using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MidtermPos
{
    class Check : PaymentMethod
    {
        public Check(double Cost)
        {
            double cost = Cost;
        }
        public override string GetPayment()
        {
            Console.Write("Please enter your check number (Routing:Account:Check):");
            string input = Console.ReadLine();
            double pay = Validator.GetValidDouble("Enter Amount");
            if (Regex.IsMatch(input, @"^((\d{9})\:{0,1}(\d{8})\:{0,1}(\d{5}))$"))
            {
                return $"{input}\t{pay}";
            }
            else
            {
                return GetPayment();
            }


        }
        



    }
}
