using System;

namespace KAlmache_Project1
{
    public abstract class Employee 
    {
        //We create a abstract class that implements Interface
        //declare atributes
        private string firstName;
        private string lastName;
        private int age;
        private string city;

        //Constructor with parameter
        public Employee(string firstName, string lastName, int age, string city)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.city = city;
        }
        //Empty Constructor
        public Employee() { }

        //encapsulation principles, get and set
        
        public override string? ToString()
        {
            return $"Fist name: {firstName}, Last Name: {lastName}, Age: {age}, City: {city}";
        }


    }
}