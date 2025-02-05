// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Restaurant.Domain.Db;
using Restaurant.Domain.Entities;

namespace Restaurant.Application;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Welcome to Eke Tech Restaurant!");

        // when application starts up, verify you have an admin account already setup.
        var adminStaff = AppDb.StaffTable.Where(_ => _.Value.Designation == "System Admin").FirstOrDefault();
        if(adminStaff.Value == null)
        {
            // meaning there is no admin. So go ahead and create one
            var newAdminStaff = new Staff
            {
                StaffId = 1,
                FirstName = "System",
                LastName = "Admin",
                Designation = "System Admin",
                Password = "superPassword"
            };

            newAdminStaff.CreateStaff();
        }

        Console.WriteLine("Enter your login details");
        Console.WriteLine("Staff Id:");
        var staffId = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Password:");
        var password = Console.ReadLine();
        var staff = AppDb.StaffTable.Where(_ => _.Value.StaffId == staffId && _.Value.Password == password).SingleOrDefault().Value;
        if(staff is null)
        {
            Console.WriteLine("Invalid Credential");
            return;
        }

        Console.WriteLine($"Welcome {staff.FirstName} {staff.LastName}");
        Console.WriteLine($"Select a system menu from the list below");

        int menuCounter = 0;
        if(staff.Designation == "System Admin")
        {
            List<string> systemMenu = new List<string> { "Create a new Staff", "View Staff", "Edit Staff", "Setup a new Restaurant", "Setup Restaurant Menu" };
            foreach (var sysMenu in systemMenu)
            {
                menuCounter++;
                Console.WriteLine($"{menuCounter} {sysMenu}");
            }
        }
        var menuSelection = Console.ReadLine();
        if (menuSelection == "1") 
        {
            try
            {
                Console.WriteLine("Enter staff details (staff id, first name, last name, designation, password)");
                var newStaffInfo = Console.ReadLine();
                var splitStaffInfo = newStaffInfo.Split(',');
                var newStaffData = new Staff
                {
                    StaffId = Convert.ToInt32(splitStaffInfo[0]),
                    FirstName = splitStaffInfo[1],
                    LastName = splitStaffInfo[2],
                    Designation = splitStaffInfo[3],
                    Password = splitStaffInfo[4]
                };
                newStaffData.CreateStaff();
                Console.WriteLine("Staff list");
                Console.WriteLine("===================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(String.Format("{0}\t {1}\t {2}\t {3}", "StaffId", "First Name", "Last Name", "Designation"));
                Console.WriteLine("========================================================================");
                var staffList = AppDb.StaffTable.Values.ToList();
                foreach (var record in staffList)
                {
                    Console.WriteLine(String.Format("{0}\t {1}\t {2}\t {3}", record.StaffId, record.FirstName, record.LastName, record.Designation));
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Something went wrong: {ex.Message}");
            }

        }

        Console.ReadLine();
    }

}
