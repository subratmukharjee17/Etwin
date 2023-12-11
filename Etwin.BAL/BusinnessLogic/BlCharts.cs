using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.ComponentModel;
using System.Linq.Expressions;
using LogDll;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlCharts : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlCharts(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddChart(Chart chart)
        {
            //clsLog.Info(">>> ADDCHART - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Chart.Add(chart);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDCHART - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADDCHART - FINE");
            }

            return result;
        }


        public IList<Chart> GetCharts()
        {
            //clsLog.Info(">>> GETCHARTS - INIZIO");

            IList<Chart> lstCharts = new List<Chart>();

            try
            {
                lstCharts = this.unitOfWork.Chart.GetAll(null, null, "ChartSeries").ToList();
                //clsLog.Info(">>> Record trovati: " + lstCharts.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETCHARTS - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETCHARTS - FINE");
            }

            return lstCharts;
        }

        public IList<Chart> GetCharts(int idChart)
        {
            //clsLog.Info(">>> GETCHARTS - INIZIO");

            IList<Chart> lstCharts = new List<Chart>();

            try
            {
                Expression<Func<Chart, bool>> expr = e => e.Id == idChart;
                lstCharts = this.unitOfWork.Chart.GetAll(expr, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstCharts.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETCHARTS - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETCHARTS - FINE");
            }

            return lstCharts;
        }

        public Chart GetChartByName(string caption)
        {
            Chart chart = null;
            try
            {
                Expression<Func<Chart, bool>> expr = e => e.ChartName == caption;

                chart = this.unitOfWork.Chart.GetFirstOrDefault(expr, "");
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return chart;
        }

        public BindingList<Chart> GetChart(string chartName)
        {
            //clsLog.Info(">>> GETCHART - INIZIO");

            IList<Chart> lstCharts = new List<Chart>();
            BindingList<Chart> bindingList = new BindingList<Chart>();

            try
            {
                Expression<Func<Chart, bool>> expr = e => e.ChartName == chartName;

                lstCharts = this.unitOfWork.Chart.GetAll(expr, null, "").ToList();
                bindingList = new BindingList<Chart>(lstCharts);

            }
            catch (Exception ex)
            {
                clsLog.Error("GETCHART - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETCHART - FINE");
            }

            return bindingList;
        }

        public Chart GetChart(int idChart)
        {
            //clsLog.Info(">>> GETCHART - INIZIO");

            Chart graph = new Chart();

            try
            {
                graph = this.unitOfWork.Chart.Get(idChart);
            }
            catch (Exception ex)
            {
                clsLog.Error("GETCHART - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETCHART - FINE");
            }

            return graph;
        }


        public bool UpdateChart(Chart chart)
        {
            //clsLog.Info(">>> UPDATECHART - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Chart.Update(chart);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATECHART - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATECHART - FINE");
            }

            return result;
        }

        public bool DeleteChart(Chart chart)
        {
            //clsLog.Info(">>> DELETECHART - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Chart.Remove(chart);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETECHART - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETECHART - FINE");
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
