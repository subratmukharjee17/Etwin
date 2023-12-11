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
    public class BlChartStrips : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlChartStrips(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddChartStrips(ChartStrip chartStrip)
        {
            //clsLog.Info(">>> ADD ChartStrip - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartStrips.Add(chartStrip);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADD ChartStrip - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADD ChartStrip - FINE");
            }

            return result;
        }


        public IList<ChartStrip> GetChartStrip()
        {
            //clsLog.Info(">>> GET ChartStrip - INIZIO");

            IList<ChartStrip> lstChartStrip = new List<ChartStrip>();

            try
            {
                lstChartStrip = this.unitOfWork.ChartStrips.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstChartStrip.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GET ChartStrip - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET ChartStrip - FINE");
            }

            return lstChartStrip;
        }

        public ChartStrip GetChartStrip(int IdChartStrip)
        {
            //clsLog.Info(">>> GET ChartStrip - INIZIO");

            ChartStrip chartStrip = new ChartStrip();

            try
            {
                chartStrip = this.unitOfWork.ChartStrips.Get(IdChartStrip);
            }
            catch (Exception ex)
            {
                clsLog.Error("GET ChartStrip - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET ChartStrip - FINE");
            }

            return chartStrip;
        }


        public bool UpdateChartStrip(ChartStrip chartStrip)
        {
            //clsLog.Info(">>> UPDATE ChartStrip - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartStrips.Update(chartStrip);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATE ChartStrip - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATE ChartStrip - FINE");
            }

            return result;
        }

        public bool DeleteChartStrip(ChartStrip chartStrip)
        {
            //clsLog.Info(">>> DELETE ChartStrip - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartStrips.Remove(chartStrip);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETE ChartStrip - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETE ChartStrip - FINE");
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
