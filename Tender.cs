using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPos
{
    public class Tender : PaymentMethod
    {
        public double Cost { get; set; }
        public Tender(double cost)
        {
            this.Type = "Tender";
            this.Cost = cost;
        }
        public override string GetPayment()
        {
            while (true)
            {
                double input = Validator.GetValidDouble("what is the Tender amount paid?");
                input = Math.Round(input, 2);
                if (input / Cost == 1)
                {
                    return $"Tender ${input} : Change $0.00";
                }
                else if (input /Cost > 1)
                {
                    Console.WriteLine($"Change Due: ${input - Cost}");
                    return $"Tender ${input} : Change ${input - Cost}";
                }
                else
                {
                    Console.WriteLine("Not a valid Amount");
                }
            }

        }
    }
}
