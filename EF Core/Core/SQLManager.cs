using EF_Core.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EF_Core.Core;

class SQLManager
{
    string _connStr = "Server=localhost\\SQLEXPRESS;Database=EFCore;Trusted_Connection=True;TrustServerCertificate=True;";

    public static int currentUser;

    #region SetGetCurrentUser
    public void SetCurrentUser(int id)
    {
        currentUser = id;
    }
    public int GetCurrentUser()
    {
        return currentUser;
    }
    #endregion

    #region Add
    public void Add(object obj)
    {
        var props = obj.GetType().GetProperties().Select(x => x.Name);
        var values = obj.GetType().GetProperties().Select(x => ("'" + x.GetValue(obj)) + "'").ToList();
        string tableName = obj.GetType().Name;
        string propsStr = string.Join(',', props);
        string valuesStr = string.Join(',', values);
        Exe($"INSERT INTO {tableName}s ({propsStr}) VALUES ({valuesStr})");
    }
    #endregion

    #region Buy
    public void Buy()
    {
        DataTable dt = GenerateDataTable<Basket>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = dt.Rows[i];
            Add(new History
            {
                Productname = row.ItemArray[1].ToString(),
                Price = Convert.ToDecimal(row.ItemArray[2]),
                Username = FindNameById<User>(currentUser),
            });
        }
    }
    #endregion

    #region Delete
    public void Delete<T>(int id)
    {
        Exe($"DELETE {typeof(T).Name}s WHERE Id = {id}");
    }
    public void Delete<T>(string name)
    {
        Exe($"DELETE {typeof(T).Name}s WHERE Name = '{name}'");
    }
    public void DeleteAll<T>()
    {
        Exe($"DELETE {typeof(T).Name}s WHERE 1=1");
    }
    #endregion

    #region Update
    public void Update(int id, object obj)
    {
        var props = obj.GetType().GetProperties().Select(x => x.Name).ToList();
        var values = obj.GetType().GetProperties().Select(x => ("'" + x.GetValue(obj)) + "'").ToList();

        List<string> setList = new List<string>();
        for (int i = 0; i < props.Count; i++)
        {
            setList.Add($"{props[i].ToString()} = {values[i]}");
        }
        Exe($"UPDATE {obj.GetType().Name}s  SET {string.Join(',', setList)} WHERE Id = {id}");
    }
    #endregion

    #region Print
    public void PrintAll<T>()
    {
        DataTable dt = GenerateDataTable<T>();

        //Stores the max lengths of the columns
        int[] padLen = new int[dt.Columns.Count];
        string columnNames = string.Empty;

        //Generate first row
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            int maxLen = GetMaxLenOfColumn<T>(dt.Columns[i]);
            padLen[i] = maxLen;
            columnNames += '│' + dt.Columns[i].ColumnName.PadRight(maxLen, ' ');
        }
        columnNames += '│';

        GenerateTableLine(padLen, '┌', '┬', '┐');
        Console.WriteLine(columnNames);
        GenerateTableLine(padLen, '├', '┼', '┤');

        //Generate middle rows
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = dt.Rows[i];
            for (int j = 0; j < row.ItemArray.Length; j++)
            {
                if (row.ItemArray[j].GetType().ToString() != "System.DBNull")
                {
                    Console.Write('│');
                    if (row.ItemArray[j].ToString() == "True")
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    else if (row.ItemArray[j].ToString() == "False")
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(row.ItemArray[j].ToString().PadRight(padLen[j]));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write('│');
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("NULL".PadRight(padLen[j]));
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (j == row.ItemArray.Length - 1) Console.Write('│');
            }
            Console.WriteLine();
            if (i != dt.Rows.Count - 1)
                GenerateTableLine(padLen, '├', '┼', '┤');
        }
        //Generate last line
        GenerateTableLine(padLen, '└', '┴', '┘');
    }
    void GenerateTableLine(int[] padLen, char first, char mid, char last)
    {
        string upperLine = string.Empty;
        Console.Write(first);
        for (int i = 0; i < padLen.Length; i++)
        {
            if (i != padLen.Length - 1)
                upperLine += $"{"".PadRight(padLen[i], '─') + mid}";
            else
                upperLine += $"{"".PadRight(padLen[i], '─') + last}";
        }
        Console.WriteLine(upperLine);
    }
    DataTable GenerateDataTable<T>()
    {
        DataTable dt = new DataTable();
        using SqlConnection conn = new SqlConnection(_connStr);
        {
            conn.Open();
            if (typeof(T) == typeof(User))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"SELECT x.Id, x.Name, x.Surname, x.Username, x.[Password], x.IsDeleted, y.Name as Role FROM {typeof(T).Name}s AS x FULL JOIN Roles as Y ON x.RoleId = y.Id", conn))
                    sda.Fill(dt);
            }
            else if (typeof(T) == typeof(Basket))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"SELECT x.Id, z.Name as Product, z.Price FROM {typeof(T).Name}s AS x JOIN Users as Y ON x.UserId = y.Id JOIN Products as Z ON x.ProductId = z.Id WHERE x.UserId = {currentUser}", conn))
                    sda.Fill(dt);
            }
            else if (typeof(T) == typeof(Product))
            {
                string str = string.Empty;
                if (GetRole(currentUser) == "User")
                    str = $"SELECT * FROM {typeof(T).Name}s WHERE IsDeleted = {0}";
                else
                    str = $"SELECT * FROM {typeof(T).Name}s";

                using (SqlDataAdapter sda = new SqlDataAdapter(str, conn))
                    sda.Fill(dt);
            }
            else
            {
                using (SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM {typeof(T).Name}s", conn))
                    sda.Fill(dt);
            }
            return dt;
        }
    }
    public int GetMaxLenOfColumn<T>(DataColumn column)
    {
        string cmdStr = $"SELECT CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{typeof(T).Name}s' AND COLUMN_NAME = '{column.ColumnName}'";
        using SqlConnection conn = new SqlConnection(_connStr);
        using SqlCommand cmd = new SqlCommand(cmdStr, conn);
        conn.Open();
        var result = cmd.ExecuteScalar();

        //Ugly code :(
        if (column.ColumnName == "Id") return 5;
        else if (column.ColumnName == "Price") return 11;
        else if (column.ColumnName == "IsDeleted") return 9;
        else if (column.ColumnName == "Role")
        {
            Console.WriteLine("--------------12---------------");
            return 12;
        }
        else if (column.ColumnName == "User") return 12;
        else if (column.ColumnName == "Product") return 12;
        else return Convert.ToInt32(result);
    }
    #endregion

    #region Find
    public int FindIdByName<T>(string name)
    {
        using SqlConnection conn = new SqlConnection(_connStr);
        using SqlCommand cmd = new SqlCommand($"SELECT Id FROM {typeof(T).Name}s WHERE Name = '{name}'", conn);
        conn.Open();
        var result = cmd.ExecuteScalar();
        return Convert.ToInt32(result);
    }
    public string FindNameById<T>(int id)
    {
        using SqlConnection conn = new SqlConnection(_connStr);
        using SqlCommand cmd = new SqlCommand($"SELECT Name FROM {typeof(T).Name}s WHERE Id = '{id}'", conn);
        conn.Open();
        var result = cmd.ExecuteScalar();
        return result.ToString();
    }
    #endregion

    #region GetRole
    public string GetRole(int id)
    {
        using SqlConnection conn = new SqlConnection(_connStr);
        using SqlCommand cmd = new SqlCommand($"SELECT y.Name as Role FROM Users AS x FULL JOIN Roles as Y ON x.RoleId = y.Id WHERE X.ID = {id}", conn);
        conn.Open();
        var result = cmd.ExecuteScalar();
        return result.ToString();
    }
    #endregion

    #region Login
    public bool Login(string username, string password)
    {
        using SqlConnection conn = new SqlConnection(_connStr);
        using SqlCommand cmd1 = new SqlCommand($"SELECT Id FROM Users WHERE Username = '{username}' AND Password = '{password}'", conn);
        using SqlCommand cmd2 = new SqlCommand($"SELECT IsDeleted FROM Users WHERE Username = '{username}' AND Password = '{password}'", conn);
        conn.Open();
        var result1 = Convert.ToInt32(cmd1.ExecuteScalar());
        var result2 = Convert.ToInt32(cmd2.ExecuteScalar());
        currentUser = result1;
        if (result1 != 0 && result2 == 0)
            return true;
        else
            return false;
    }
    #endregion

    #region Execute
    void Exe(string cmdStr)
    {
        using SqlConnection conn = new SqlConnection(_connStr);
        using SqlCommand cmd = new SqlCommand(cmdStr, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
    }
    #endregion
}
