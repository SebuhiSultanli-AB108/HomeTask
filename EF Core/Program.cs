using EF_Core.App;

namespace EF_Core;

class Program
{
    static void Main()
    {
        #region Comments
        //SQLManager manager = new SQLManager();

        //manager.Add(new User { Name = "Name1", Password = "Password1", Surname = "Surname1", Username = "Username1" });
        //manager.Add(new Product { Name = "Name1", Price = 100m });

        //manager.PrintAll<User>();
        //manager.PrintAll<Product>();

        //manager.Delete<User>(41);
        //manager.Delete<User>("Name40");

        //manager.Delete<User>(14);
        //manager.Delete<User>("Name6");

        //manager.Update(14, new Product { Name = "Name14", Price = 1400m });
        //manager.Update(38, new User { Name = "Name38", Password = "Password38", Surname = "Surname38", Username = "Username38" });

        //SQLManager manager = new SQLManager();
        //manager.Update(41, new User
        //{
        //    Name = "Name1",
        //    Password = "Password1",
        //    Surname = "Surname1",
        //    Username = "Username1",
        //    RoleId = manager.FindIdByName<Role>("Admin")
        //});
        //manager.PrintAll<User>();
        #endregion
        MarketApp marketApp = new MarketApp();
        marketApp.Start();
    }
}
