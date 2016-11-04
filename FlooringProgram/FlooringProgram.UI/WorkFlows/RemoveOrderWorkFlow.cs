using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI.WorkFlows
{
    class RemoveOrderWorkFlow
    {
        public void Execute()
        {
            OperationManager or = new OperationManager();
          
            Console.Clear();
            Console.WriteLine($"                                              Deleting an Order");
            Console.WriteLine(ConsoleIO.SeperatorBarr);
          //  Console.WriteLine( "Please enter the date of the order you want delete");
            DateTime date=ConsoleIO.PromptforDateTime();
           List<Order> orders= or.ListOrders(date).orders;
            foreach(Order order in  orders)
            {
                ConsoleIO.FullOrderDetails(order);
            }
            int orderNumberToDelete = ConsoleIO.GetRequiredIntFromUser("Please select the order number of the order you would like to delete. ");
            

            string answer = ConsoleIO.GetYesNoAnswerFromuser("Are you sure you want to delete that order").ToUpper();
            if (answer == "Y")
            {
                or.RemoveOrder(date, orderNumberToDelete);

               
              
            }
           

            
            
        }
    }
}
