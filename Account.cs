using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfosysBusinessLayer
{
    class Account
    {
        double amount;
        NewCustomer cust;

        public Account(NewCustomer cust)
        {
            this.cust = cust;
        }

        public void DebitTransaction(double amount)
        {
            this.amount = amount;

            /*if (cust.AlertPreference == "Email")
            {
                Alerts.SendEmail(cust.CustomerName, amount);
            }
            if (cust.AlertPreference == "SMS")
            {
                Alerts.SendSMS(cust.CustomerName, amount);
            }
            if (cust.AlertPreference == "WhatsApp")
            {
                Alerts.SendWhatApp(cust.CustomerName, amount);
            }*/
            cust.AlertPreference(cust.CustomerName, amount);
        }       
    }
}
