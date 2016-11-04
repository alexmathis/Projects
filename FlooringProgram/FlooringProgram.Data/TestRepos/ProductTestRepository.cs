using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class ProductTestRepository : IProductRepository
    {
        List<Product> products = new List<Product>();
        public ProductTestRepository()
        {
            Product carpet = new Product()
            {
                ProductType = "CARPET",
                LaborCostPerSquareFoot = 2.10M,
                CostPerSquareFoot = 2.25M
            };
            Product Wood = new Product()
            {
                ProductType = "WOOD",
                LaborCostPerSquareFoot = 5.15M,
                CostPerSquareFoot = 4.75M
            };
            Product Tile = new Product()
            {
                ProductType = "TILE",
                LaborCostPerSquareFoot = 4.15M,
                CostPerSquareFoot = 3.50M
            };
            Product Laminate = new Product()
            {
                ProductType = "LAMINATE",
                LaborCostPerSquareFoot = 2.10M,
                CostPerSquareFoot = 1.75M
            };


            products.Add(carpet);
            products.Add(Tile);
            products.Add(Wood);

        }

        public Product GetProduct(string ProductType)
        {

            var productToReturn = products.FirstOrDefault(p => p.ProductType == ProductType);
                return productToReturn;
        }

        public List<Product> ListProducts()
        {
            return products;
        }
    }
}   
