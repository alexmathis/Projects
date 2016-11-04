using FlooringProgram.BLL;
using FlooringProgram.Models.Responses;
using FlooringProgram.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI.WorkFlows
{
    class AddOrderWorkFlow
    {
        public void Execute()
        {

            Console.Clear();
            Console.WriteLine($"                                              Add an  Order");
            Console.WriteLine(ConsoleIO.SeperatorBarr);
            string CustomerName=ConsoleIO.GetRequiredStringFromUser("Please input a customer name: ");
            Console.WriteLine(ConsoleIO.SeperatorBarr);
            string State=ConsoleIO.GetRequiredState("Please Input your State, supported states are IN,PA,OH, and MI:  ").ToUpper();
            //string State = ConsoleIO.GetRequiredStringFromUser("Please Input your Full State Name:  ").ToUpper();
            Console.WriteLine(ConsoleIO.SeperatorBarr);
            string ProductType = ConsoleIO.GetRequiredProduct("Please input a Product Type ex(wood,tile,carpet,Laminate):  ").ToUpper();
            
               // string ProductType = ConsoleIO.GetRequiredStringFromUser("Please input a Product Type ex(wood,tile,carpet,Laminate):  ").ToUpper();
            Console.WriteLine(ConsoleIO.SeperatorBarr);
            decimal Area = ConsoleIO.GetRequiredDecimalFromUser("Please enter the Area you want to cover:  ");
            Console.WriteLine(ConsoleIO.SeperatorBarr);
            if(ConsoleIO.GetYesNoAnswerFromuser("please Type Y if you want to save this Data, N for No.") == "Y")
            {
                OperationManager ordermanager = new OperationManager();
                ordermanager.AddOrder(CustomerName, State, Area, ProductType);
            }
           
            




           //AddOrderResponse response = orderManager.
           // if (response.Success)
           // {
           //   //  ConsoleIO.DisplayAccountDetails(response.account);
           // }
           // else
           // {
           //     Console.WriteLine("An Error Occured");
           //     Console.WriteLine(response.Message);

            // }
            // Console.WriteLine("Press any key to continue.");
            // Console.ReadKey();
        }
    }
}
