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
    public class BlChartConstantLine : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlChartConstantLine(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public BindingList<ChartConstantLine> GetConstantLine(int idConstantLine)
        {
            IList<ChartConstantLine> lstChartConstantLine = new List<ChartConstantLine>();
            BindingList<ChartConstantLine> bindingListChartConstantLine = new BindingList<ChartConstantLine>();
            try
            {
                Expression<Func<ChartConstantLine, bool>> expr = e => e.IdConstantLine == idConstantLine;

                lstChartConstantLine = this.unitOfWork.ChartConstantLine.GetAll(expr).ToList();
                bindingListChartConstantLine = new BindingList<ChartConstantLine>(lstChartConstantLine);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListChartConstantLine;
        }



        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
