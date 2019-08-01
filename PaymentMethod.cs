using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPos
{
    public abstract class PaymentMethod
    {
        public string Type { get; set; }

        public abstract string GetPayment();
    }
}
