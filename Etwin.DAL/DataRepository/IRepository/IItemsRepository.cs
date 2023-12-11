using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IItemsRepository : IRepository<Item>
    {
        void Update(Item itme);
    }
}
