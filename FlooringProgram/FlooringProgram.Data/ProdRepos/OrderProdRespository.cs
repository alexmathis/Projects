using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data
{

    public class OrderProdRespository : IOrderRepository
    {
       
        public void AddOrder(DateTime Date, Order order)
        {
            var orders = ReadFromFile(order.OrderDate);
            orders.Add(order);


            order.OrderNumber = orders.IndexOf(order) + 1;

            WriteToFile(orders, Date);
            
        }

      

        public void DeleteOrder(DateTime date, int index)
        {
            var orders = ReadFromFile(date);
            var orderToChange = orders.FirstOrDefault(o => o.OrderNumber == index);
            orders.Remove(orderToChange);



            WriteToFile(orders,date);
        
        }

        public void EditOrder(DateTime Date, int orderNumber, Order order)
        {
           // bool isSuccess = false;


           

            var orders = ReadFromFile(Date);
            var orderToRemove = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            orders.Remove(orderToRemove);
            orders.Add(order);
            orders = orders.OrderBy(o => o.OrderNumber).ToList();

            

            WriteToFile(orders, Date);

            //return true;

        }

        public List<Order> ListOrdersByDate(DateTime Date)
        {
            
            var orders = ReadFromFile(Date);
            return orders;
           
        }

        public Order LoadOrder(DateTime Date, int OrderNumber)
        {
            throw new NotImplementedException();
        }

        private List<Order> ReadFromFile(DateTime Date)
        {
           string fileName=GetFilePath(Date);

            List<Order> orders= new List<Order>();

            if (File.Exists(fileName))
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    // read the header line
                    

                    string inputLine = "";
                    sr.ReadLine();
                    while ((inputLine = sr.ReadLine()) != null)
                    {
                        string[] inputParts = inputLine.Split(',');
                        Order newOrder = new Order()
                        {
                            CustomerName = inputParts[0],
                            State = inputParts[1],
                            ProductType = inputParts[2],
                            TaxRate = decimal.Parse(inputParts[3]),
                            CostPerSQFoot = decimal.Parse(inputParts[4]),
                            Area = decimal.Parse(inputParts[5]),
                            LaborCostPerSQFoot = decimal.Parse(inputParts[6]),
                            MaterialCost = decimal.Parse(inputParts[7]),
                            LaborCost = decimal.Parse(inputParts[8]),
                            TotalTax = decimal.Parse(inputParts[9]),
                            Total = decimal.Parse(inputParts[10]),
                            OrderNumber = int.Parse(inputParts[11]),
                            OrderDate = DateTime.Parse(inputParts[12]),


                        };

                        orders.Add(newOrder);
                    }
                }
            }

            return orders;
        }

        private void WriteToFile(List<Order> orders, DateTime Date)
        {
            string FileName = GetFilePath(Date);
            using (StreamWriter sw = new StreamWriter(FileName, false))
            {
                // write the header line
                sw.WriteLine("CustomerName,State,ProductType,TaxRate,CostPerSQFoot,Area,LaborCostPerSQFoot,MaterialCost,LaborCost,TotalTax,Total,OrderDate");

                foreach (var order in orders)
                {
                    sw.WriteLine($"{order.CustomerName},{order.State},{order.ProductType},{order.TaxRate},{order.CostPerSQFoot},{order.Area},{order.LaborCostPerSQFoot},{order.MaterialCost},{order.LaborCost},{order.TotalTax},{order.Total},{order.OrderNumber},{order.OrderDate}");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public string GetFilePath(DateTime Date)
        {
            string FILENAME = @"DataFiles\Orders_";
            string  FILEEXT = ".txt";

             string fileName = String.Format("{0:MMddyyyy}", Date);
            fileName = FILENAME + fileName + FILEEXT;
            return fileName;
        }
    }
}