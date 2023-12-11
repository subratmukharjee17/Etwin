using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Etwin.Model;
using Range = Etwin.Model.Range;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IRangeRepository : IRepository<Range>
    {
        void Update(Range range);
    }
}
