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
    public class BlGantts : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlGantts(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddGantts(Gantt Gantts)
        {
            //clsLog.Info(">>> ADD Gantts - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Gantt.Add(Gantts);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADD Gantts - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADD Gantts - FINE");
            }

            return result;
        }

        public Gantt GetGanttByName(string caption)
        {
            Gantt gantt = null;
            try
            {
                Expression<Func<Gantt, bool>> expr = e => e.GanttName == caption;

                gantt = this.unitOfWork.Gantt.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return gantt;
        }
        public IList<Gantt> GetGantts()
        {
            //clsLog.Info(">>> GET Gantts - INIZIO");

            IList<Gantt> lstGantts = new List<Gantt>();

            try
            {
                lstGantts = this.unitOfWork.Gantt.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstGantts.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GET Gantts - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET Gantts - FINE");
            }

            return lstGantts;
        }

        public Gantt GetGantts(int IdGantts)
        {
            //clsLog.Info(">>> GET Gantts - INIZIO");

            Gantt gantts = new Gantt();

            try
            {
                gantts = this.unitOfWork.Gantt.Get(IdGantts);
            }
            catch (Exception ex)
            {
                clsLog.Error("GET Gantts - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET Gantts - FINE");
            }

            return gantts;
        }


        public bool UpdateGantts(Gantt gantts)
        {
            //clsLog.Info(">>> UPDATE Gantts - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Gantt.Update(gantts);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATE Gantts - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATE Gantts - FINE");
            }

            return result;
        }

        public bool DeleteGantts(Gantt gantts)
        {
            //clsLog.Info(">>> DELETE Gantts - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Gantt.Remove(gantts);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETE Gantts - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETE Gantts - FINE");
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
