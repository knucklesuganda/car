using CarsDestiny.Models;
using CarsDestiny.Models.Cars;
using CarsDestiny.Models.Orders;
using CarsDestiny.Models.Users;
using System;

namespace DulatCareHonor
{
    public class CarApp
    {
        private User User { get; set; }

        //Registration
        void RegisterOrLogin()
        {

            Console.WriteLine("1) Register");
            Console.WriteLine("2) Login");
            while (true)
            {
                try
                {


                    ConsoleKey choice = Console.ReadKey().Key;
                    Console.WriteLine();

                    if (choice == ConsoleKey.D1)
                    {
                        RegisterMenu();
                        return;
                    }
                    else if (choice == ConsoleKey.D2)
                    {
                        LoginMenu();
                        return;
                    }
                    else
                        Console.WriteLine("Write correct number!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
        void LoginMenu()
        {

            try
            {
                while (true)
                {
                    Console.Write("Write name:");
                    string name = Console.ReadLine();

                    Console.Write("Write password:");
                    string password = Console.ReadLine();
                    string message;

                    ServiceUser serviceUser = new ServiceUser();
                    User user = serviceUser.LogOn(name, password, out message);

                    if (user == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong name or password");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        User = user;
                        Console.WriteLine("Hello {0}", user.Name);
                        return;

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        void RegisterMenu()
        {

            while (true)
            {
                try
                {

                    Console.Write("Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Password:");
                    string password = Console.ReadLine();

                    Console.WriteLine("Rights:");
                    string rights = Console.ReadLine();

                    User user = new User(name, password, rights);
                    string message;

                    ServiceUser serviceUser = new ServiceUser();
                    serviceUser.Registration(user, out message);

                    User = user;
                    Console.WriteLine("User created!");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        //Main
        public void Main()
        {
            RegisterOrLogin();
            Console.Clear();

            while (true)
            {
                Console.Clear();

                try
                {

                    Console.WriteLine("1) Orders");
                    Console.WriteLine("2) Users");
                    Console.WriteLine("3) Cars");
                    Console.WriteLine("4) Exit");

                    ConsoleKey choice = Console.ReadKey().Key;

                    switch (choice)
                    {

                        case ConsoleKey.D1:
                            OrdersMain();
                            break;

                        case ConsoleKey.D2:
                            //Users();
                            break;

                        case ConsoleKey.D3:
                            //CarsMain();
                            break;

                        default:
                            Console.WriteLine("Choose real option");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
        private void OrdersMain()
        {
            Console.Clear();

            while (true)
            {
                Console.Clear();

                try
                {

                    Console.WriteLine("1)Show orders");
                    Console.WriteLine("2)Create order");
                    Console.WriteLine("3)Remove order");
                    Console.WriteLine("4)Update order");

                    ConsoleKey key = Console.ReadKey().Key;

                    OrderService serviceOrder = new OrderService();
                    string message;

                    switch (key)
                    {

                        case ConsoleKey.D1:
                            //serviceOrder.GetAllOrders(out message);
                            break;

                        case ConsoleKey.D2:
                            addOrder();
                            break;

                        default:
                            Console.WriteLine("Write correct number!");
                            break;

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }

        private void addOrder()
        {

            try
            {
                OrderService orderService = new OrderService();

                DateTime start = DateTime.Now;
                CarService carService = new CarService();
                Car orderedCar = null;

                Console.WriteLine("1) Choose car");
                Console.WriteLine("2) Create car");

                while (true)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.D1:

                            Console.WriteLine("1) Find car by number");
                            Console.WriteLine("2) Find car by model");

                            ConsoleKey carChoose = Console.ReadKey().Key;
                            string message;

                            switch (carChoose)
                            {

                                case ConsoleKey.D1:
                                    Console.Write("Write number:");
                                    orderedCar = carService.FindCarByNumber(Convert.ToInt32(Console.ReadLine()), out message);
                                    break;

                                case ConsoleKey.D2:
                                    Console.Write("Write model:");
                                    orderedCar = carService.FindCarByModel(Console.ReadLine(), out message);
                                    break;

                                default:
                                    Console.WriteLine("Write correct number!");
                                    break;

                            }

                            break;

                        default:
                            Console.WriteLine("Write correct number!");
                            break;

                    }

                    if (orderedCar != null)
                        break;
                }

                Console.Write("Write breaks info:");
                string breakInfo = Console.ReadLine();

                Console.Write("Write recomendation:");
                string recomendation = Console.ReadLine();

                Component comp = new Component();
                comp.Name = Console.ReadLine();
                comp.Info = Console.ReadLine();

                orderService.CreateOrder(start, orderedCar, breakInfo, recomendation, User, comp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }

}