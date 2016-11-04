using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.Models.Responses;
using FlooringProgram.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI.WorkFlows
{
    class EditOrderWorkFlow
    {
        public void Execute()
        {
            OperationManager or = new OperationManager();
            Console.Clear();
            Console.WriteLine($"                                                      Edit Account");
            Console.WriteLine(ConsoleIO.SeperatorBarr);
            DateTime Date;
            ListOrderResponse response= new ListOrderResponse();
            response.Success = false;
            
            while (response.Success==false)
            {
                Console.WriteLine("Please enter a date mm/dd/yyyy");
                string userInput = Console.ReadLine();
                DateTime.TryParse(userInput, out Date);
                OperationManager opm = new OperationManager();
                opm.ListOrders(Date);

                response = opm.ListOrders(Date);
               
                if (response.Success==true)
                {
                    List<Order> orders = response.orders;
                    foreach (Order order in orders)
                    {
                        ConsoleIO.FullOrderDetails(order);
                       

                    }
              
                    break;
                }
                else
                {

                    response.Message = $"                      There are no orders for that date currently";
                    Console.WriteLine(response.Message);

                }
            }
           
            

            int orderNumberToEdit = ConsoleIO.GetRequiredIntFromUser("Please select the order number of the order you would like to edit. ") -1;
            Console.Clear();

            ConsoleIO.FullOrderDetails(response.orders[orderNumberToEdit]);
            string answer = ConsoleIO.GetYesNoAnswerFromuser("Are you sure you want to edit that order").ToUpper();

            if (answer == "Y")
            {
                Order order = response.orders[orderNumberToEdit];


               
               
                string  CustomerName=ConsoleIO.GetEditStringName($"current customer name( {order.CustomerName} ): ", order);
                Console.WriteLine(ConsoleIO.SeperatorBarr);
                State state =ConsoleIO.GetRequiredStateForEdit($"Current  State = ({order.State} ) valid states are OH, PA, MI, and IN ", order);
                Console.WriteLine(ConsoleIO.SeperatorBarr);
                Product product =ConsoleIO.GetEditStringProductType($"current product type is( {order.ProductType})  products are (carpet, wood, tile, Laminate) press enter to keep current selection ", order);
                decimal Area = ConsoleIO.GetEditdecimalArea(order);
                OperationManager op = new OperationManager();
                op.EditOrder(order,  CustomerName,  state,  Area, product);




            }

        }






    }


}
    

