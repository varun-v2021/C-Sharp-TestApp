using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfosysBusinessLayer;
using System.Collections;

namespace InfosysTestApp
{
    public delegate double DiscountDelegate3(double amount);
    public delegate int CalculatorDelegate(int num1, int num2);
    public delegate void GreetDelegate();
    public delegate int GetProductsDelegate(int categoryId);
    public delegate Int32 BinaryToIntOp(Int32 x, Int32 y);

    class Program
    {
        static void Main(string[] args)
        {          
            /*
            //Object Creation
            Customer custObj = new Customer();

            //Customer Values assigned
            custObj.customerName = "Fred";
            custObj.customerAddress = "Las Vegas";
            custObj.customerContact = "+1-231-34452";

            //Printing CustomerDetails
            custObj.MyProfile();

            Product prodObj1 = new Product("P101", "Table", 1034.00, 10);
            Product prodObj2 = new Product("P102", "Chair", 1134.00, 20);
            Product prodObj3 = new Product("P103", "Books", 534.00, 30);

            Product[] productList = new Product[5];
            productList[0] = prodObj1;
            productList[1] = prodObj2;
            productList[2] = prodObj3;
            try
            {
                for (int i = 0; i < productList.Length; i++)
                {
                    Console.WriteLine("ID = " + productList[i].productId +
                                                "\tName = " + productList[i].productName +
                                                "\tPrice = " + productList[i].price +
                                                "\tQuantityAvailable = " + productList[i].quantityAvailable);
                }
            }
            catch(Exception ex) {
                Console.WriteLine("There is some error in program");
            }


            try
            {
                Console.WriteLine("Enter the Age");
                short age = Convert.ToInt16(Console.ReadLine());
                if (age > 0)
                    Console.WriteLine("Customer Age = " + age);
                else
                {
                    // When age is invalid, user defined exception object is thrown
                    InvalidAgeException expObj = new InvalidAgeException("Age value should not be a negative number");
                    throw expObj;
                }
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Some other error occured in the program.");
            }


            finally
            {
                Console.WriteLine("End of product details\n");
            }

            */

            ContactDetails<long> mobileContacts = new ContactDetails<long>(3);
            ContactDetails<string> emailContacts = new ContactDetails<string>(3);

            // Code to add 3 mobile numbers

            mobileContacts.AddContact(8902312345);
            mobileContacts.AddContact(9321409812);
            mobileContacts.AddContact(9243209814);

            // Code to add 3 email id's

            emailContacts.AddContact("Albert@gmail.com");
            emailContacts.AddContact("William@gmail.com");
            emailContacts.AddContact("Jenny@gmail.com");

            Random r = new Random();
            int luckyNumber = r.Next(0, 3);

            //Below two lines of code has compilation errors - type casting needs to be done
            long mobileNumber = mobileContacts.GetContact(luckyNumber);
            string emailId = emailContacts.GetContact(luckyNumber);

            Console.WriteLine("Mobile Number : " + mobileNumber);
            Console.WriteLine("Email ID : " + emailId);

            // generics shows compile time error - to ensure type safety
            //mobileNumber = (string)mobileContacts.GetContact(luckyNumber);
            //Console.WriteLine("MobileNumber: "+mobileNumber);

            Program prg = new Program();
            prg.OverloadedMethodsFunc();

            prg.listFunctionDemo();

            prg.sortedListObjectsDemo();

            prg.dictionaryStructureDemo();

            //Delegates example
            NewCustomer custObj1 = new NewCustomer
            {
                CustomerId = 1001,
                CustomerName = "John",
                EmailId = "John@gmail.com",
                MobileNumber = 9988776655
            };

            //Without Delegate
            /*
            custObj1.AlertPreference = "SMS";
            Account accountObj1 = new Account(custObj1);
            accountObj1.DebitTransaction(2500);

            custObj1.AlertPreference = "Email";
            Account accountObj2 = new Account(custObj1);
            accountObj2.DebitTransaction(2500);
            */

            //With Delegate
            custObj1.AlertPreference = Alerts.SendSMS;


            /*
            Delegate is a class which holds the reference to a method. These references can be changed at run-time
            The delegate signature should match the signature of the method(s) that would be referred by the delegate
            Delegates are used to pass methods as arguments to other methods
            To work with delegates, the developer should follow the below steps:
            Declare a delegate
            Instantiate the delegate
            Invoke the delegate
             */

            //Delegate Example
            ShoppingCart shopCart = new ShoppingCart();
            shopCart.CartAmount = 5000.0;
            shopCart.ProcessCart();

            //+=' operator adds a method to the end of the invocation list.
            //'-=' operator removes a method from the end of the invocation list.
            //For delegate methods which have return type as void
            DiscountDelegate1 discountDelRef = Sale.FestivalDiscount;
            discountDelRef += Sale.RegularDiscount;
            discountDelRef -= Sale.FestivalDiscount;
            discountDelRef();

            //For delegate methods which have return type as non - void
            DiscountDelegate2 discountDelRef1 = Sale.FestivalDiscount;
            discountDelRef1 += Sale.RegularDiscount;
            //Observe that, the output returned by the last method in the delegate chain – 
            //RegularDiscount() has overwritten the output returned by FestivalDiscount().
            Console.WriteLine("Discount amount = " + discountDelRef1(1000));

            /*
             * observe the output that, we are able to see the output of both the methods using GetInvocationList().
             * A reference type variable that holds the reference to a method, the reference can be changed at run time
                Can refer to those methods whose signature matches with the delegate signature
             */
            DiscountDelegate discountDelRef2 = Sale.FestivalDiscount;
            discountDelRef2 += Sale.RegularDiscount;
            foreach (DiscountDelegate item in discountDelRef2.GetInvocationList())
            {
                Console.WriteLine("Discount amount for {0} is {1} ", item.Method.Name, item(1000));
            }

            //anonymous method using delegate keyword
            //DiscountDelegate3 declared at the top in namespace
            DiscountDelegate3 disDelObj3 = delegate (double amount)
            {
                return amount - amount * (50 / 100.0);
            };
            double result = disDelObj3.Invoke(1000);
            Console.WriteLine("Calling anonymous method using delegate keyword - result: "+result);    

            //Lambda Expressions
            CalculatorDelegate addObj = (x, y) => x + y;
            GreetDelegate displayObj = () => Console.WriteLine("Hello World");
            Console.Write(addObj(4, 5));
            displayObj.Invoke();

            //Passing parameters via Invoke API call as well
            CalculatorDelegate subObj = (x, y) => x + y;
            subObj.Invoke(100,60);

            //Anonymous method using Lambda expression
            DiscountDelegate3 disDelObj4 = (amount) =>
            {
                return amount - amount * (50 / 100.0);
            };
            Console.WriteLine("Amount after 50% discount = " + disDelObj4(5000));

            //Anonymous method using Lambda expression with no curly braces
            DiscountDelegate3 disDelObj5 = (amount) => amount - amount * (50 / 100.0);
            
            Console.WriteLine("Amount after 50% discount = " + disDelObj5(5000));

            //Anonymous method using Lambda expression with no curly braces
            DiscountDelegate3 disDelObj6 = (n) => n - n * (50 / 100.0);

            Console.WriteLine("Amount after 50% discount = " + disDelObj6(10000));

            int[] productList = new int[4];
            productList[0] = 1001;
            productList[1] = 1002;
            productList[2] = 1003;
            productList[3] = 1004;

            GetProductsDelegate getProductsCount = categoryId1 =>
            {
                int count = 0;
                foreach (var item in productList) {
                    if(categoryId1 == item)
                    count++;
                }
                return count;
            };

            int categoryId = 1003;
            int noOfProducts = getProductsCount(categoryId);
            Console.WriteLine("Number of products available in categoryId " + categoryId + " is " + noOfProducts);

            int catId = 1002;
            GetProductsDelegate getProductsCount1 = categoryId1 => FetchProductsCount(categoryId1);
            Console.WriteLine("Number of products available in categoryId " + catId + " is " + getProductsCount1(catId));


            int[] source = new[] { 13, 28, 4, 16, 11, 27, 9, 42, 24, 8 };

            foreach (int i in source.Where(
                x =>
                {
                    if ((x / 4) <= 3)
                        return true;
                    else if ((x / 4) >= 7)
                        return true;
                    return false;
                }))
                Console.WriteLine(i);

            //In-built delegates which don't require user defined delegate required
            /*
             Takes 0 to 16 input parameters of different types and 1 output parameter for storing result
             By default, the last parameter is always the out parameter type in the signature of the delegate
             Rest of the parameters indicate the input parameter types
             */
            Func<DateTime> dateDel = () => DateTime.Now;
            Console.WriteLine(dateDel());

            Action<string> greetDel = name => Console.WriteLine("Hello "+name);
            greetDel("John");

            //Void return type delegate
            Action helloDel = () => Console.WriteLine("Hello World...");
            helloDel();

            //categoryId4 is a declaration/local variable for lambda expression
            Action<int> getTotalProductsCount = (categoryId4) =>
            {
                int count = 0;
                foreach (var item in productList)
                {
                    if (categoryId4 == item)
                        count++;
                }
                Console.WriteLine("\nNumber of products available in categoryId " + categoryId4 + " = " + count);
            };

            getTotalProductsCount(categoryId);
        }

