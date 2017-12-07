using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfosysBusinessLayer
{
    public delegate void SendAlerts(string name, double amount);

    public class Alerts
    {
        public static void SendSMS(string name, double amount)
        {
            Console.WriteLine("SMS Alert: Dear {0}, {1} INR has been debited from your account", name, amount);
        }
        public static void SendEmail(string name, double amount)
        {
            Console.WriteLine("Email Alert: Dear {0}, {1} INR has been debited from your account", name, amount);
        }
        public static void SendWhatApp(string name, double amount)
        {
            Console.WriteLine("WhatsApp Alert: Dear {0}, {1} INR has been debited from your account", name, amount);
        }        
    }
}
