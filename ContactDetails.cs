using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfosysTestApp
{
    public class ContactDetails<T>
    {
        // object array to hold either long(phone Numbers) or string(email ids)
        T[] contacts;
        int indexNumber;
        int size;

        public ContactDetails(int size)
        {
            contacts = new T[size];
            indexNumber = 0;
            this.size = size;
        }

        public void AddContact(T contact)
        {
            if (indexNumber < size)
            {
                contacts[indexNumber++] = contact;
            }
        }
        public T GetContact(int number)
        {
            return contacts[number];
        }
    }
}
