using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfosysBusinessLayer
{
    class NewCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public enum Gender { Male, Female, Others }
        public string Password { get; set; }
        public long MobileNumber { get; set; }
        public SendAlerts AlertPreference { get; set; }
    }
}
