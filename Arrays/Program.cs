#region LabTask1
/*---> İki ədəd verilir. Birinci ədədin ikinci ədəd qüvvətini hesablayan alqoritmin diaqramını qurun. <---*/

//int x = int.Parse(Console.ReadLine());
//int y = int.Parse(Console.ReadLine());

//int num = x;

//for (int i = 1; i < y; i++)
//{
//    num *= x;
//}

//Console.WriteLine(num);

#endregion

#region LabTask2
/*---> Verilmiş ədədin neçə mərtəbəli olduğunu print edən alqoritmin diaqramını qurun. <---*/

//int num = int.Parse(Console.ReadLine());
//int count = 0;

//while(num > 0)
//{
//    num /= 10;
//    count++;
//}

//Console.WriteLine(count);

#endregion


#region LabTask3
/*---> Ədədlərdən ibarət arrayda neçə rəqəm olduğunu ekrana çap edin (Məs: { 1,77,6,14} arrayında 2 rəqəm var ) <---*/

int[] nums = { 1, 77, 6, 14, 56, 8, 2 };
int count = 0;

for (int i = 0; i < nums.Length; i++)
{
    if (nums[i] < 10 && nums[i] > 0) count++;
}

Console.WriteLine(count);

#endregion