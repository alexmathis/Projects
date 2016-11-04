using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.UI.Helpers;
using FlooringProgram.UI.WorkFlows;

namespace FlooringProgram.UI
{
    public static class MainMenu
    {
        public static void start()
        {
            while (true)
            {
               


                Console.Clear();
                Console.WriteLine($"                                             Flooring Program");
                Console.WriteLine( ConsoleIO.SeperatorBarr);
                Console.WriteLine($"                                               1.List Orders");
                Console.WriteLine($"                                               2.Add an Order");
                Console.WriteLine($"                                               3.Edit an Order");
                Console.WriteLine($"                                               4.Remove an Order");

                Console.WriteLine($"\n                                                 Q to quit");
               
                string userInput = "";
                while(userInput!="1"&& userInput!="2" && userInput != "3" && userInput != "4" && userInput != "Q")
                {
                  
                    Console.Write($"\n                                              Enter Selection  ");
                    userInput = Console.ReadLine().ToUpper();
                    switch (userInput)
                    {
                        case "1":
                            ListOrdersWorkFlow listorders = new ListOrdersWorkFlow();
                            listorders.Execute();
                            break;


                        case "2":
                            AddOrderWorkFlow addorder = new AddOrderWorkFlow();
                            addorder.Execute();
                            break;
                        case "3":
                            EditOrderWorkFlow editOrder = new EditOrderWorkFlow();
                            editOrder.Execute();
                            break;
                        case "4":
                            RemoveOrderWorkFlow removeorder = new RemoveOrderWorkFlow();
                            removeorder.Execute();
                            break;
                        case "Q":
                            return;
                    }

                }
            }

        }
    }
}
