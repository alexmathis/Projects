using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Data.ProdRepos;

namespace FlooringProgram.Data.Factory
{
    public class RepositoryFactory
    {
        public static IOrderRepository CreateOrderRepo()
        {
            IOrderRepository repo;
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "FreeTest":

                    repo = new OrderTestRepository();
                    break;
                default:
                    repo = new OrderProdRespository();
                    break;


            }
            return repo;
        }
        public static IProductRepository CreateProductRepo()
        {
            IProductRepository repo;
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "FreeTest":
                    repo = new ProductTestRepository();
                    break;
                default:
                    repo = new ProductProdRepository();
                    break;
            }
            return repo;
        }
        public static IStateRepository CreateStateRepo()
        {
            IStateRepository repo;
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            switch (mode)
            {
                case "FreeTest":
                    repo = new StateTestRepository();
                    break;
                default:
                    repo = new StateProdRepository();
                    break;
            }
            return repo;
        }


    }
}