        public static int FetchProductsCount(int categoryId)
        {
            int[] productList = new int[4];
            productList[0] = 1001;
            productList[1] = 1002;
            productList[2] = 1003;
            productList[3] = 1004;
            int count = 0;
            foreach (var item in productList)
            {
                if (categoryId == item)
                    count++;
            }
            return count;
        }

        public void OverloadedMethodsFunc() {
            // Code to add 3 mobile numbers
            long[] mobileContacts = new long[3];
            mobileContacts[0] = 8902312345;
            mobileContacts[1] = 9321409812;
            mobileContacts[2] = 9243209814;

            // Code to add 3 email id's
            string[] emailContacts = new string[3];
            emailContacts[0] = "Albert@gmail.com";
            emailContacts[1] = "William@gmail.com";
            emailContacts[2] = "Jenny@gmail.com";


            SearchContacts search = new SearchContacts();

            //string[] and string data used as contactList and contactToSearch 
            string result = search.SendMessage(emailContacts, "Albert@gmail.com", "e-Greetings sent to");
            Console.WriteLine(result);

            //long[] and long data used as contactList and contactToSearch 
            result = search.SendMessage(mobileContacts, 8902312345, "SMS send to");
            Console.WriteLine(result);

            //Lambda expression example
            //delegate is a name of a variable that holds reference to a method or a lambda
            //lambda is a method which has no permanent name
            BinaryToIntOp sumofSquares = (a, b) => a * a + b * b;
            Action<int> squareValue = (x) => {
                Console.WriteLine(x * x);
            } ;
            Console.WriteLine("Square value using LAMBDA EXPRESSION: ");
            squareValue(10);

        }

