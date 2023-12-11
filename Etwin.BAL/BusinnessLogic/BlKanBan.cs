using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlKanBan : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlKanBan(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public KanBanBoard GetKanBanBoard(int idBoard)
        {
            KanBanBoard board = new KanBanBoard();

            try
            {
                Expression<Func<KanBanBoard, bool>> expr = e => e.Id == idBoard;
                board = this.unitOfWork.KanBanBoard.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return board;
        }

        public IList<KanBanGroup> GetListKanBanGroup(int idBoard)
        {
            IList<KanBanGroup> lstGroup = new List<KanBanGroup>();

            try
            {
                Expression<Func<KanBanGroup, bool>> expr = e => e.IdBoard == idBoard;
                lstGroup = this.unitOfWork.KanBanGroup.GetAll(expr).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstGroup;
        }

        public IList<KanBanItem> GetListKanBanItem(int idGroup)
        {
            IList<KanBanItem> lstItem = new List<KanBanItem>();

            try
            {
                Expression<Func<KanBanItem, bool>> expr = e => e.IdGroup == idGroup;
                lstItem = this.unitOfWork.KanBanItem.GetAll(expr).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstItem;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
