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
    public class BlRangeAreaChart : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlRangeAreaChart(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddRangeAreaChart(RangeAreaChart rangeAreaChart)
        {
            //clsLog.Info(">>> ADD RangeAreaChart - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RangeAreaChart.Add(rangeAreaChart);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADD RangeAreaChart - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADD RangeAreaChart - FINE");
            }

            return result;
        }


        public IList<RangeAreaChart> GetRangeAreaChart()
        {
            //clsLog.Info(">>> GET RangeAreaChart - INIZIO");

            IList<RangeAreaChart> lstRangeAreaChart = new List<RangeAreaChart>();

            try
            {
                lstRangeAreaChart = this.unitOfWork.RangeAreaChart.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstRangeAreaChart.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GET RangeAreaChart - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET RangeAreaChart - FINE");
            }

            return lstRangeAreaChart;
        }

        public RangeAreaChart GetRangeAreaChart(int IdRangeAreaChart)
        {
            //clsLog.Info(">>> GET RangeAreaChart - INIZIO");

            RangeAreaChart rangeAreaChart = new RangeAreaChart();

            try
            {
                rangeAreaChart = this.unitOfWork.RangeAreaChart.Get(IdRangeAreaChart);
            }
            catch (Exception ex)
            {
                clsLog.Error("GET RangeAreaChart - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET RangeAreaChart - FINE");
            }

            return rangeAreaChart;
        }


        public bool UpdateRangeAreaChart(RangeAreaChart rangeAreaChart)
        {
            //clsLog.Info(">>> UPDATE RangeAreaChart - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RangeAreaChart.Update(rangeAreaChart);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATE RangeAreaChart - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATE RangeAreaChart - FINE");
            }

            return result;
        }

        public bool DeleteRangeAreaChart(RangeAreaChart rangeAreaChart)
        {
            //clsLog.Info(">>> DELETE RangeAreaChart - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RangeAreaChart.Remove(rangeAreaChart);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETE RangeAreaChart - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETE RangeAreaChart - FINE");
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
