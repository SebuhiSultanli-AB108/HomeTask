using EF_Core.Core;
using EF_Core.Models;

namespace EF_Core.App;

public class MarketApp
{
    public void Start()
    {
        Console.WriteLine("Hello!");
        LoginRegister();
    }
    void LoginRegister()
    {
        SQLManager manager = new SQLManager();
        bool isLooping = true;
        while (isLooping)
        {
            PrintLoginRegisterInfo();
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Name:");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Surname:");
                    string Surname = Console.ReadLine();
                    Console.WriteLine("Username:");
                    string Username = Console.ReadLine();
                    Console.WriteLine("Password:");
                    string Password = Console.ReadLine();
                    Console.WriteLine("Role:");
                    string Role = Console.ReadLine();
                    manager.Add(new User
                    {
                        Name = Name,
                        Surname = Surname,
                        Username = Username,
                        Password = Password,
                        RoleId = manager.FindIdByName<Role>(Role)
                    });
                    break;
                case "2":
                    Console.WriteLine("Please type Username and Password to login:");
                    if (manager.Login(Console.ReadLine(), Console.ReadLine()))
                    {
                        Console.WriteLine($"Welcome!");
                        isLooping = false;
                        Console.WriteLine(manager.GetRole(manager.GetCurrentUser()));
                        if (manager.GetRole(manager.GetCurrentUser()) == "Admin")
                            AdminMenu();
                        else if (manager.GetRole(manager.GetCurrentUser()) == "User")
                            MainMenu();
                        else Console.WriteLine("Role not found!");
                    }
                    else
                    {
                        Console.WriteLine("Username or Password is incorrect!\nPlease try again:");
                    }
                    break;
                case "0":
                    Console.WriteLine("Bye!");
                    isLooping = false;
                    break;
                default:
                    break;
            }
        }
    }
    void MainMenu()
    {
        SQLManager manager = new SQLManager();
        bool isLooping = true;
        while (isLooping)
        {
            PrintMainMenuInfo();
            switch (Console.ReadLine())
            {
                case "1":
                    manager.PrintAll<Product>();
                    bool isShopping = true;
                    while (isShopping)
                    {
                        PrintShoppingMenuInfo();
                        switch (Console.ReadLine())
                        {
                            case "1":
                                manager.Add(new Basket
                                {
                                    ProductId = Convert.ToInt32(Console.ReadLine()),
                                    UserId = manager.GetCurrentUser(),
                                });
                                break;
                            case "2":
                                isShopping = false;
                                MainMenu();
                                break;
                            case "0":
                                Console.WriteLine("Bye!");
                                isShopping = false;
                                isLooping = false;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "2":
                    manager.PrintAll<Basket>();
                    isLooping = false;
                    ManageBasket();
                    break;
                case "3":
                    isLooping = false;
                    LoginRegister();
                    break;
                case "0":
                    Console.WriteLine("Bye!");
                    isLooping = false;
                    break;
                default:
                    break;
            }
        }
    }
    void AdminMenu()
    {
        SQLManager manager = new SQLManager();
        bool isLooping = true;
        while (isLooping)
        {
            PrintAdminMenuInfo();
            switch (Console.ReadLine())
            {
                case "1":
                    manager.PrintAll<User>();
                    break;
                case "2":
                    manager.PrintAll<History>();
                    break;
                case "3":
                    manager.PrintAll<Product>();
                    bool isManaging = true;
                    while (isManaging)
                    {
                        PrintAdminProductManageInfo();
                        switch (Console.ReadLine())
                        {
                            case "1":
                                manager.Delete<Product>(Convert.ToInt32(Console.ReadLine()));
                                break;
                            case "2":
                                manager.DeleteAll<Product>();
                                break;
                            case "3":
                                manager.Add(new Product
                                {
                                    Name = Console.ReadLine(),
                                    Price = Convert.ToDecimal(Console.ReadLine()),
                                });
                                break;
                            case "4":
                                isManaging = false;
                                AdminMenu();
                                break;
                            case "0":
                                Console.WriteLine("Bye!");
                                isManaging = false;
                                isLooping = false;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "4":
                    isLooping = false;
                    LoginRegister();
                    break;
                case "0":
                    Console.WriteLine("Bye!");
                    isLooping = false;
                    break;
                default:
                    break;
            }
        }
    }
    void ManageBasket()
    {
        SQLManager manager = new SQLManager();
        bool isLooping = true;
        while (isLooping)
        {
            PrintBasketManageInfo();
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Enter Id:");
                    manager.Delete<Basket>(Convert.ToInt32(Console.ReadLine()));
                    break;
                case "2":
                    manager.DeleteAll<Basket>();
                    break;
                case "3":
                    manager.Buy();
                    Console.WriteLine("Item(s) bought!");
                    break;
                case "0":
                    Console.WriteLine("Bye!");
                    isLooping = false;
                    break;
                default:
                    break;
            }
        }
    }
    void ManageProduct()
    {
        SQLManager manager = new SQLManager();
        bool isLooping = true;
        while (isLooping)
        {
            PrintProductManageInfo();
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Enter Id:");
                    manager.Delete<Product>(Convert.ToInt32(Console.ReadLine()));
                    break;
                case "2":
                    manager.DeleteAll<Product>();
                    break;
                case "0":
                    Console.WriteLine("Bye!");
                    isLooping = false;
                    break;
                default:
                    break;
            }
        }
    }



    #region PrintInfo
    void PrintMainMenuInfo()
    {
        string Info = """
                       ┌──────────────────────────────────────────────────────┐
                       │ 1.See products                                       │
                       │ 2.See basket                                         │
                       │ 3.Log out                                            │
                       │ 0.Quit                                               │
                       │                                                      │
                       │ Note: To see the controls type any unregistered key! │
                       └──────────────────────────────────────────────────────┘
                       """;
        Console.WriteLine(Info);
    }
    void PrintShoppingMenuInfo()
    {
        string Info = """
                       ┌──────────────────────────────────────────────────────┐
                       │ 1.Buy by id                                          │
                       │ 2.Back                                               │
                       │ 0.Quit                                               │
                       │                                                      │
                       │ Note: To see the controls type any unregistered key! │
                       └──────────────────────────────────────────────────────┘
                       """;
        Console.WriteLine(Info);
    }
    void PrintAdminMenuInfo()
    {
        string Info = """
                       ┌──────────────────────────────────────────────────────┐
                       │ 1.See users                                          │
                       │ 2.See history                                        │
                       │ 3.See products                                       │
                       │ 4.Log out                                            │
                       │ 0.Quit                                               │
                       │                                                      │
                       │ Note: To see the controls type any unregistered key! │
                       └──────────────────────────────────────────────────────┘
                       """;
        Console.WriteLine(Info);
    }
    void PrintBasketManageInfo()
    {
        string Info = """
                       ┌──────────────────────────────────────────────────────┐
                       │ 1.Delete by id                                       │
                       │ 2.Delete all                                         │
                       │ 3.Buy                                                │
                       │ 0.Quit                                               │
                       │                                                      │
                       │ Note: To see the controls type any unregistered key! │
                       └──────────────────────────────────────────────────────┘
                       """;
        Console.WriteLine(Info);
    }
    void PrintAdminProductManageInfo()
    {
        string Info = """
                       ┌──────────────────────────────────────────────────────┐
                       │ 1.Delete by id                                       │
                       │ 2.Delete all                                         │
                       │ 3.Add                                                │
                       │ 4.Back                                               │
                       │ 0.Quit                                               │
                       │                                                      │
                       │ Note: To see the controls type any unregistered key! │
                       └──────────────────────────────────────────────────────┘
                       """;
        Console.WriteLine(Info);
    }
    void PrintProductManageInfo()
    {
        string Info = """
                       ┌──────────────────────────────────────────────────────┐
                       │ 1.Delete by id                                       │
                       │ 2.Delete all                                         │
                       │ 0.Quit                                               │
                       │                                                      │
                       │ Note: To see the controls type any unregistered key! │
                       └──────────────────────────────────────────────────────┘
                       """;
        Console.WriteLine(Info);
    }
    void PrintLoginRegisterInfo()
    {
        string Info = """
                      ┌──────────────────────────────────────────────────────┐
                      │ 1. Register                                          │
                      │ 2. Login                                             │
                      │ 0. Quit                                              │
                      │                                                      │
                      │ Note: To see the controls type any unregistered key! │
                      └──────────────────────────────────────────────────────┘
                      """;
        Console.WriteLine(Info);
    }
    #endregion
}
