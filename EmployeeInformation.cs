using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRollManagement
{
    public enum WorkLocation{Chennai, Delhi , Coimbator}
    public enum Gender{Male, Female,Other} 
    public class EmployeeInformation
    {
        private int _employeeid=1000;
       public string EmployeeID {get; set;}
       public string EmployeeName{get; set;}
       public string Role{get ; set;}
       public WorkLocation Location {get; set;}
       public string TeamName{get; set;}
       public DateTime JoiningDate{get; set;}
       public double WorkingDays{get; set;}
       public double LeaveDays{get; set;}
       public Gender Gender{get; set;}
       public EmployeeInformation(string employeename , string role , WorkLocation location , string teamname ,DateTime joiningdate , double workingdays , double leavedays,Gender gender)
       {
        _employeeid++;
        EmployeeID="SF"+_employeeid;
        EmployeeName=employeename;
        Role=role;
        Location=location;
        TeamName=teamname;
        JoiningDate=joiningdate;
        WorkingDays=workingdays;
        LeaveDays=leavedays;
        Gender = gender;
       }
       public EmployeeInformation(string employee)
       {
        string[] value = employee.Split(",");
        _employeeid=int.Parse(value[0].Remove(0 ,2));
        EmployeeID=value[0];
        EmployeeName=value[1];
        Role=value[2];
        Location=Enum.Parse<WorkLocation>(value[3]);
        TeamName=value[4];
        JoiningDate=DateTime.ParseExact(value[5],"dd/MM/yyyy",null);
        WorkingDays=int.Parse(value[6]);
        LeaveDays=int.Parse(value[7]);
        Gender = Enum.Parse<Gender>(value[8]);
       }



    }
}