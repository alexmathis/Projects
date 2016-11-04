using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        
        static Dictionary<DateTime, List<Order>> ordersByDate = new Dictionary<DateTime, List<Order>>();

       
        static OrderTestRepository()
        {

           

            Order november = new Order();
          
            november.CustomerName = "GOJO";
            november.State = "OHIO";
            november.ProductType = "Carpet";
            november.TaxRate = 6.00M;
            november.CostPerSQFoot = 20.00M;
            november.Area = 100.00M;
            november.LaborCostPerSQFoot = 10.00M;
            november.MaterialCost = 10.00M;
            november.LaborCost = 1000.00M;
            november.TotalTax = 6.00M;
            november.Total = 12000.00M;
            november.OrderDate = new DateTime(1991, 12, 04);
            november.OrderNumber = 1;




            Order september = new Order();
            
            september.CustomerName = "BOBSPIZZASHOP";
            september.State = "OHIO";
            september.ProductType = "TILE";
            september.TaxRate = 6.00M;
            september.CostPerSQFoot = 30.00M;
            september.Area = 100.00M;
            september.LaborCostPerSQFoot = 15.00M;
            september.MaterialCost = 15.00M;
            september.LaborCost = 1000.00M;
            september.TotalTax = 6.00M;
            september.Total = 12000.00M;
            september.OrderDate = new DateTime(1991, 12, 04);
            september.OrderNumber = 2;

            Order dannerPress = new Order();
            
            dannerPress.CustomerName = "DannerPress";
            dannerPress.State = "OHIO";
            dannerPress.ProductType = "WOOD";
            dannerPress.TaxRate = 6.00M;
            dannerPress.CostPerSQFoot = 20.00M;
            dannerPress.Area = 100.00M;
            dannerPress.LaborCostPerSQFoot = 40.00M;
            dannerPress.MaterialCost = 10.00M;
            dannerPress.LaborCost = 1000.00M;
            dannerPress.TotalTax = 6.00M;
            dannerPress.Total = 12000.00M;
            dannerPress.OrderDate = new DateTime(1991, 12, 03);
            dannerPress.OrderNumber = 1;

            Order jackSmith = new Order();
            
            jackSmith.CustomerName = "Jack Smith";
            jackSmith.State = "OHIO";
            jackSmith.ProductType = "WOOD";
            jackSmith.TaxRate = 6.25M;
            jackSmith.CostPerSQFoot = 20.00M;
            jackSmith.Area = 100.00M;
            jackSmith.LaborCostPerSQFoot = 10.00M;
            jackSmith.MaterialCost = 10.00M;
            jackSmith.LaborCost = 1000.00M;
            jackSmith.TotalTax = 6.00M;
            jackSmith.Total = 12000.00M;
            jackSmith.OrderDate = new DateTime(1991, 12, 03);
            jackSmith.OrderNumber = 2;

            Order MakersMark = new Order();

            MakersMark.CustomerName = "Makers Mark";
            MakersMark.State = "OHIO";
            MakersMark.ProductType = "WOOD";
            MakersMark.TaxRate = 6.00M;
            MakersMark.CostPerSQFoot = 20.00M;
            MakersMark.Area = 100.00M;
            MakersMark.LaborCostPerSQFoot = 40.00M;
            MakersMark.MaterialCost = 10.00M;
            MakersMark.LaborCost = 1000.00M;
            MakersMark.TotalTax = 6.00M;
            MakersMark.Total = 12000.00M;
            MakersMark.OrderDate = new DateTime(1991, 12, 02);
            MakersMark.OrderNumber = 1;

            Order jackDaniels = new Order();

            jackDaniels.CustomerName = "Jack Daniels";
            jackDaniels.State = "OHIO";
            jackDaniels.ProductType = "CARPET";
            jackDaniels.TaxRate = 6.25M;
            jackDaniels.CostPerSQFoot = 20.00M;
            jackDaniels.Area = 100.00M;
            jackDaniels.LaborCostPerSQFoot = 10.00M;
            jackDaniels.MaterialCost = 10.00M;
            jackDaniels.LaborCost = 1000.00M;
            jackDaniels.TotalTax = 6.00M;
            jackDaniels.Total = 12000.00M;
            jackDaniels.OrderDate = new DateTime(1991, 12, 02);
            jackDaniels.OrderNumber = 2;

            Order JimBeam = new Order();

            JimBeam.CustomerName = "JimBeam";
            JimBeam.State = "OHIO";
            JimBeam.ProductType = "CARPET";
            JimBeam.TaxRate = 6.25M;
            JimBeam.CostPerSQFoot = 20.00M;
            JimBeam.Area = 100.00M;
            JimBeam.LaborCostPerSQFoot = 10.00M;
            JimBeam.MaterialCost = 10.00M;
            JimBeam.LaborCost = 1000.00M;
            JimBeam.TotalTax = 6.00M;
            JimBeam.Total = 12000.00M;
            JimBeam.OrderDate = new DateTime(1991, 12, 01);
            JimBeam.OrderNumber = 1;

            
            List<Order> orders = new List<Order>();
            List<Order> anotherorders = new List<Order>();
            List<Order>  newWisky = new List<Order>();
            List<Order> anotherWisky = new List<Order>();

            orders.Add(november);
            orders.Add(september);
            
            anotherorders.Add(dannerPress);
            anotherorders.Add(jackSmith);

            newWisky.Add(jackDaniels);
            newWisky.Add(MakersMark);
            anotherWisky.Add(JimBeam);
            
          



            ///this creates a date time, but must have this format.
           

            ordersByDate.Add(november.OrderDate, orders);
            ordersByDate.Add(dannerPress.OrderDate, anotherorders);
            ordersByDate.Add(jackDaniels.OrderDate, newWisky);
            ordersByDate.Add(JimBeam.OrderDate, anotherWisky);
        }
        
       
        

        public Order LoadOrder(DateTime Date, int OrderNumber)
        {
            throw new NotImplementedException();

        }

        public List<Order> ListOrdersByDate(DateTime Date)
        {
            if (ordersByDate.ContainsKey(Date))
            {
                List<Order> value = ordersByDate[Date];
                return value;
            }
            return null;
        }

        public void DeleteOrder(DateTime date, int index)
        {
            if (ordersByDate.ContainsKey(date))
            {
                List<Order> value = ordersByDate[date];
                value.RemoveAt(index-1);
            }
            
      
        }

        public void EditOrder(DateTime Date, int orderNumber, Order order)
        {
            if (ordersByDate.ContainsKey(Date))
            {
                //LinQ Statment that gets item then remove. 
                List<Order> orders = ordersByDate[Date];
                orders.RemoveAll(o => o.OrderNumber == orderNumber);
                orders.Add(order);


                
               
             
                
            }

           
        }

        public void AddOrder(DateTime Date, Order order)
        {
            if (ordersByDate.ContainsKey(Date))
            {

                ordersByDate[Date].Add(order);
                order.OrderNumber = ordersByDate[Date].IndexOf(order) + 1;
            }
            else
            {
                List<Order> addorder = new List<Order>();

                addorder.Add(order);
                order.OrderNumber = addorder.IndexOf(order) + 1;
                ordersByDate.Add(Date, addorder);
            }
        }
    }
}   