        public void listFunctionDemo() {
            List<string> lstEmailIds = new List<string>();
            List<long> lstPhoneNumbers = new List<long>();

            //code to add two email id's to the list
            lstEmailIds.Add("William@gmail.com");
            lstEmailIds.Add("Albert@gmail.com");

            //code to add two phone numbers to the list
            lstPhoneNumbers.Add(9845030735);
            lstPhoneNumbers.Add(9676091239);

            //Retrieval of email id's from the list using index numbers
            for (int index = 0; index < lstEmailIds.Count; index++)
            {
                Console.WriteLine(lstEmailIds[index]);
            }
            Console.WriteLine();

            //Retrieval of mobile numbers from the list using index numbers
            for (int index = 0; index < lstPhoneNumbers.Count; index++)
            {
                Console.WriteLine(lstPhoneNumbers[index]);
            }

            //Indexes adjust accordingly after the removal of the items
            lstEmailIds.Remove("William@gmail.com");

            //Observe the index number passed as parameter
            lstPhoneNumbers.RemoveAt(0);
            Console.WriteLine();

            Console.WriteLine("Number of elements after remove operation (Email ID): " + lstEmailIds.Count);
            for (int index = 0; index < lstEmailIds.Count; index++)
            {
                Console.WriteLine(lstEmailIds[index]);
            }

            Console.WriteLine();

            Console.WriteLine("Number of elements after remove operation (Phone Number): " + lstPhoneNumbers.Count);
            for (int index = 0; index < lstPhoneNumbers.Count; index++)
            {
                Console.WriteLine(lstPhoneNumbers[index]);
            }

            string[] lstMoreEmailIds = new string[]
            {
                "Jane@gmail.com",
                "Cheryl@gmail.com",
                "Joseph@gmail.com"
            };

            //AddRange() accepts another list as parameter
            lstEmailIds.AddRange(lstMoreEmailIds);
            for (int index = 0; index < lstEmailIds.Count; index++)
            {
                Console.WriteLine(lstEmailIds[index]);
            }

            Console.WriteLine();
            //Starting index number and count of elements to remove are passed as parameters
            lstEmailIds.RemoveRange(0, 2);
            for (int index = 0; index < lstEmailIds.Count; index++)
            {
                Console.WriteLine(lstEmailIds[index]);
            }

            Console.WriteLine();
            lstEmailIds.Add("Bruce@gmail.com");
            lstEmailIds.Add("Sharon@gmail.com");
            lstEmailIds.Add("Bruce@gmail.com"); // Same email-id added for the second time
            for (int index = 0; index < lstEmailIds.Count; index++)
            {
                Console.WriteLine(lstEmailIds[index]);
            }

            //Compilation error when null value is added to the list
            //lstEmailIds.Add(null);
            //lstPhoneNumbers.Add(null);

            //Uncomment as the code results in runtime exception
            /*
            ArrayList list = new ArrayList();
            list.Add(5);
            list.Add(9);
            list.Add(5.10);

            int result = 0;
            foreach (int item in list)
            {
                result += item;
            }
            Console.WriteLine(result);
            */


            /*
            ArrayList empList = new ArrayList();

            empList.Add("Emily");
            empList.Add(101);
            empList.Add("James");
            empList.Add(102);

            empList.RemoveAt(2);
            empList.RemoveAt(3);

            foreach (var item in empList)
            {
                Console.WriteLine(item);
            }*/

            List<bool> list = new List<bool>();
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            list.Add(true);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            list.RemoveAt(0);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
        }

