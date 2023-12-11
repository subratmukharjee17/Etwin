using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlBom : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlBom(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public void AddBom(Bom bom)
        {
            try
            {
                this.unitOfWork.Bom.Add(bom);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public Bom GetBomByItem(int idItem)
        {
            Bom bom = null;

            try
            {
                Expression<Func<Bom, bool>> expr = e => e.IdItem == idItem;

                bom = this.unitOfWork.Bom.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bom;
        }

        public Bom ExistBom(int idItem)
        {
            Bom bom = null;
            try
            {
                Expression<Func<Bom, bool>> expr = e => e.IdItem == idItem;
                bom = this.unitOfWork.Bom.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bom;
        }

        public IList<Bom> GetBomByItemByMain(int id)
        {
            IList<Bom> bomList = new List<Bom>();
            try
            {
                Expression<Func<Bom, bool>> expr = e => e.Id == id || e.IdMainBom == id;
                bomList = this.unitOfWork.Bom.GetAll(expr).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bomList;
        }

        public void DeleteBom(Bom bom)
        {
            try
            {
                this.unitOfWork.Bom.Remove(bom);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        
        public Bom GetBomById(int idBom)
        {
            Bom b = new Bom();
            try
            {
                Expression<Func<Bom, bool>> expr = e => e.Id == idBom;
                b = this.unitOfWork.Bom.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return b;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}
