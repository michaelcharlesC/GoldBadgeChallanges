using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_GoldChallangeFive_Repository
{
    public enum CustomerType
    {
        Potential =1,
        Current =2,
        Past =3,
    }
    public class CustomerClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }


        public CustomerClass() { }
        public CustomerClass(string firstName , string lastName,CustomerType type)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }
    }

}
