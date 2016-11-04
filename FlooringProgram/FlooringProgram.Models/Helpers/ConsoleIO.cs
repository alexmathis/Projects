using FlooringProgram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI.Helpers
{
    class ConsoleIO
    {
        public const string SeperatorBarr = "=====================================================================================================";





        public static string GetRequiredStringFromUser(string prompt)
        {
            
            Console.Write(prompt);
            string Userinput = Console.ReadLine();


            if (string.IsNullOrEmpty(Userinput))
            {
                Console.WriteLine("You must enter valid text.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            else
            {


            }
            return Userinput;
        }

        public static int GetRequiredIntFromUser(string prompt)
        {
          

            int number = 0;
            string UserInput;
            bool doWeHaveANumber = false;

            while (doWeHaveANumber == false)
            {

                Console.Write(prompt);
                // rounds = Convert.ToInt32(Console.ReadLine());
                UserInput = Console.ReadLine();
                if (int.TryParse(UserInput, out number))
                {
                    if (number >= 1)
                    {
                        doWeHaveANumber = true;
                        return number;
                    }
                    else
                    {
                        doWeHaveANumber = false;
                        Console.WriteLine("That is not a valid  number");

                    }



                }
                else
                {
                    doWeHaveANumber = false;
                    Console.WriteLine("That is not a number");
                }


            }
            return number;
        }
        public static decimal GetRequiredDecimalFromUser(string prompt)
        {
            
           

            decimal number = 0;
            
            bool doWeHaveANumber = false;

            while (doWeHaveANumber == false)
            {
                Console.Write(prompt);
                string UserInput = Console.ReadLine();

                // rounds = Convert.ToInt32(Console.ReadLine());
                //UserInput = Console.ReadLine();
                if (decimal.TryParse(UserInput, out number))
                {
                    if (number >= 1)
                    {
                        doWeHaveANumber = true;
                        return number;
                    }
                    else
                    {
                        doWeHaveANumber = false;
                        Console.WriteLine("That is not a valid  number");

                    }



                }
                else
                {
                    doWeHaveANumber = false;
                    Console.WriteLine("That is not a number");
                }


            }
            return number;
        }
        public static DateTime PromptforDateTime()
        {
            DateTime enteredDate;
            string input = "";
            
            do
            {
                Console.Write("Please enter a date: ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out enteredDate));

            return enteredDate;
        }
       

        public static string GetYesNoAnswerFromuser(string prompt)
        {

            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                    }
                    return input;
                }
            }
        }


        public static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine($"{order.OrderDate}");
            Console.WriteLine($"{order.OrderNumber}");
            Console.WriteLine($"{order.CustomerName}");

        }

        public static void FullOrderDetails(Order order)
        {
            Console.WriteLine(ConsoleIO.SeperatorBarr);
            Console.WriteLine("");
            Console.WriteLine($"        Customer Name{order.CustomerName}");
            Console.WriteLine($"        Order Number {order.OrderNumber}");
            Console.WriteLine($"        Order Date: {order.OrderDate}");
            Console.WriteLine("");
            Console.WriteLine($"        Product Type: {order.ProductType}");
            Console.WriteLine($"        Order Tax Rate: {order.TaxRate}%");
            Console.WriteLine($"        Order Cost PSQF: ${order.CostPerSQFoot}");
            Console.WriteLine($"        Order Labor Cost PSQF: ${order.LaborCostPerSQFoot}");
            Console.WriteLine("");
            Console.WriteLine($"        Order Labor Cost: ${order.LaborCost}");
            Console.WriteLine($"        Order Material Cost: ${order.MaterialCost}");
            Console.WriteLine($"         Order Total: ${order.Total}");
            Console.WriteLine("");
          
        }



    }
}     

