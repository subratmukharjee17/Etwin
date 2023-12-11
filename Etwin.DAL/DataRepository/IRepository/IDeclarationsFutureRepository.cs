using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Xml.Linq;
using Etwin.Model;

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IDeclarationsFutureRepository : IRepository<DeclarationsFuture>
    {
        void Update(DeclarationsFuture declaration);
    }
}
