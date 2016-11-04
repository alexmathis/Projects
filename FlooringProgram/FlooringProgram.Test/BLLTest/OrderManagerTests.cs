using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.Models.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Test.BLLTest
{
    [TestFixture]
    public class OrderManagerTests
    {
        [Test]
        public void TestAddOrder()
        {
            OperationManager manager = new OperationManager();
            
            string CustomerName ="Bob";
            decimal Area = 100.00M;
            string ProductType = "CARPET";
           string State = "OHIO";
            manager.AddOrder(CustomerName, State,Area,ProductType);
            DateTime newDate = DateTime.Today;
           ListOrderResponse response= manager.ListOrders(newDate);
            List<Order> orders = response.orders;
                Assert.AreEqual(1, orders.Count);
            
        }
        //[Test]
        //public void TestEditOrder()
        //{
        //    OperationManager manager = new OperationManager();
        //    Order oldOrder = new Order();
        //    oldOrder.CustomerName = "Bob";
        //    oldOrder.Area = 100.00M;
        //    oldOrder.ProductType = "CARPET";
        //    oldOrder.State = "OHIO";
        //    string CustomerName = "Alex";
        //    decimal Area = 200.00M;
        //    string ProductType = "WOOD";
        //    string State = "OHIO";
        //    manager.EditOrder(oldOrder, CustomerName, State, Area, product);
        //    DateTime newDate = DateTime.Today;
        //    ListOrderResponse response = manager.ListOrders(newDate);
        //    List<Order> orders = response.orders;
        //    Assert.AreEqual(1, orders.Count);
        //    Assert.AreEqual("Bob", orders[0].CustomerName);


        //}
        [Test]
        public void TestRemoveOrder()
        {
            OperationManager manager = new OperationManager();

            DateTime anotherDate = DateTime.Parse("12/01/1991");

            manager.RemoveOrder(anotherDate, 1);
            ListOrderResponse response = manager.ListOrders(anotherDate);
            List<Order> orders = response.orders;
            Assert.AreEqual(false,response.Success=false);



        }

    }
}
