using FlooringProgram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using System.IO;

namespace FlooringProgram.Data.ProdRepos
{
    class ProductProdRepository : IProductRepository
    {
        private const string _filepath = @"DataFiles\Products.txt";

        public Product GetProduct(string ProductType)
        {
            List<Product> products = new List<Product>();
            using (StreamReader sr = new StreamReader(_filepath))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Product newproduct = new Product();

                    string[] columns = line.Split(',');

                    newproduct.ProductType = columns[0];
                    newproduct.CostPerSquareFoot = decimal.Parse(columns[1]);
                    newproduct.LaborCostPerSquareFoot = decimal.Parse(columns[2]);


                    products.Add(newproduct);


                }
                var productToReturn = products.FirstOrDefault(p => p.ProductType == ProductType);
                return productToReturn;

            }
        }

       

        public List<Product> ListProducts()
        {
            List<Product> products = new List<Product>();
            using (StreamReader sr = new StreamReader(_filepath))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Product newproduct = new Product();

                    string[] columns = line.Split(',');

                    newproduct.ProductType = columns[0];
                    newproduct.CostPerSquareFoot = decimal.Parse(columns[1]);
                    newproduct.LaborCostPerSquareFoot = decimal.Parse(columns[2]);


                    products.Add(newproduct);


                }
                
                return products;

            }
        }
    }
}
