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
    public class BlChartTitle : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlChartTitle(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddChartTitles(ChartTitle chartTitles)
        {
            //clsLog.Info(">>> ADD chartTitles - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartTitle.Add(chartTitles);
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


        public IList<ChartTitle> GetChartTitles()
        {
            //clsLog.Info(">>> GET chartTitles - INIZIO");

            IList<ChartTitle> lstChartTitles = new List<ChartTitle>();

            try
            {
                lstChartTitles = this.unitOfWork.ChartTitle.GetAll(null, null, "").ToList();
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

        //public IList<ChartTitle> GetChartTitle(int IdChart)
        //{
        //    //clsLog.Info(">>> GET chartTitles - INIZIO");

        //    IList<ChartTitle> lstChartTitles = new List<ChartTitle>();

        //    try
        //    {
        //        Expression<Func<ChartTitle, bool>> expr = e => e.IdChart == IdChart;
        //        lstChartTitles = this.unitOfWork.ChartTitle.GetAll(expr, null, "").ToList();
        //        //clsLog.Info(">>> Record trovati: " + lstChartTitles.Count());
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error("GET chartTitles - Error: " + ex.ToString());
        //    }
        //    finally
        //    {
        //        //clsLog.Info(">>> GET chartTitles - FINE");
        //    }

        //    return lstChartTitles;
        //}

        public ChartTitle GetChartTitles(int IdChartTitles)
        {
            //clsLog.Info(">>> GET chartTitles - INIZIO");

            ChartTitle chartTitles = new ChartTitle();

            try
            {
                chartTitles = this.unitOfWork.ChartTitle.Get(IdChartTitles);
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


        public bool UpdateChartTitles(ChartTitle chartTitles)
        {
            //clsLog.Info(">>> UPDATE chartTitles - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartTitle.Update(chartTitles);
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

        public bool DeleteChartTitles(ChartTitle chartTitles)
        {
            //clsLog.Info(">>> DELETE chartTitles - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartTitle.Remove(chartTitles);
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
