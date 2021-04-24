using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class CustomersRate
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Rate { get; set; }
       
        //public CustomersRate(
        //    string firstName,
        //    string lastName,
        //    int rate)
        //{
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //    this.Rate = rate;
        //}
    }
}
