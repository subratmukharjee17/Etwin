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
    public class BlOperatorsCalendars : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlOperatorsCalendars(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public BindingList<OperatorsCalendar> GetOperatorsCalendar(int idOperatorsCalendar)
        {
            IList<OperatorsCalendar> lstOperatorsCalendar = new List<OperatorsCalendar>();
            BindingList<OperatorsCalendar> bindingListOperatorsCalendar = new BindingList<OperatorsCalendar>();
            try
            {
                Expression<Func<OperatorsCalendar, bool>> expr = e => e.IdOperatorCalendar == idOperatorsCalendar;

                lstOperatorsCalendar = this.unitOfWork.OperatorsCalendar.GetAll(expr).ToList();
                bindingListOperatorsCalendar = new BindingList<OperatorsCalendar>(lstOperatorsCalendar);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListOperatorsCalendar;
        }



        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
