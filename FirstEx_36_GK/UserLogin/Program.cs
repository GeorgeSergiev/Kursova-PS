using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        public static void ErrHandler(string errorMsg) 
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
            Logger.LogActivity(errorMsg);
        }
        private static int AdminMenu() 
        {
            int option = -2;
            while (option != 0)
            {
                Console.WriteLine("Chose your option");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Change User Role");
                Console.WriteLine("2: Change User Active Date");
                Console.WriteLine("3: List of Users");
                Console.WriteLine("4: Show Log File");
                Console.WriteLine("5: Current Session Activity");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Role:");
                        UserRoles role = (UserRoles)int.Parse(Console.ReadLine());
                        UserData.AssignUserRole(username, role);
                        break;
                    case 2:
                        Console.WriteLine("Username:");
                        string username1 = Console.ReadLine();
                        Console.WriteLine("Active Date:");
                        DateTime activeDate = DateTime.Parse(Console.ReadLine());
                        UserData.SetUserActiveTo(username1, activeDate);
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.WriteLine(Logger.GetLogFile());
                        break;
                    case 5:
                        Console.WriteLine(Logger.GetCurrentSessionActivities());
                        break;
                    default:
                        break;
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            int shouldRun = 1;
            while (shouldRun == 1)
            {
                if (!LoginValidation.UserLoginPossible())
                {
                    Console.WriteLine("Too many failed login attempts");
                    Thread.Sleep(120*1000);
                    continue;
                }

                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();
                LoginValidation validator = new LoginValidation(username, password, ErrHandler);
                User user = null;
                if (validator.ValidateUserInput(ref user))
                {
                    Console.WriteLine(user);
                    switch (LoginValidation.CurrentUserRole)
                    {
                        case UserRoles.ANONYMOUS:
                            Console.WriteLine("Anonymous");
                            break;
                        case UserRoles.ADMIN:
                            Console.WriteLine("Admin");
                            shouldRun = AdminMenu();
                            break;
                        case UserRoles.INSPECTOR:
                            Console.WriteLine("Inspector");
                            break;
                        case UserRoles.PROFESSOR:
                            Console.WriteLine("Profesor");
                            break;
                        case UserRoles.STUDENT:
                            Console.WriteLine("Student");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
