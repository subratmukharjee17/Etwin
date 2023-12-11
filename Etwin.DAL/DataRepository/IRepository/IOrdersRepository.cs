using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IOrdersRepository : IRepository<Order>
    {
        void Update(Order order);
    }
}