        public void sortedListObjectsDemo() {

            Product prodObj1 = new Product("P101", "Table", 1034.00, 10);
            Product prodObj2 = new Product("P102", "Chair", 1134.00, 20);
            Product prodObj3 = new Product("P103", "Books", 534.00, 30);

            SortedList<string, Product> slProductDetails = new SortedList<string, Product>();
            slProductDetails.Add("P101", prodObj1);
            slProductDetails.Add("P102", prodObj2);
            slProductDetails.Add("P103", prodObj3);

            Console.WriteLine("Key\tValue");
            Console.WriteLine("-------------------");
            foreach (KeyValuePair<string, Product> product in slProductDetails)
            {
                // Key and Value properties are used to access a single key and Value
                Console.WriteLine("{0}\t{1}", product.Key, product.Value.productName);
            }

            Product prodObj = slProductDetails["P103"];
            Console.WriteLine("Product Name : " + prodObj.productName);
            Console.WriteLine();
        }

        public void dictionaryStructureDemo()
        {
            /*

            SortedList needs sorting and indexing on every addition of a new element.This can degrade the performance of the application.
            To overcome this, Dictionary<TKey, TValue> can be used. Can be used in situations where the data items need not be sorted
            It belongs to System.Collections.Generic namespace Elements are of type KeyValuePair<TKey, TValue> and can be accessed based on only the key and not on index 
            */
            Product prodObj1 = new Product("P101", "Table", 1034.00, 10);
            Product prodObj2 = new Product("P102", "Chair", 1134.00, 20);
            Product prodObj3 = new Product("P103", "Books", 534.00, 30);

            Dictionary<String, Product> dictProductDetails = new Dictionary<string, Product>();

            dictProductDetails.Add("P101", prodObj1);
            dictProductDetails.Add("P102", prodObj2);
            dictProductDetails.Add("P103", prodObj3);

            Console.WriteLine("Key\tValue");
            Console.WriteLine("-------------------");
            foreach (KeyValuePair<string, Product> product in dictProductDetails)
            {
                // Key and Value properties are used to access a single key and Value similar to SortedList
                Console.WriteLine("{0}\t{1}", product.Key, product.Value.productName);
            }


            /*What do you observe when an index number is used with Keys and Values properties?

            It results in compilation error.

            Keys and Values properties of Dictionary cannot be used with index numbers unlike SortedList.*/

            //for (int index = 0; index < dictProductDetails.Count; index++)
            //{
            // Keys and Values properties cannot be used with index numbers to retrieve a single key and value
            //   Console.WriteLine("{0}\t{1}", dictProductDetails.Keys[index], dictProductDetails.Values[index].productName);
            //}
            Product prodObj = dictProductDetails["P102"];
            Console.WriteLine("Product Name : " + prodObj.productName);
            Console.WriteLine();
        }
    }
}


