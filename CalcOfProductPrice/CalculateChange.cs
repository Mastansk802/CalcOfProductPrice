using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcOfProductPrice
{
    public class CalculateChange
    {

        //denominations of UK in pence 
        static readonly int[] denominations = new int[] { 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };

        public List<string> CalculateChangeInPurchase(decimal totalAmount, decimal purchasePrice)
        {
            // Convert both amounts to pence for easy calculation
            int totalAmountInPence = (int)(totalAmount * 100);
            int purchasePriceInPence = (int)(purchasePrice * 100);

            int changeInPence = totalAmountInPence - purchasePriceInPence;

            if (changeInPence < 0)
                throw new ArgumentException("Total amount must be greater than or equal to purchase price.");

            var li = new List<string>();
            li.Add(string.Format("\nChange to be returned: £{0}.{1:D2}", changeInPence / 100, changeInPence % 100));
            
           // Console.WriteLine("Breakdown by denominations:");

            foreach (var denomination in denominations)
            {
                int count = changeInPence / denomination;
                if (count > 0)
                {
                    li.Add(string.Format("{0} x £{1}.{2:D2}", count, denomination / 100, denomination % 100));
                }
                changeInPence %= denomination;
            }

            return li;
        }
    }
}
