using System;

namespace KAlmache_Project1 {
public interface IEmployee
{
        /*Employee is not really a class, 
         * is an interface with only basic methods.*/
        //
        string FirsName { get; set; }   
        string LastName { get; set; }


        // method having only declaration 
        // not definition
        public double calculeSalary(String typePayment, int dias);

    }
}
