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
    public class BlChartPanes : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlChartPanes(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddChartPane(ChartPane chartPanes)
        {
            //clsLog.Info(">>> ADD ChartPanes - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartPanes.Add(chartPanes);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADD ChartPanes - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADD ChartPanes - FINE");
            }

            return result;
        }


        public IList<ChartPane> GetChartPane()
        {
            //clsLog.Info(">>> GET ChartPanes - INIZIO");

            IList<ChartPane> lstChartPane = new List<ChartPane>();

            try
            {
                lstChartPane = this.unitOfWork.ChartPanes.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstChartPane.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GET ChartPane - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET ChartPane - FINE");
            }

            return lstChartPane;
        }

        public ChartPane GetChartPane(int IdChartPane)
        {
            //clsLog.Info(">>> GET ChartPane - INIZIO");

            ChartPane chartPane = new ChartPane();

            try
            {
                chartPane = this.unitOfWork.ChartPanes.Get(IdChartPane);
            }
            catch (Exception ex)
            {
                clsLog.Error("GET ChartPane - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET ChartPane - FINE");
            }

            return chartPane;
        }


        public bool UpdateChartPane(ChartPane chartPane)
        {
            //clsLog.Info(">>> UPDATE ChartPane - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartPanes.Update(chartPane);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATE ChartPane - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATE ChartPane - FINE");
            }

            return result;
        }

        public bool DeleteChartPane(ChartPane chartPane)
        {
            //clsLog.Info(">>> DELETE ChartPane - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartPanes.Remove(chartPane);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETE ChartPane - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETE ChartPane - FINE");
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
