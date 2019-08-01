using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPos
{
    class TerminalMethods
    {
        public static void WelcomeMenu()
        {
            Console.WriteLine("                         vvvvvvv                       ");
            Console.WriteLine("       O~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~O      ");
            Console.WriteLine("       >      Welcome to Deno's Pizzeria!       <      ");
            Console.WriteLine("       >              Gran Giorno!              <      ");
            Console.WriteLine("       >            555 - 888 - 1000            <      ");
            Console.WriteLine("       O~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~O      ");
            Console.WriteLine("                         ^^^^^^^                       ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("           ==================================          ");
            Console.WriteLine("                    1. Add To Order                    ");
            Console.WriteLine("                    2. Add New Item To Menu            ");
            Console.WriteLine("                    3. Leave The Pizzeria              ");
            Console.WriteLine("           ==================================          ");
            Console.WriteLine("                 What would you like to do?            ");

        }

        public static void ReceiptItems(List<Items> orderedItems)
        {
            foreach (Items item in orderedItems)
            {
                Console.WriteLine($"{item.Name} {item.Price,-0}");
            }
        }

        public static void PriceCalculator(List<Items> orderedItems,string pay)
        {
            double subTotal = 0;//{ item.Name }{ item.Price };
            subTotal = Math.Round(subTotal, 2);
            foreach (Items item in orderedItems)
            {
                subTotal += item.Price;
            }

            double salesTax = subTotal * .06;
            salesTax = Math.Round(salesTax, 2);

            double totalAmount = subTotal + salesTax;
            totalAmount = Math.Round(totalAmount, 2);
            Console.WriteLine("   ===============================================     ");
            Console.WriteLine($"Subtotal        ..........            ${subTotal}     ");
            Console.WriteLine();
            Console.WriteLine($"Sales Tax (6%)  ..........            ${salesTax}     ");
            Console.WriteLine();
            Console.WriteLine($"Total           ..........            ${totalAmount}  ");
            Console.WriteLine();
            Console.WriteLine($"{pay,-0}");
            Console.WriteLine("   ===============================================     ");
        }

        public static void CompleteReceipt(List<Items> order, string pay)
        {
            ReceiptItems(order);
            Console.WriteLine();
            PriceCalculator(order, pay);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("       S~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~S      ");
            Console.WriteLine("       S  Thanks for visiting Deno's Pizzeria!  S      ");
            Console.WriteLine("       S              Gran Giorno!              S      ");
            Console.WriteLine("       S            555 - 888 - 1000            S      ");
            Console.WriteLine("       S~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~S      ");


        }
    }
}
