using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfosysTestApp
{
    public delegate void DiscountDelegate1();

    public delegate double DiscountDelegate2(double amount);

    class Sale
    {
        public static void FestivalDiscount()
        {
            Console.WriteLine("Festival discount applied on the bill.");
        }
        public static void RegularDiscount()
        {
            Console.WriteLine("Regular discount applied on the bill.");
        }
        public static double FestivalDiscount(double amount)
        {
            return amount - amount * (50 / 100.0);
        }
        public static double RegularDiscount(double amount)
        {
            return amount - amount * (10 / 100.0);
        }
    }
}
