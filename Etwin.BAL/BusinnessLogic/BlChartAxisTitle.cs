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
    public class BlChartAxisTitle : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlChartAxisTitle(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddChartAxisTitle(ChartAxisTitle chartTitles)
        {
            //clsLog.Info(">>> ADD chartTitles - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartAxisTitle.Add(chartTitles);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADD chartTitles - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADD chartTitles - FINE");
            }

            return result;
        }


        public IList<ChartAxisTitle> GetChartAxisTitle()
        {
            //clsLog.Info(">>> GET chartTitles - INIZIO");

            IList<ChartAxisTitle> lstChartTitles = new List<ChartAxisTitle>();

            try
            {
                lstChartTitles = this.unitOfWork.ChartAxisTitle.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstChartTitles.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GET chartTitles - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET chartTitles - FINE");
            }

            return lstChartTitles;
        }

        public IList<ChartAxisTitle> GetChartAxisTitle(int IdChart)
        {
            //clsLog.Info(">>> GET chartTitles - INIZIO");

            IList<ChartAxisTitle> lstChartTitles = new List<ChartAxisTitle>();

            try
            {
                Expression<Func<ChartAxisTitle, bool>> expr = e => e.IdAxisTitle== IdChart;
                lstChartTitles = this.unitOfWork.ChartAxisTitle.GetAll(expr, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstChartTitles.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GET chartTitles - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET chartTitles - FINE");
            }

            return lstChartTitles;
        }

        public ChartAxisTitle GetChartAxisTitles(int IdChartTitles)
        {
            //clsLog.Info(">>> GET chartTitles - INIZIO");

            ChartAxisTitle chartTitles = new ChartAxisTitle();

            try
            {
                chartTitles = this.unitOfWork.ChartAxisTitle.Get(IdChartTitles);
            }
            catch (Exception ex)
            {
                clsLog.Error("GET chartTitles - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET chartTitles - FINE");
            }

            return chartTitles;
        }


        public bool UpdateChartAxisTitle(ChartAxisTitle chartTitles)
        {
            //clsLog.Info(">>> UPDATE chartTitles - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartAxisTitle.Update(chartTitles);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATE chartTitles - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATE chartTitles - FINE");
            }

            return result;
        }

        public bool DeleteChartAxisTitle(ChartAxisTitle chartTitles)
        {
            //clsLog.Info(">>> DELETE chartTitles - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartAxisTitle.Remove(chartTitles);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETE chartTitles - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETE chartTitles - FINE");
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
