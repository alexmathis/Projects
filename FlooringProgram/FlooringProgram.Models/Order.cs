﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public string ProductType { get; set; }
        public decimal TaxRate { get; set; }
        public decimal CostPerSQFoot { get; set; }
        public decimal Area { get; set; }
        public decimal LaborCostPerSQFoot { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal TotalTax { get; set; }
        public decimal Total { get; set; }
    }
}