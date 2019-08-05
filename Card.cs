using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Environment;

namespace MidtermPos
{
    class Card : PaymentMethod
    {
        public Card(double cost)
        {
            Cost = cost;
        }

        public double Cost { get; set; }

        public override string GetPayment()
        {
            bool valid = true;
            string cardNum = null; ;
            while (valid)
            {
                cardNum = Validator.GetValidString("What is the card number?");
                valid = !Regex.IsMatch(cardNum, @"(([0-9]{4})\-{0,1}([0-9]{4})\-{0,1}([0-9]{4})\-{0,1}([0-9]{4}))");
            }
            while (!valid)
            {
                string expDate = Validator.GetValidString("what is the expiration date?");
                valid = Regex.IsMatch(expDate, @"(([0-1]{1}[0-9]{1})\/([0-9]{2,4}))");
            }
            while (valid)
            {
               string cvv = Validator.GetCVV("What is the card CVV?");
                valid = !Regex.IsMatch(cvv, @"([0-9]{3})");
                if(cvv.Length != 3)
                {
                    valid = true;
                }
            }
            return $"Card ending in {cardNum.Substring(cardNum.Length - 4, 4)} \n Under {UserName} ${Cost}";
        }
    }
}
