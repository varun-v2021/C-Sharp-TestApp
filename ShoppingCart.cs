using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfosysTestApp
{
    public delegate double DiscountDelegate(double amount);

    class ShoppingCart
    {
        public double CartAmount { get; set; }
        private static double FestivalDiscount(double amount)
        {
            return ((amount * 90) / 100);
        }

        public void ProcessCart()
        {
            DiscountDelegate typeOfDiscount = FestivalDiscount;
            Console.WriteLine("Original Bill Amount = {0}", CartAmount);
            CartAmount = typeOfDiscount(CartAmount);
            Console.WriteLine("Discounted Bill Amount = {0}", CartAmount);
        }
    }
}
