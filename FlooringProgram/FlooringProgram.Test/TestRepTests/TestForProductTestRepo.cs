using FlooringProgram.Data;
using FlooringProgram.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Test
{
    [TestFixture]
    public class TestForProductTestRepo
    {
        [Test]
        public void TestGetProduct()
        {
            ProductTestRepository repo = new ProductTestRepository();
            Product carpet = repo.GetProduct("CARPET");
            Assert.AreEqual("CARPET",carpet.ProductType);
            Assert.AreEqual(10.00M, carpet.LaborCostPerSquareFoot );
            Assert.AreEqual(20.00M, carpet.CostPerSquareFoot);
        }
        public void TestListProducts()
        {
            ProductTestRepository repo = new ProductTestRepository();
            List<Product> products = repo.ListProducts();
            Assert.AreEqual(3, products.Count());
        }

    }
}
