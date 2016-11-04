using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI.Helpers
{
    public class ConsoleIO
    {


        public const string SeperatorBarr = "========================================================================================================================";





        public static string GetRequiredStringFromUser(string prompt)
        {

            Console.Write(prompt);
            bool weHaveAStringWithoutComma = false;

            string Userinput = null;

            do
            {
                Userinput = Console.ReadLine().ToUpper();

                if ((string.IsNullOrEmpty(Userinput)) || Userinput.Contains(","))
                {
                    Console.WriteLine("Your name may not contain a comma.");

                    OperationManager op = new OperationManager();
                    op.ErrorLoggingCall("need valid text");
                }
                else
                {
                    weHaveAStringWithoutComma = true;
                }


            }
            while (weHaveAStringWithoutComma == false);

            return Userinput;
        }

        public static string GetRequiredState(string prompt)
        {
            bool weHaveAStringWithoutComma = false;
            string Userinput;
            do
            {
                Console.Write(prompt);
                Userinput = Console.ReadLine().ToUpper();
                OperationManager op = new OperationManager();
                ListStateResponse response = op.GetState(Userinput);

                if (response.Success == true)
                {
                    weHaveAStringWithoutComma = true;
                }


            }
            while (weHaveAStringWithoutComma == false);

            return Userinput;
        }

        public static string GetRequiredProduct(string prompt)
        {


            bool weHaveAStringWithoutComma = false;

            string Userinput;
           
            do
            {
                Console.Write(prompt);
                Userinput = Console.ReadLine().ToUpper();
                OperationManager op = new OperationManager();
                ListProductResponse response = op.GetProduct(Userinput);

                if (response.Success == true)
                {
                    weHaveAStringWithoutComma = true;
                }


            }
            while (weHaveAStringWithoutComma == false);

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
                        OperationManager op = new OperationManager();
                        op.ErrorLoggingCall("That is not a valid  number");

                    }



                }
                else
                {
                    doWeHaveANumber = false;
                    Console.WriteLine("That is not a number");
                    OperationManager op = new OperationManager();
                    op.ErrorLoggingCall("That is not a number");
                }


            }
            return number;
        }

        public static decimal GetRequiredDecimalFromUser(string prompt)
        {



            decimal number = 0.00M;

            bool doWeHaveANumber = false;

            while (doWeHaveANumber == false)
            {
                Console.Write(prompt);
                string UserInput = Console.ReadLine();

                // rounds = Convert.ToInt32(Console.ReadLine());
                //UserInput = Console.ReadLine();
                if (decimal.TryParse(UserInput, out number))
                {
                    if (number >= 1.00M)
                    {
                        doWeHaveANumber = true;
                        return number;
                    }
                    else
                    {
                        doWeHaveANumber = false;
                        Console.WriteLine("value must be at least 1.00");
                        OperationManager op = new OperationManager();
                        op.ErrorLoggingCall("enterd number less than zero");

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
                Console.Write("Please enter a date MM/DD/YYYY:  ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out enteredDate));

            return enteredDate;
        }

        public static string GetYesNoAnswerFromuser(string prompt)
        {

            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue.");
                    OperationManager op = new OperationManager();
                    op.ErrorLoggingCall("Need Yes or No ");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue.");
                        OperationManager op = new OperationManager();
                        op.ErrorLoggingCall("is a sting  but now y or n");
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
            Console.WriteLine($"                Customer Name: {order.CustomerName}");
            Console.WriteLine($"                 Order Number: {order.OrderNumber}");
            Console.WriteLine($"                        State: {order.State}     ");
            Console.WriteLine($"                   Order Date: {order.OrderDate}");
            Console.WriteLine("");
            Console.WriteLine($"                 Product Type: {order.ProductType}");
            Console.WriteLine($"               Order Tax Rate: {order.TaxRate}%");
           
            Console.WriteLine($"              Order Cost PSQF: {order.CostPerSQFoot.ToString("C")}");
      
           
            Console.WriteLine($"        Order Labor Cost PSQF: {order.LaborCostPerSQFoot.ToString("C")}");
            Console.WriteLine("");
            Console.WriteLine($"             Order Labor Cost: {order.LaborCost.ToString("C")}");
            Console.WriteLine($"          Order Material Cost: {order.MaterialCost.ToString("C")}");

            Console.WriteLine($"              order Tax Total: {order.TotalTax.ToString("C")}");

            Console.WriteLine($"                  Order Total: {order.Total.ToString("C")}");
            Console.WriteLine("");

        }
         
        public static decimal GetEditedArea(string inputArea)
        {

            decimal number = 0;

            bool doWeHaveANumber = false;

            while (doWeHaveANumber == false)
            {

                string UserInput = Console.ReadLine();


                if (decimal.TryParse(UserInput, out number))
                {
                    if (number >= 1.00M)
                    {
                        doWeHaveANumber = true;
                        return number;
                    }
                    else
                    {
                        doWeHaveANumber = false;
                        Console.WriteLine("That is not a valid decimal. please enter a decimal that is at least 1.00 and less than 28 char.");
                        OperationManager op = new OperationManager();
                        op.ErrorLoggingCall("That is not a valid decimal. please enter a decimal that is at least 1.00 or more than 28 characters");

                    }



                }
                else
                {
                    doWeHaveANumber = false;
                    Console.WriteLine("That is not valid");
                    OperationManager op = new OperationManager();
                    op.ErrorLoggingCall("That is not valid");
                }


            }
            return number;

        }

        public static Product GetEditStringProductType(string prompt, Order order)
        {


            string productType = "";
            bool CorrectProductType = false;
            Product product = null;



            do
            {
                Console.Write(prompt);

                string Userinput = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(Userinput))
                {
                    productType = order.ProductType;
                    OperationManager op = new OperationManager();
                    ListProductResponse getProduct = op.GetProduct(productType);
                    product = getProduct.product;
                    CorrectProductType = true;

                }
                else
                {


                    OperationManager op = new OperationManager();
                    ListProductResponse getproduct = op.GetProduct(Userinput);

                    if (getproduct.Success == true)
                    {
                        product = getproduct.product;
                        CorrectProductType = true;

                    }

                }


            } while ((CorrectProductType == false));
            return product;
        }



        public static State GetRequiredStateForEdit(string prompt, Order order)
        {


            bool weHaveAStringWithoutComma = false;

            State state = null;
            string Userinput;

            do
            {
                Console.Write(prompt);
                string stateToGet;

                Userinput = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(Userinput))
                {
                    stateToGet = order.State;
                    OperationManager op = new OperationManager();
                    ListStateResponse getState = op.GetState(stateToGet);
                    state = getState.state;
                    weHaveAStringWithoutComma = true;

                    break;
                }
                else
                {




                    OperationManager op = new OperationManager();
                    ListStateResponse getState = op.GetState(Userinput);

                    if (getState.Success == true)
                    {
                        state = getState.state;
                        weHaveAStringWithoutComma = true;
                        break;
                    }
                    else
                    {
                        Console.Write(prompt);
                        weHaveAStringWithoutComma = false;
                    }

                }




            }
            while (weHaveAStringWithoutComma == false);

            return state;
        }

        //public static string GetEditStringState(string prompt, Order order)
        //{

        //    Console.Write($"{ prompt}");
        //    string Userinput = Console.ReadLine().ToUpper();
        //    string State;

        //    if (string.IsNullOrEmpty(Userinput))
        //    {
        //        State = order.State;
        //        OperationManager op = new OperationManager();

        //    }
        //    else
        //    {
        //        State = Userinput;

        //    }
        //    return State;
        //}

        public static string GetEditStringName(string prompt, Order order)
        {
            bool weHaveAStringWithoutComma = false;
            Console.Write($"{ prompt}");

            string CustomerName = "";
            while (weHaveAStringWithoutComma == false)
            {
                string Userinput = Console.ReadLine().ToUpper();
                if (string.IsNullOrEmpty(Userinput))
                {
                    CustomerName = order.CustomerName;
                    weHaveAStringWithoutComma = true;

                }
                else
                {

                    if (Userinput.Contains(","))
                    {
                        Console.WriteLine("Your name may not contain a comma.");

                        OperationManager op = new OperationManager();
                        op.ErrorLoggingCall("need valid text");
                        weHaveAStringWithoutComma = false;
                    }
                    else
                    {
                        weHaveAStringWithoutComma = true;
                        CustomerName = Userinput;
                    }


                }

               
            }
            return CustomerName;
        }



        public static decimal GetEditdecimalArea(Order order)
        {
            bool doWeHaveANumber = false;
            decimal Area = 0;
            do
            {
                Console.Write($"Current Area {order.Area} must be at least one and less than 28 char. long:  ");
                string Userinput = Console.ReadLine();

                if (Userinput == "")
                {
                    Area = order.Area;
                    doWeHaveANumber = true;
                   
                }
                else
                {
                    decimal number;
                    decimal.TryParse(Userinput, out number);

                    if (number >= 1.00M)
                    {
                        doWeHaveANumber = true;
                        Area = number;
                        break;
                    }
                    else
                    {
                        doWeHaveANumber = false;
                        Console.WriteLine(". number must be at least 1.00 and less than 28 char. long");
                        OperationManager op = new OperationManager();
                        op.ErrorLoggingCall("enterd number less than zero or longer than 28 characters");
                       
                    }


                }


            } while (doWeHaveANumber == false);
            return Area;
        }
        
    }
}   
          

