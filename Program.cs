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
            while (true)
            {
                List<Items> orderedItems = new List<Items>();
                bool rep = true;
                while (rep)
                {
                    List<Items> itemList = new List<Items>();

                    ReadFile(itemList);
                    TerminalMethods.WelcomeMenu();
                    int functionChoice = Validator.GetIntChoice(1, 3);
                    Console.Clear();

                    switch (functionChoice)
                    {
                        case 1:
                            DisplayMenuItems(itemList);
                            int refValue = Validator.GetIntChoice(1, itemList.Count());
                            Console.WriteLine("How many do you want?(max10)");

                            int quanity = Validator.GetIntChoice(1, 10);
                            for (int i = 0; i <= quanity; i++)
                            {
                                orderedItems.Add(itemList[refValue]);
                            }
                            break;
                        case 2:
                            AddItem();
                            break;
                        case 3:
                            double subTotal = 0;//{ item.Name }{ item.Price };
                            subTotal = Math.Round(subTotal, 2);
                            foreach (Items item in orderedItems)
                            {
                                subTotal += item.Price;
                            }
                            Console.WriteLine("Are you paying with Cash,Card, or Check(1/2/3)");
                            int payChoice = Validator.GetIntChoice(1, 3);
                            string pay;
                            if (payChoice == 1)
                            {
                                PaymentMethod Trans = new Tender(subTotal);
                                pay = Trans.GetPayment();
                            }
                            else
                            if (payChoice == 1)
                            {
                                PaymentMethod Trans = new Card(subTotal);
                                pay = Trans.GetPayment();
                            }
                            else
                            {
                                PaymentMethod Trans = new Check(subTotal);
                                pay = Trans.GetPayment();
                            }
                            TerminalMethods.ReceiptItems(orderedItems);
                            TerminalMethods.CompleteReceipt(orderedItems, pay);
                            rep = false;
                            break;
                    }
                }
                Console.Clear();
                bool end = Validator.GetYN("Would you like to create a new order?");
                if (!end)
                {
                    Validator.EndProgram("Goodbye.");
                }
            }
        }
        public static void ReadFile(List<Items> itemList)
        {
            StreamReader reader = new StreamReader("../../ItemList.txt");
            string line = reader.ReadLine();
            while(line != null && line != "")
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
            int i = 1;
            foreach (Items item in itemList)
            {
                if (item.Catagorie == "Pizza")
                {
                    Console.WriteLine($"{i}: {item.Name}\t\t${item.Price}");
                    Console.WriteLine($"\t\t{item.Discription}");
                    i++;
                }
            }
            Console.WriteLine("Beverage\t------------\t");
            foreach (Items item in itemList)
            {
                if (item.Catagorie == "Beverage")
                {
                    Console.WriteLine($"{i}: {item.Name}\t\t${item.Price}");
                    Console.WriteLine($"\t\t{item.Discription}");
                    i++;
                }
            }
            Console.WriteLine("Side\t------------\t");
            foreach (Items item in itemList)
            {
                if (item.Catagorie == "Side")
                {
                    Console.WriteLine($"{i}: {item.Name}\t\t${item.Price}");
                    Console.WriteLine($"\t\t{item.Discription}");
                    i++;
                }
            }
            
        }
        

    }
}
