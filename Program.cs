using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPos
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        public static void ReadFile(List<Items> itemList)
        {
            StreamReader reader = new StreamReader("../../../ItemList.txt");
            string line = reader.ReadLine();
            while(line != null)
            {
                string[] items = line.Split('|');
                itemList.Add(new Items(items[0], items[1], items[2], double.Parse(items[3])));
                line = reader.ReadLine();

            }
            reader.Close();
        }
        public static void DisplayMenuItems(List<Items> itemList)
        {
            Console.WriteLine("Menu\n\t------------\t");
            Console.WriteLine("Pizza\t------------\t");
            foreach (Items item in itemList)
            {
                if (item.Catagorie == "Pizza")
                {
                    Console.WriteLine($"{item.Name}\t{item.Price}");
                    Console.WriteLine($"\t{item.Discription}");
                }
            }
            Console.WriteLine("Beverage\t------------\t");
            foreach (Items item in itemList)
            {
                if (item.Catagorie == "Beverage")
                {
                    Console.WriteLine($"{item.Name}\t{item.Price}");
                    Console.WriteLine($"\t{item.Discription}");
                }
            }
            Console.WriteLine("Side\t------------\t");
            foreach (Items item in itemList)
            {
                if (item.Catagorie == "Side")
                {
                    Console.WriteLine($"{item.Name}\t{item.Price}");
                    Console.WriteLine($"\t{item.Discription}");
                }
            }
        }
        

    }
}
