using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class ViewDepartmentOpenProcessesRepository : Repository<ViewDepartmentOpenProcess>, IViewDepartmentOpenProcessesRepository
    {
        private readonly ETwinContext _db;

        public ViewDepartmentOpenProcessesRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ViewDepartmentOpenProcess viewDepartmentOpenProcess)
        {
            //var objFromDb = this._db.ViewCommesse.FirstOrDefault(s => s.Id == viewCommesse.Id);

            //if (objFromDb != null)
            //{
            //    this._db.SaveChanges();
            //}
        }
    }
}
