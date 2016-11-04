using FlooringProgram.Data;
using FlooringProgram.Data.Factory;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.BLL
{
    public class OperationManager
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IStateRepository _stateRepository;

        public OperationManager()
        {
            _orderRepository = RepositoryFactory.CreateOrderRepo();
            _productRepository = RepositoryFactory.CreateProductRepo();
            _stateRepository = RepositoryFactory.CreateStateRepo();
        }

        //public OperationManager(IOrderRepository orderRepository, IProductRepository productRepository, IStateRepository stateRepository)
        //{
        //    this._orderRepository = orderRepository;
        //    this._productRepository = productRepository;
        //    this._stateRepository = stateRepository;
        //}

        public ListOrderResponse ListOrders(DateTime Date)
        {
            ListOrderResponse response = new ListOrderResponse();
            response.orders = _orderRepository.ListOrdersByDate(Date);
            if (response.orders.Count == 0)
            {
                response.Success = false;
                response.Message = "That is Not A Valid Date.";
            }
            else
            {
                response.Success = true;
                return response;
            }
            return response;



        }
        public Order CreateOrder(string CustomerName, string State, decimal Area, string ProductType)
        {
            string stateInput = State;
            State stateobject = _stateRepository.GetState(stateInput);

            string productTypeInput = ProductType;
            Product productObject = _productRepository.GetProduct(ProductType);



            Order order = new Order();
            order.ProductType = productObject.ProductType;
            order.CustomerName = CustomerName;
            order.State = stateobject.StateName;
            order.TaxRate = stateobject.TaxRate;
            order.OrderDate = DateTime.Today;
            order.Area = Area;
            order.MaterialCost = productObject.CostPerSquareFoot * Area;
            order.LaborCost = productObject.LaborCostPerSquareFoot * Area;
            order.CostPerSQFoot = (order.MaterialCost + order.LaborCost) / Area;
            decimal subtotal = order.MaterialCost + order.LaborCost;
            order.TotalTax = Math.Round((order.TaxRate * 0.01M) * subtotal, 2);
            order.Total = order.MaterialCost + order.LaborCost + order.TotalTax;
            order.LaborCostPerSQFoot = order.LaborCost / Area;



            return order;
        }

        public void AddOrder(string CustomerName, string State, decimal Area, string ProductType)
        {
            Order ordertoAdd = CreateOrder(CustomerName, State, Area, ProductType);
            ListOrderResponse response = new ListOrderResponse();

            _orderRepository.AddOrder(ordertoAdd.OrderDate, ordertoAdd);




        }

        public void RemoveOrder(DateTime date, int indexOfOrderToDelete)
        {
            _orderRepository.DeleteOrder(date, indexOfOrderToDelete);
        }

        public void EditOrder(Order oldOrder, string CustomerName, State State, decimal Area, Product product)
        {
            Order newOrder = CreateEditedOrder(oldOrder, CustomerName, State, Area, product);
            _orderRepository.EditOrder(newOrder.OrderDate, newOrder.OrderNumber, newOrder);




        }

        public Order CreateEditedOrder(Order order, string CustomerName, State State, decimal Area, Product Product)
        {
          

            
           



            Order newOrder = new Order();
            newOrder.ProductType = Product.ProductType;
            newOrder.CustomerName = CustomerName;
            newOrder.State = State.StateName;
            newOrder.TaxRate = State.TaxRate;
            newOrder.OrderDate = order.OrderDate;
            newOrder.Area = Area;
            newOrder.MaterialCost = Product.CostPerSquareFoot * Area;
            newOrder.LaborCost = Product.LaborCostPerSquareFoot * Area;
            newOrder.CostPerSQFoot = (newOrder.MaterialCost + newOrder.LaborCost) / Area;
            decimal subtotal = newOrder.MaterialCost + newOrder.LaborCost;
            newOrder.TotalTax = Math.Round((newOrder.TaxRate * 0.01M) * subtotal, 2);
            newOrder.Total = (newOrder.MaterialCost + newOrder.LaborCost + newOrder.TotalTax);
            newOrder.LaborCostPerSQFoot = newOrder.LaborCost / Area;

            newOrder.OrderNumber = order.OrderNumber;



            return newOrder;
        }

        public void ErrorLoggingCall(string errorMessage)
        {
            ErrorLgging error = new ErrorLgging();
            error.LogErrors(errorMessage);
        }

        public ListProductResponse GetProduct(string productType)
        {
            ListProductResponse response = new ListProductResponse();
            response.product = _productRepository.GetProduct(productType);
            if (response.product != null)
            {
                response.Success = true;
               

            }
            else
            {
                response.Success = false;
                response.Message = "enter a valid product type. wood, tile, laminate, carpet.";
                ErrorLoggingCall("enter a valid product type.");
            }
            return response;
        }

        public ListStateResponse GetState(string stateName)
        {
            ListStateResponse response = new ListStateResponse();
            response.state = _stateRepository.GetState(stateName);
            if (response.state != null)
            {
                response.Success = true;

            }
            else
            {
                response.Success = false;
                response.Message = "enter a valid product type. wood, tile, laminate, carpet.";
                ErrorLoggingCall("enter a valid state name.");
            }
            return response;
        }


    }
}      
