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
                bool go = true;
                while (go)
                {
                    List<Items> orderedItems = new List<Items>();
                    bool rep = true;
                    while (rep)
                    {
                        List<Items> itemList = new List<Items>();

                        ReadFile(itemList);
                        Console.Clear();
                        TerminalMethods.WelcomeMenu();
                        int functionChoice = Validator.GetIntChoice(1, 3) + 1;
                        Console.Clear();

                        switch (functionChoice)
                        {
                            case 1:
                                DisplayMenuItems(itemList);
                                Console.WriteLine("\nPlease select menu item by reference number.");
                                int refValue = Validator.GetIntChoice(1, itemList.Count());
                                Console.WriteLine("How many do you want? (Maximum of 10 per order.)");

                                int quanity = Validator.GetIntChoice(1, 10);
                                for (int i = 0; i <= quanity; i++)
                                {
                                    orderedItems.Add(itemList[refValue]);
                                }
                                break;

                            case 2:
                                WriteFile();
                                break;

                            case 3:
                                double subTotal = 0;//{ item.Name }{ item.Price };
                                subTotal = Math.Round(subTotal, 2);
                                foreach (Items item in orderedItems)
                                {
                                    subTotal += item.Price;

                                }
                                if (subTotal == 0)
                                {
                                    Validator.EndProgram("Goodbye.");
                                    break;
                                }
                                else
                                {
                                    double salesTax = subTotal * .06;
                                    salesTax = Math.Round(salesTax, 2);

                                    double totalAmount = subTotal + salesTax;
                                    totalAmount = Math.Round(totalAmount, 2);

                                    Console.WriteLine($"The total is ${totalAmount}");
                                    Console.WriteLine("Are you paying with Cash, Card, or Check? (1/2/3)");

                                    int payChoice = Validator.GetIntChoice(1, 3) + 1;
                                    string pay;
                                    if (payChoice == 1)
                                    {
                                        PaymentMethod Trans = new Tender(totalAmount);
                                        pay = Trans.GetPayment();
                                    }
                                    else
                                    if (payChoice == 2)
                                    {
                                        PaymentMethod Trans = new Card(totalAmount);
                                        pay = Trans.GetPayment();
                                    }
                                    else
                                    {
                                        PaymentMethod Trans = new Check(totalAmount);
                                        pay = Trans.GetPayment();
                                    }

                                    Console.Clear();
                                    TerminalMethods.CompleteReceipt(orderedItems, pay);
                                    Console.WriteLine("Please enter Enter to exit the menu.");

                                    while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                                    {
                                    }
                                    rep = false;
                                    break;
                                }
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
                List<string[]> sortList = new List<string[]>();
                string line = reader.ReadLine();
                while (line != null && line != "")
                {
                    string[] items = line.Split('|');
                    sortList.Add(items);
                    line = reader.ReadLine();
                }
                foreach (string[] item in sortList)
                {
                    if (item[1] == "Pizza")
                    {
                        itemList.Add(new Items(item[0], item[1], item[2], double.Parse(item[3])));
                    }
                }
                foreach (string[] item in sortList)
                {
                    if (item[1] == "Side")
                    {
                        itemList.Add(new Items(item[0], item[1], item[2], double.Parse(item[3])));
                    }
                }
                foreach (string[] item in sortList)
                {
                    if (item[1] == "Beverage")
                    {
                        itemList.Add(new Items(item[0], item[1], item[2], double.Parse(item[3])));
                    }
                }

                reader.Close();
            }

            public static void WriteFile()
            {
                using (StreamWriter writer = File.AppendText("../../ItemList.txt"))
                {

                    string addItem = Validator.GetValidName("What is the name of the item would you like to add? ");

                    string addCategory = Validator.ValidateCategory("What category is this item in? (Pizza, Side, Beverage) ");

                    Console.WriteLine("What is the description of this item?");
                    string addDescription = Console.ReadLine();
                    double price = Validator.TryParseDouble("What is the price of this item? ");

                    Console.WriteLine();
                    writer.WriteLine(addItem + "|" + addCategory + "|" + addDescription + "|" + price);
                    writer.Close();

                }

            }
            public static void DisplayMenuItems(List<Items> itemList)
            {
                Console.WriteLine("     ===============  MENU  ===============     ");
                Console.WriteLine();
                Console.WriteLine("          ========== Pizza =========      ");
                Console.WriteLine();

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
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("          ========== Side =========      ");
                Console.WriteLine();
                foreach (Items item in itemList)
                {
                    if (item.Catagorie == "Side")
                    {
                        Console.WriteLine($"{i}: {item.Name}\t\t${item.Price}");
                        Console.WriteLine($"\t\t{item.Discription}");
                        i++;
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("          ========== Beverage =========      ");
                Console.WriteLine();
                foreach (Items item in itemList)
                {
                    if (item.Catagorie == "Beverage")
                    {
                        Console.WriteLine($"{i}: {item.Name}\t\t${item.Price}");
                        Console.WriteLine($"\t\t{item.Discription}");
                        i++;
                    }
                }


            }


    }

}


