using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model;
using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IChartRepository : IRepository<Chart>
    {
        void Update(Chart chart);
    }
}
