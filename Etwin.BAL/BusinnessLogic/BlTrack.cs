using System.Linq.Expressions;
using LogDll;
using System.Drawing;
using System;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.DAL.DataRepository;
using Etwin.Model;
using System.Collections.Generic;
using System.Linq;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlTrack: IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlTrack(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public IList<Track> GetTrack(int qty)
        {
            IList<Track> lstTrack = new List<Track>();
            try
            {
                Expression<Func<Track, bool>> expr = e => e.Id == qty;
                lstTrack = this.unitOfWork.Track.GetAll(expr).ToList();
                //lstTrack = lstTrack.Take(qty).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstTrack;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
