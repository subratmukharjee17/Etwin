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
    public class BlBomPhases : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlBomPhases(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public IList<BomPhase> GetBomPhaseByPhaseList(int idPhaseList)
        {
            IList<BomPhase> lstBomPhase = new List<BomPhase>();
            try
            {
                Expression<Func<BomPhase, bool>> expr = e => e.IdPhaseList == idPhaseList;

                lstBomPhase = this.unitOfWork.BomPhases.GetAll(expr, null, "").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstBomPhase;
        }

        public BomPhase ExistBomPhase(BomPhase bp)
        {
            BomPhase bomPhase = new BomPhase();
            try
            {
                Expression<Func<BomPhase, bool>> expr = e => e.IdPhaseList == bp.IdPhaseList && e.IdItem == bp.IdItem;

                bomPhase = this.unitOfWork.BomPhases.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bomPhase;
        }

        public void AddBomPhase(BomPhase bom)
        {
            try
            {
                this.unitOfWork.BomPhases.Add(bom);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void UpdateBomPhase(BomPhase bom)
        {
            try
            {
                this.unitOfWork.BomPhases.Update(bom);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void DeleteBomPhase(BomPhase bom)
        {
            try
            {
                this.unitOfWork.BomPhases.Remove(bom);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
