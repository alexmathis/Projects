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
    class ListOrdersWorkFlow
    {
        public void Execute()
        {
         
            Console.Clear();
            Console.WriteLine($"                                          Look Orders By Date");
            Console.WriteLine(ConsoleIO.SeperatorBarr);
            Console.WriteLine("Enter an Order Date: ");
            string userInput = Console.ReadLine();
            DateTime Date;
            DateTime.TryParse(userInput, out Date);
            OperationManager opm = new OperationManager();

            ListOrderResponse response = opm.ListOrders(Date);
            if (response.Success)
            {
                List<Order> orders = response.orders;
                foreach( Order order in orders)
                {
                    ConsoleIO.FullOrderDetails(order);


                }
            }
            else
            {
               
                response.Message="There are no orders for that date currently";
                Console.WriteLine(response.Message);

            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

      
    }
}
