using System;
using System.Collections.Generic;
namespace EmployeePayRollManagement
{
    class Program
    {
        public static List<EmployeeInformation> employeeInformation = new List<EmployeeInformation>();
        static EmployeeInformation currentemployee;
        public static void Main()
        {
           FileManipulation.Create();
           FileManipulation.ReadCSV();
            Console.WriteLine("EMPLOYEE PAYROLL MANAGEMENT!");
            string val = "yes";
            do
            {
                Console.WriteLine(" 1 . Registration ");
                Console.WriteLine(" 2 . Login ");
                Console.WriteLine(" 3 . Exit");
                Console.WriteLine("Choose This Option");
                string option = Console.ReadLine();


                switch (option)
                {
                    case "1":
                        {
                            //called registration method
                            Registration();
                            break;
                        }
                    case "2":
                        {
                            //called login method
                            Login();
                            break;
                        }
                    case "3":
                        {//exit from the main menu
                            Console.WriteLine("THANK YOU! ..");
                            val = "no";
                            break;
                        }
                }
            } while (val == "yes");
            FileManipulation.WriteCSV();

        }
        public static void Login()
        {
            Console.WriteLine("Enter Your EmployeeID ");
            string employeid = Console.ReadLine().ToUpper();
            bool check = false;
            foreach (EmployeeInformation employeedetail in employeeInformation)
            {
                if (employeedetail.EmployeeID == employeid)
                {
                    check = true;
                    currentemployee = employeedetail;
                    Submenu();
                    break;

                }
            }
            if (check == false)
            {
                Console.WriteLine("USER INVALID ID");
            }
        }
        public static void Submenu()
        {
            string value = "yes";
            Console.WriteLine("SUBMENU");
            do
            {
                Console.WriteLine(" 1 . CalculateSalary");
                Console.WriteLine(" 2 . DisplayDetails");
                Console.WriteLine(" 3 . Exit");
                Console.WriteLine("Choose This Option");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        {
                            CalculateSalary();
                            break;
                        }
                    case "2":
                        {
                            DisplayDetails();
                            break;
                        }
                    case "3":
                        {
                            //go to main menu
                            value = "no";
                            Console.WriteLine("Your Selected Main Menu");
                            break;
                        }
                }
            } while (value == "yes");

        }
        public static void CalculateSalary()
        {
            double salary = (currentemployee.WorkingDays -currentemployee.LeaveDays)* 500;
            Console.WriteLine("YOUR SALARY IS : " + salary);

        }
        public static void DisplayDetails()
        {
            foreach (EmployeeInformation employee in employeeInformation)
            {
                Console.WriteLine("EMPLOYEE ID           : " + employee.EmployeeID);
                Console.WriteLine("EMPLOYEENAME          : " + employee.EmployeeName);
                Console.WriteLine("ROLE                  : " + employee.Role);
                Console.WriteLine("WORKLOCATION          : " + employee.Location);
                Console.WriteLine("TEAM NAME             : " + employee.TeamName);
                Console.WriteLine("DATE OF JOINING       : " + employee.JoiningDate.ToString("dd/MM/yyyy"));
                Console.WriteLine("WORKING DAYS          : " + employee.WorkingDays);
                Console.WriteLine("NUMBER OF LEAVE TAKEN : " + employee.LeaveDays);
                Console.WriteLine("GENDER                : " + employee.Gender);



            }
        }
        public static void Registration()
        {
            string name = "";
            bool check = false;
            do
            {

                Console.WriteLine("Enter Your Name");
                name = Console.ReadLine().Trim();
                if (name.Contains("  ") || string.IsNullOrEmpty(name) || Specialcase(name))
                {
                    check = false;
                    Console.WriteLine("Your Name Is InValid Please Enter Valid One");
                }
                else
                {
                    check = true;
                    break;
                }
            } while (!check);

            string roll="";
            bool check1 =false;
            do
            {
            Console.WriteLine("Enter Your Roll");
            roll = Console.ReadLine().Trim();
            if(roll.Contains("  ") || string.IsNullOrEmpty(roll) || Specialcase(roll))
            {
                check1 = false;
                Console.WriteLine("Your Roll Is Not A Integer So Please Try Again");
            }
            else
            {
                check1 = true;
                break;
            }
            }while(!check1);
                WorkLocation workLocation;
                do
                {

            Console.WriteLine("Enter Your WorkSpace Available(Chennai , Delhi , Coimbator)");
             string location = Console.ReadLine();
             if(Enum.TryParse(location , true , out workLocation))
             {
                if(int.TryParse(location ,out _ ))
                {
                    Console.WriteLine("Your Input is Invalid");
                }
                else
                {
                    break;
                }
             }
             else
             {
                Console.WriteLine("Invalid Input");
             }
                }while(true);

            string teamname="";
            bool check2 =false;
            do
            {
            Console.WriteLine("Enter Your Team Name");
             teamname = Console.ReadLine().Trim();
             if(teamname.Contains("  ") || string.IsNullOrEmpty(teamname) || Specialcase(teamname))
             {
                check2=false;
                Console.WriteLine("Invalid Team Name Please Try Again");
             }
             else
             {
                check2=true;
                break;
             }

            }while(!check2);

            DateTime date;
            do
            {
                Console.WriteLine("Enter Your DateOfJoining must be (dd/MM/yyyy)");
                if(DateTime.TryParseExact(Console.ReadLine() , "dd/MM/yyyy" , null , System.Globalization.DateTimeStyles.None , out date))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Your Date Format Is Invalid Please Try Again");
                }

            }while(true);

            double workdays;
            do
            {

            Console.WriteLine("Enter Your Number Of Working Days");
             string workingdays = Console.ReadLine().Trim();
             if(double.TryParse(workingdays , out workdays) && workdays<=31 && workdays>0 )
             {
                        break;
             }
             else
             {
                Console.WriteLine("Invalid input !!..Monthly Working Days Only 31 days Please Try Again");
             }
            }while(true);
            double LeaveDays;
            do
            {

            Console.WriteLine("Enter Your Number Of Leave Days");
            string leavedays = Console.ReadLine().Trim();
            if(double.TryParse(leavedays , out LeaveDays) && LeaveDays<workdays && LeaveDays>0)
            {
                break;
            }
            else
            {
                Console.WriteLine(" Invalid Input Please Try Again ");
            }
            }while(true);

            Gender gender1;
            do{
            Console.WriteLine("Enter Your Gender (Male , Female, Others)");
            string  gender =Console.ReadLine();
            if(Enum.TryParse(gender ,true, out gender1 ))
            {
                if(int.TryParse(gender , out _))
                {
                    Console.WriteLine("Your Input Is Invalid Please Try Again");
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Input  Please Enter The  Correct Gender ");
            }
            }while(true);

            EmployeeInformation employeeInfo = new EmployeeInformation(name, roll, workLocation, teamname, date, workdays, LeaveDays, gender1);
            employeeInformation.Add(employeeInfo);
            Console.WriteLine("YOUR EMPLOYEE ID IS : " + employeeInfo.EmployeeID);



        }
        public static bool Specialcase(string name)
        {
            foreach (char name1 in name)
            {
                if (!char.IsLetter(name1) && !char.IsWhiteSpace(name1))
                {
                    return true;
                }
            }
            return false;
        }
    }
}