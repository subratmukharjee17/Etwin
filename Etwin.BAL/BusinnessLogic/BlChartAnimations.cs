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
    public class BlChartAnimations : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlChartAnimations(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddChartAnimations(ChartAnimation chartAnimation)
        {
            //clsLog.Info(">>> ADD Chart Animations - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartAnimations.Add(chartAnimation);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADD Chart Animations - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADD Chart Animations - FINE");
            }

            return result;
        }


        public IList<ChartAnimation> GetChartAnimations()
        {
            //clsLog.Info(">>> GET Chart Animations - INIZIO");

            IList<ChartAnimation> lstChartAnimations = new List<ChartAnimation>();

            try
            {
                lstChartAnimations = this.unitOfWork.ChartAnimations.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstChartAnimations.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GET Chart Animations - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET Chart Animations - FINE");
            }

            return lstChartAnimations;
        }

        public ChartAnimation GetChartAnimations(int IdChartAnimations)
        {
            //clsLog.Info(">>> GET Chart Animations - INIZIO");

            ChartAnimation chartAnimation = new ChartAnimation();

            try
            {
                chartAnimation = this.unitOfWork.ChartAnimations.Get(IdChartAnimations);
            }
            catch (Exception ex)
            {
                clsLog.Error("GET Chart Animations - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GET Chart Animations - FINE");
            }

            return chartAnimation;
        }


        public bool UpdateChartAnimations(ChartAnimation chartAnimation)
        {
            //clsLog.Info(">>> UPDATE Chart Animations - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartAnimations.Update(chartAnimation);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATE Chart Animations - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATE Chart Animations - FINE");
            }

            return result;
        }

        public bool DeleteChartAnimations(ChartAnimation chartAnimation)
        {
            //clsLog.Info(">>> DELETE Chart Animations - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.ChartAnimations.Remove(chartAnimation);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETE Chart Animations - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETE Chart Animations - FINE");
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
