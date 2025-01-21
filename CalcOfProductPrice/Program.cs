using System;

namespace CalcOfProductPrice
{
    class Program
    {
        //denominations of UK in pence 
        static readonly int[] denominations = new int[] { 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 }; 

        static void Main(string[] args)
        {

            Console.WriteLine("Enter the total amount of money you have (in pounds): ");
            decimal amountInPounds = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter the price of the product (in pounds): ");
            decimal productPriceInPounds = Convert.ToDecimal(Console.ReadLine());

            // Converting both input amounts to pence (100 pence = 1 pound)
            int totalAmountInPence = (int)(amountInPounds * 100);
            int productPriceInPence = (int)(productPriceInPounds * 100);

            // Calculating the change to be returned
            int changeInPence = totalAmountInPence - productPriceInPence;

            // If there is no change to be returned then printing message and returning
            if (changeInPence < 0)
            {
                Console.WriteLine("Insufficient funds!");
                return;
            }

            // Display the change
            Console.WriteLine("\nChange to be returned: £{0}.{1:D2}", changeInPence / 100, changeInPence % 100);
            Console.WriteLine("Breakdown by denominations:");

            foreach (var denomination in denominations)
            {
                int count = changeInPence / denomination;
                if (count > 0)
                {
                    Console.WriteLine("{0} x £{1}.{2:D2}", count, denomination / 100, denomination % 100);
                }
                changeInPence %= denomination;
            }
        }
    }
}
