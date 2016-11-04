using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.Interfaces
{
    public interface IOrderRepository
    {
        Order LoadOrder(DateTime Date, int OrderNumber);
        void AddOrder(DateTime Date, Order order);
        void EditOrder( DateTime Date, int orderNumber, Order order);
        void DeleteOrder(DateTime date, int index);
        List<Order> ListOrdersByDate(DateTime Date);
        
    }
}
 