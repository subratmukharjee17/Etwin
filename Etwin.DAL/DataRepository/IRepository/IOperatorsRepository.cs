using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IOperatorsRepository : IRepository<Operator>
    {
        void Update(Operator operators);
    }
}
