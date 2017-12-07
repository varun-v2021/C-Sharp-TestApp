using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfosysTestApp
{
    class SearchContacts
    {

        public string SendMessage<T>(T[] contactList, T contactToSearch, string message)
        {
            string resultMessage = "Could not find the contact";
            T temp;
            for (int i = 0; i < contactList.Length; i++)
            {
                temp = contactList[i];
                if (temp.ToString().Equals(contactToSearch.ToString()))
                {
                    resultMessage = message + " " + temp.ToString();
                    break;
                }
            }
            return resultMessage;
        }

        /*public string SendMessage(long[] contactList, long contactToSearch, string message)
        {
            string resultMessage = "Could not find the contact";
            long temp;
            for (int i = 0; i < contactList.Length; i++)
            {
                temp = contactList[i];
                if (temp.ToString().Equals(contactToSearch.ToString()))
                {
                    resultMessage = message + " " + temp.ToString();
                    break;
                }
            }
            return resultMessage;
        }
        public string SendMessage(string[] contactList, string contactToSearch, string message)
        {
            string resultMessage = "Could not find the contact";
            string temp;
            for (int i = 0; i < contactList.Length; i++)
            {
                temp = contactList[i];
                if (temp.ToString().Equals(contactToSearch.ToString()))
                {
                    resultMessage = message + " " + temp.ToString();
                    break;
                }
            }
            return resultMessage;
        } */
    }
}
