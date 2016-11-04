using FlooringProgram.BLL;
using FlooringProgram.Data;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using FlooringProgram.Data;

namespace FlooringProgram.Test
{
    [TestFixture]


    public class TestOrderTestRepository
    {
        

        [Test]
        public void TestAddOrder()
        {

            OrderTestRepository repo = new OrderTestRepository();


            Order Test = new Order();

            Test.CustomerName = "Floor Cleaner";
            Test.State = "OHIO";
            Test.ProductType = "Carpet";
            Test.TaxRate = 6.00M;
            Test.CostPerSQFoot = 20.00M;
            Test.Area = 100.00M;
            Test.LaborCostPerSQFoot = 10.00M;
            Test.MaterialCost = 10.00M;
            Test.LaborCost = 1000.00M;
            Test.TotalTax = 6.00M;
            Test.Total = 12000.00M;
            Test.OrderDate = new DateTime(1991, 12, 04);
            repo.AddOrder(Test.OrderDate, Test);


            List<Order> orders = repo.ListOrdersByDate(Test.OrderDate);

            Assert.AreEqual(3, orders.Count());
            Order check = orders[2];
            Assert.AreEqual("Floor Cleaner", check.CustomerName);
            Assert.AreEqual("OHIO", check.State);


        }
        [Test]
        public void TestDeleteOrder()
        {

            OrderTestRepository repo = new OrderTestRepository();
            DateTime newDateTime = DateTime.Parse("12/03/1991");
           
            repo.DeleteOrder(newDateTime, 2);


            List<Order> orders = repo.ListOrdersByDate(newDateTime);

            Assert.AreEqual(1, orders.Count());


        }
        [Test]
        public void TestEditOrder()
        {

            OrderTestRepository repo = new OrderTestRepository();


        

            Order Test = new Order();

            Test.CustomerName = "Should Have Been Jack Daniels";
            Test.State = "OHIO";
            Test.ProductType = "WOOD";
            Test.TaxRate = 6.00M;
            Test.CostPerSQFoot = 20.00M;
            Test.Area = 100.00M;
            Test.LaborCostPerSQFoot = 40.00M;
            Test.MaterialCost = 10.00M;
            Test.LaborCost = 1000.00M;
            Test.TotalTax = 6.00M;
            Test.Total = 12000.00M;
            Test.OrderDate = new DateTime(1991, 12, 02);
            Test.OrderNumber = 1;
            repo.EditOrder(Test.OrderDate, 1, Test);


            List<Order> orders= repo.ListOrdersByDate(Test.OrderDate);

            Assert.AreEqual(2, orders.Count());
            Order check = orders[1];
            Assert.AreEqual("Should Have Been Jack Daniels", check.CustomerName);
        }
        [Test]
        public void TestListOrder()
        {

            OrderTestRepository repo = new OrderTestRepository();


            Order Test = new Order();
            DateTime time = new DateTime(1991, 12, 04);
            List<Order> orders = repo.ListOrdersByDate(time);
            Assert.AreEqual(3, orders.Count());

        }
    }
}