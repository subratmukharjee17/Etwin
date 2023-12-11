using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IRibbonPagesRepository : IRepository<RibbonsPage>
    {
        void Update(RibbonsPage ribbonPage);
    }
}
