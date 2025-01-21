using System;

namespace CalcOfProductPrice
{
    class Program
    {
       

        static void Main(string[] args)
        {

            Console.WriteLine("Enter the total amount of money you have (in pounds): ");
            decimal amountInPounds = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter the price of the product (in pounds): ");
            decimal productPriceInPounds = Convert.ToDecimal(Console.ReadLine());
            CalculateChange calculateChange = new CalculateChange();
            List<string> res = calculateChange.CalculateChangeInPurchase(amountInPounds, productPriceInPounds);
            foreach(var kv in res)
            {
                Console.WriteLine(kv);
            }
        }
    }
}
