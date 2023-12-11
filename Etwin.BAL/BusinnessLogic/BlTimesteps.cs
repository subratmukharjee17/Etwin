using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.ComponentModel;
using LogDll;
using System.Linq.Expressions;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlTimesteps : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlTimesteps(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public BindingList<Timestep> GetTimestep(int idTimestep)
        {
            IList<Timestep> lstTimestep = new List<Timestep>();
            BindingList<Timestep> bindingListTimestep = new BindingList<Timestep>();
            try
            {
                Expression<Func<Timestep, bool>> expr = e => e.IdTimestep == idTimestep;

                lstTimestep = this.unitOfWork.Timesteps.GetAll(expr).ToList();
                bindingListTimestep = new BindingList<Timestep>(lstTimestep);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListTimestep;
        }



        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
