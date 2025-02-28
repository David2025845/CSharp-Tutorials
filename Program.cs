using System;
using System.Collections;

class program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Application Module");
            Console.WriteLine("1. Staff Management");
            Console.WriteLine("2. Restaurant Management");
            Console.WriteLine("3. Exit");
            Console.WriteLine("select an option");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                StaffManagement();
                break;
                case "2":
                RestaurantManagement();
                break;
                case "3":
                return;
                default:
                Console.WriteLine("invalid selection , please try again .");
            }
        }
    }
    static void StaffManagement()
    {
        while (true)
        {
            Console.WriteLine("staff management");
            Console.WriteLine("1. view staff");
            Console.WriteLine("2. create staff");
            Console.WriteLine("3. edit staff");
            Console.WriteLine("4. back");
            Console.WriteLine("select an option");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                Console.WriteLine("viewing staff...");
                break;
                case "2":
                Console.WriteLine("creating staff...");
                break;
                case "3":
                Console.WriteLine("editing staff...");
                break;
                case "4":
                return;
                default:
                Console.WriteLine("invalid selection, please try again");
                break;
            }
        }
    }
    static void RestaurantManagement()
    {
        while (true)
        {
            Console.WriteLine("Restaurant Management");
            Console.WriteLine("1. Menu setup");
            Console.WriteLine("2. Menu item setup");
            Console.WriteLine("3. back");
            Console.WriteLine("select an option");
            string choice = Console.ReadLine();
            switch (choice)
            case "1":
            Console.WriteLine("setting up menu...");
            break;
            case "2":
            Console.WriteLine("setting up menu items...");
            break;
            case "3":
            return;
            default:
            Console.WriteLine("invalid selection, please try again.............");
            break;
        }
    }
}


                




        