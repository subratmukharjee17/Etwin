using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using LogDll;


namespace Etwin.BAL.BusinnessLogic
{
    public class BlRangeClient : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlRangeClient(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddRangeClient(RangeClient rangeClient)
        {
            //clsLog.Info(">>> ADD RangeClient - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RangeClient.Add(rangeClient);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADD RangeClient - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADD RangeClient - FINE");
            }

            return result;
        }


        public IList<RangeClient> GetRangeClient()
        {
            //clsLog.Info(">>> GET RangeClient - INIZIO");

            IList<RangeClient> lstRangeClient = new List<RangeClient>();

            try
            {
                lstRangeClient = this.unitOfWork.RangeClient.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstRangeClient.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GET RangeClient - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET RangeClient - FINE");
            }

            return lstRangeClient;
        }

        public RangeClient GetRangeClient(int IdRangeClient)
        {
            //clsLog.Info(">>> GET RangeClient - INIZIO");

            RangeClient rangeClient = new RangeClient();

            try
            {
                rangeClient = this.unitOfWork.RangeClient.Get(IdRangeClient);
            }
            catch (Exception ex)
            {
                clsLog.Error("GET RangeClient - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET RangeClient - FINE");
            }

            return rangeClient;
        }


        public bool UpdateRangeClient(RangeClient rangeClient)
        {
            //clsLog.Info(">>> UPDATE RangeClient - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RangeClient.Update(rangeClient);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATE RangeClient - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATE RangeClient - FINE");
            }

            return result;
        }

        public bool DeleteRangeClient(RangeClient rangeClient)
        {
            //clsLog.Info(">>> DELETE RangeClient - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RangeClient.Remove(rangeClient);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETE RangeClient - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETE RangeClient - FINE");
            }

            return result;
        }
        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
