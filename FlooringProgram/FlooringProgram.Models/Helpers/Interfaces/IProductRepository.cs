﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.Interfaces
{
   public  interface IProductRepository
    {
        List<Product> ListProducts();
        Product GetProduct(string ProductType);
       
    }
}
