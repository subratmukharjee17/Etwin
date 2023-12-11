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
    public class BlChartSeries : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlChartSeries(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddChartSeries(ChartSeries chartSeries)
        {
            //clsLog.Info(">>> ADDCHARTSERIES - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartSeries.Add(chartSeries);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDCHARTSERIES - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADDCHARTSERIES - FINE");
            }

            return result;
        }


        public IList<ChartSeries> GetChartSeries(int? idChart = null)
        {
            //clsLog.Info(">>> GETCHARTSERIES - INIZIO");

            IList<ChartSeries> lstChartSeries = new List<ChartSeries>();

            try
            {
                if(idChart != null)
                {
                    Expression<Func<ChartSeries, bool>> expr = e => e.IdChart == idChart;
                    lstChartSeries = this.unitOfWork.ChartSeries.GetAll(expr).ToList();
                }
                else
                {
                    lstChartSeries = this.unitOfWork.ChartSeries.GetAll().ToList();
                }


                //clsLog.Info(">>> Record trovati: " + lstChartSeries.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETCHARTSERIES - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETCHARTSERIES - FINE");
            }

            return lstChartSeries;
        }


        public ChartSeries GetChartSerie(int idChartSerie)
        {
            //clsLog.Info(">>> GETCHARTSERIE - INIZIO");

            ChartSeries chartSerie = new ChartSeries();

            try
            {
                chartSerie = this.unitOfWork.ChartSeries.Get(idChartSerie);
            }
            catch (Exception ex)
            {
                clsLog.Error("GETCHARTSERIE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETCHARTSERIE - FINE");
            }

            return chartSerie;
        }

        public IList<ChartStrip> GetStrips(int idSerie)
        {
            //clsLog.Info(">>> GETSTRIPS - INIZIO");
            IList<ChartStrip> lstStrip = new List<ChartStrip>();
            try
            {
                Expression<Func<ChartStrip, bool>> expr = e => e.IdChartSerie == idSerie;
                lstStrip = this.unitOfWork.ChartStrips.GetAll(expr, null, "IdChartSerieNavigation").ToList();
            }
            catch (Exception ex)
            {
                //clsLog.Info(">>> GETSTRIPS - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETSTRIPS - FINE");
            }
            return lstStrip;
        }

        public IList<ChartConstantLine> GetChartConstantLine(int idSerie)
        {
            //clsLog.Info(">>> GETChartConstantLine - INIZIO");
            IList<ChartConstantLine> lstChartConstantLine = new List<ChartConstantLine>();
            try
            {
                Expression<Func<ChartConstantLine, bool>> expr = e => e.IdChartSerie == idSerie;
                lstChartConstantLine = this.unitOfWork.ChartConstantLine.GetAll(expr, null, "").ToList();
            }
            catch (Exception ex)
            {
                //clsLog.Info(">>> GETChartConstantLine - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETChartConstantLine - FINE");
            }
            return lstChartConstantLine;
        }

        public bool UpdateChartSeries(ChartSeries chartSeries)
        {
            //clsLog.Info(">>> UPDATECHARTSERIES - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartSeries.Update(chartSeries);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATECHARTSERIES - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATECHARTSERIES - FINE");
            }

            return result;
        }

        public bool DeleteChartSerie(ChartSeries chartSerie)
        {
            //clsLog.Info(">>> DELETECHARTSERIE - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartSeries.Remove(chartSerie);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETECHARTSERIE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETECHARTSERIE - FINE");
            }

            return result;
        }

        public IList<ChartAnimation> GetChartAnimations(int idChart)
        {
            //clsLog.Info(">>> GETCHARTANIMATIONS - INIZIO");
            IList<ChartAnimation> lstAnimation = new List<ChartAnimation>();
            try
            {
                Expression<Func<ChartAnimation, bool>> expr = e => e.IdChart == idChart;
                lstAnimation = this.unitOfWork.ChartAnimations.GetAll(expr, null, "IdChartNavigation").ToList();
            }
            catch (Exception ex)
            {
                //clsLog.Info(">>> GETCHARTANIMATIONS - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETCHARTANIMATIONS - FINE");
            }
            return lstAnimation;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
