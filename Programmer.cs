using System;

namespace KAlmache_Project1
{
    public class Programmer : IEmployee
    {
        //atributes, principles encapsulation
        private string _fistName;
        private string _lastName;
        private DateTime _startPeriod;
        private DateTime _endPeriod;
        private string _technology;
        private int _durationUntilToday;
        private double _salary;

        string IEmployee.FirsName { get => _fistName; set => _fistName=value; }
        string IEmployee.LastName { get => _lastName; set => _lastName=value; }
        public DateTime StartPeriod { get => _startPeriod; set => _startPeriod = value; }
        public DateTime EndPeriod { get => _endPeriod; set => _endPeriod = value; }
        public string Technology { get => _technology; set => _technology = value; }
        public int DurationUntilToday { get => _durationUntilToday; set => _durationUntilToday = value; }
        public double Salary { get => _salary; set => _salary = value; }




        //Overload
        public Programmer() { }
        //Overload
        public Programmer(string firstName, string lastName, string tecnology, DateTime startPeriod, DateTime endPeriod)
        {
            this._fistName = firstName;
            this._lastName= lastName;
            this._technology = tecnology;
            this._startPeriod = startPeriod;
            this._endPeriod = endPeriod;

        }
        public Programmer(string firstName, string lastName, string tecnology, DateTime startPeriod, DateTime endPeriod, int durationToday, double salary)
        {
            this._fistName = firstName;
            this._lastName = lastName;
            this._technology = tecnology;
            this._startPeriod = startPeriod;
            this._endPeriod = endPeriod;
            this.DurationUntilToday = durationToday;
            this.Salary = salary;

        }


        public int calculeDuration()
        {
            TimeSpan duration;
            duration = EndPeriod - StartPeriod;
            int dias = duration.Days;
            return dias;
        }

        public int calculeDurationUntilToday(DateTime todaysDate)
        {
            TimeSpan duration;
            DateTime firstDayMonth = new DateTime(todaysDate.Year, todaysDate.Month, 1);
            int dias;

            if (_endPeriod < todaysDate && _endPeriod >= firstDayMonth)
            {
                duration = _endPeriod - firstDayMonth;
                dias = duration.Days;
            }
            else if (_endPeriod < firstDayMonth)
            {
                dias = 0;
            }
            else {
                duration = todaysDate - firstDayMonth;
                dias = duration.Days;
            }
            return dias;
        }
        public override string ToString()
        {
            return $"{_fistName} {_lastName} is in charge of {_technology} from {_startPeriod} to {_endPeriod}, total duration {calculeDuration()}, this month {DurationUntilToday} days (Total cost = {Salary}) ";
        
        }

        //interface method for calculateSalary
        public double calculeSalary(String typePayment, int dias)
        {
            double salaryrateday = 41.25;
            double totalSalary = 0;


            if (typePayment.Equals("Full"))
            {
                totalSalary = salaryrateday * dias * (100 / 100);

            }
            else if (typePayment.Equals("Half"))
            {
                totalSalary = salaryrateday * dias * 0.5;

            }
            else {
                Console.WriteLine("Choose Full or Half");
            
            }

            return totalSalary;

        }

    }
}