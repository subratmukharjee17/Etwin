using Etwin.DAL.GlobalDataRepository;
using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Etwin.BAL.BusinnessLogic.BLGlobalDB
{
    public class BlAnalysisDrawing :IDisposable
    {
        #region VARS
        IUnitOfWork unitOfWork = null;
        private readonly GlobalDbContext _db;
        #endregion

        #region CONSTRUCTOR
        public BlAnalysisDrawing()
        {
            this._db = new GlobalDbContext();
            this.unitOfWork = new UnitOfWork(_db);
        }
        #endregion

        #region DISPOSE
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion

        #region INSERT ANALYSIS DRAWING
        public void InsertAnalysisDrawings (AnalysisDrawing analysisDrawing,string cs, int? idPadre = null)
        {
            try
            {
                if(idPadre != null)
                {
                    analysisDrawing.IdMainDrawing = idPadre;
                }
                this.unitOfWork.AnalysisDrawings.Add(analysisDrawing);
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #region GET ID ANALYSIS DRAWINGS
        public AnalysisDrawing GetIdAnalysisDrawings(AnalysisDrawing analysisDrawing)
        {
            IList<AnalysisDrawing> ad = new List<AnalysisDrawing>();
            try
            {
                Expression<Func<AnalysisDrawing, bool>> expr = e => e.IdDrawingState == 1 && e.FileName == analysisDrawing.FileName;
                Func<IQueryable<AnalysisDrawing>, IOrderedEnumerable<AnalysisDrawing>> orderFunc = e=> (IOrderedEnumerable<AnalysisDrawing>)e.OrderByDescending(x => x.CreationDate);
                ad = this.unitOfWork.AnalysisDrawings.GetAll(expr, orderFunc, null).ToList();

            }
            catch(Exception ex )
            {
                clsLog.Error(ex.ToString());
            }
            return ad[0];
        }
        #endregion
    }
}
