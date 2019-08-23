using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfThreeView.Classes
{
    class Validations 
    {
        private string firstName, lastName, type, email;
        private int age, phoneNo;
        private char gender;

        public Validations(string firstName, string lastName, string type, string email, int age, int phoneNo, char gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.type = type;
            this.email = email;
            this.age = age;
            this.phoneNo = phoneNo;
            this.gender = gender;
        }

       
    }
}
