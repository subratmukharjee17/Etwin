using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IViewCommesseRepository : IRepository<ViewCommesse>
    {
        void Update(ViewCommesse viewCommesse);
    }
}
