using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace EmployeePayRollManagement
{
    public class FileManipulation
    {
        public static void Create()
        {
            if(!Directory.Exists("EmployeeInfo"))
            {
                Console.WriteLine("Creating folder....");
                Directory.CreateDirectory("EmployeeInfo");
            }
            else
            {
                Console.WriteLine("Already exist...");
            }
            if(!File.Exists("EmployeeInfo/Informations.csv"))
            {
                Console.WriteLine("Creating files...");
                File.Create("EmployeeInfo/Informations.csv");
            }
            else
            {
                Console.WriteLine("Already exist");
            }
        }
        public static void WriteCSV()
        {
            string[] strings = new string[Program.employeeInformation.Count];
            for(int i=0;i<Program.employeeInformation.Count;i++)
            {
                strings[i]= Program.employeeInformation[i].EmployeeID+","+Program.employeeInformation[i].EmployeeName+","+Program.employeeInformation[i].Role+","+Program.employeeInformation[i].Location+","+Program.employeeInformation[i].TeamName+","+Program.employeeInformation[i].JoiningDate.ToString("dd/MM/yyyy")+","+Program.employeeInformation[i].WorkingDays+","+Program.employeeInformation[i].LeaveDays+","+Program.employeeInformation[i].Gender;
            }
            File.WriteAllLines("EmployeeInfo/Informations.csv" , strings);
        }
        public static void ReadCSV()
        {
            string[] read =  File.ReadAllLines("EmployeeInfo/Informations.csv");
            foreach(string val in read)
            {
                EmployeeInformation employee= new EmployeeInformation(val);
                Program.employeeInformation.Add(employee);
            }
        }
    }
}