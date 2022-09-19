using KAlmache_Project1;
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KAlmache_Project1 { 
class Program
{
    static void Main(string[] args)
    {
            //HOW TO INITIALIZE  THE SYSTEM
            //TEAM 1
            //2 instances of Date
            DateTime startDate = new DateTime(2022, 02, 01);
            DateTime endDate = new DateTime(2022, 08, 05);
            DateTime startDate2 = new DateTime(2022, 05, 01);
            DateTime endDate2 = new DateTime(2022, 09, 22);
            DateTime startDate3 = new DateTime(2021, 12, 11);
            DateTime endDate3 = new DateTime(2022, 10, 22);
            DateTime startDate4 = new DateTime(2022, 05, 01);
            DateTime endDate4 = new DateTime(2022, 12, 10);
            //TODAYS DATE
            DateTime thisDay = DateTime.Today;
            List<ProjectTeam> myTeams = new List<ProjectTeam>();

       

            //create 2 programmer TEAM 1 
            Programmer programmer1 = new Programmer("kathy", "almache", "Javascript", startDate, endDate);
            Programmer programmer2 = new Programmer("isra", "barros", "Phyton", startDate2, endDate2);
            //create 2 programmer TEAM 2
            Programmer programmer3 = new Programmer("Juan", "lopez", "C#", startDate3, endDate3);
            Programmer programmer4 = new Programmer("Pascal", "perez", "Java", startDate4, endDate4);

            //calculation of number of days and salary



            programmer3.calculeSalary("Half", programmer3.calculeDuration());
            programmer4.calculeSalary("Half", programmer4.calculeDuration());

            /*calculation of days of this month*/
            programmer1.calculeDurationUntilToday(thisDay);
            programmer2.calculeDurationUntilToday(thisDay);

            //set in the new constructor to put salary and duration this month
         
            programmer1.DurationUntilToday = programmer1.calculeDurationUntilToday(thisDay);
            programmer1.Salary = programmer1.calculeSalary("Full", programmer1.calculeDuration());

            programmer2.DurationUntilToday = programmer2.calculeDurationUntilToday(thisDay);
            programmer2.Salary = programmer2.calculeSalary("Full", programmer2.calculeDuration());

            programmer3.DurationUntilToday = programmer3.calculeDurationUntilToday(thisDay);
            programmer3.Salary = programmer3.calculeSalary("Half", programmer3.calculeDuration());

            programmer4.DurationUntilToday = programmer4.calculeDurationUntilToday(thisDay);
            programmer4.Salary = programmer4.calculeSalary("Half", programmer4.calculeDuration());


            /*TEAM 1 */
            ProjectTeam myFirstTeam1 = new ProjectTeam("PROJECT TEAM 1 - WEB DEVELOPMENT",programmer1,programmer2);

            ProjectTeam myFirstTeam2 = new ProjectTeam("PROJECT TEAM 2 - BACKEND JAVA", programmer3, programmer4);

            myTeams.Add(myFirstTeam1);
            myTeams.Add(myFirstTeam2);



            /*show data of array of teams*/

            Console.WriteLine($"IT Company Report: \nIT company is currently composed of : {myTeams.Count} Project Teams and {myFirstTeam1.MyProgrammers.Count * myTeams.Count} Programmers");
            Console.WriteLine($"This month {totalDaysInCharge(myTeams)} days have been consumed by {myFirstTeam1.MyProgrammers.Count * myTeams.Count} programmers and pending days in charge {pendingDaysIncharge(myTeams)}");
            for (int i = 0; i < myTeams.Count; i++)
            {              
                Console.WriteLine(myTeams[i]);
            }

            //HOW TO LOAD  THE SYSTEM
            Console.WriteLine("*****LOADING INITIAL DATA**********");

            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(@"C:\Users\prokaob\source\repos\KAlmache_Project1\Files\ITCompanyData.txt");
                //Write a line of text
                sw.WriteLine($"IT Company Report: \nIT company is currently composed of : {myTeams.Count} Project Teams and {myFirstTeam1.MyProgrammers.Count * myTeams.Count} Programmers");
                sw.WriteLine($"This month {totalDaysInCharge(myTeams)} days have been consumed by {myFirstTeam1.MyProgrammers.Count * myTeams.Count} programmers and pending days in charge {pendingDaysIncharge(myTeams)}");
                for (int i = 0; i < myTeams.Count; i++)
                {                        
                    sw.WriteLine(myTeams[i]);
                }
     
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            Console.WriteLine("*****LOADING INITIAL DATA INCREACE IN ONE DAY**********");

            //  HOW TO UPDATE THE SYSTEM
            //Increase the duration of all programmers in charge (+1 day)..

            IncreaceOneDay(myTeams);

            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(@"C:\Users\prokaob\source\repos\KAlmache_Project1\Files\ITCompanyData.txt", true);
                //Write a line of text
                sw.WriteLine("*****************INCRESE ONE DAY*****************UPDATING DATA....");
                sw.WriteLine($"IT Company Report: \nIT company is currently composed of : {myTeams.Count} Project Teams and {myFirstTeam1.MyProgrammers.Count * myTeams.Count} Programmers");
                sw.WriteLine($"This month {totalDaysInCharge(myTeams)} days have been consumed by {myFirstTeam1.MyProgrammers.Count * myTeams.Count} programmers and pending days in charge {pendingDaysIncharge(myTeams)}");
                
                for (int i = 0; i < myTeams.Count; i++)
                {
                    
                    sw.WriteLine(myTeams[i]);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }


            Console.WriteLine("*****CREATING JASON FILE**********");
            //Design your own record structure (xml, json, whatever) and save the whole data (all created objects) in a text file.

            FormatJson(myTeams);

        }


        public static int totalDaysInCharge(List<ProjectTeam> myTeams) {
            int totalDays = 0;
            DateTime thisDay = DateTime.Today;
            foreach (var team in myTeams)
            {
                List<Programmer> myListp = team.MyProgrammers;

                foreach (var p in myListp) {
                   totalDays+= p.calculeDurationUntilToday(thisDay);
                
                }
            }
            return totalDays;       
        }

        public static int pendingDaysIncharge(List<ProjectTeam> myTeams)
        {
            int pendingDays = 0;
            DateTime thisDay = DateTime.Today;
            foreach (var team in myTeams)
            {
                List<Programmer> myListp = team.MyProgrammers;
                TimeSpan duration;
                foreach (var p in myListp)
                {
                    duration = p.EndPeriod - thisDay;
                    pendingDays += duration.Days;
                }
            }
            return pendingDays;
        }

        public static void  IncreaceOneDay(List<ProjectTeam> myTeams)
        {

            foreach (var team in myTeams)
            {
                List<Programmer> myListp = team.MyProgrammers;

                foreach (var p in myListp)
                {
                    p.EndPeriod = p.EndPeriod.AddDays(1);

                }
            }
        }
        public static void FormatJson(List<ProjectTeam> myTeams)
        {
            var fileName = @"C:\Users\prokaob\source\repos\KAlmache_Project1\Files\JsonData.json";
            string jsonString = "";
            foreach (var team in myTeams)
            {     
                jsonString += $"\n{JsonSerializer.Serialize(team)}";
                
            }
            File.WriteAllText(fileName, jsonString);

        }
    }
}



