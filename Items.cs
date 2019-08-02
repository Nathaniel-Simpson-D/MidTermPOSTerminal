using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPos
{
    public class Items
    {
        public Items(string name, string catagorie, string discription, double price)
        {
            Name = name;
            Category = catagorie;
            Discription = discription;
            Price = price;
        }

        public Items()
        {
        }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Discription { get; set; }
        public double Price { get; set; }

    }
}
