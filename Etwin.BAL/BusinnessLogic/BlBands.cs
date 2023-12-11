using Etwin.Model;
using System.ComponentModel;
using System.Linq.Expressions;
using LogDll;
using System;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.DAL.DataRepository;
using System.Collections.Generic;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlBands : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlBands(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public bool AddBand(GridBand band)
        {
            ////clsLog.Info(">>> ADDBAND - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Band.Add(band);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDBAND - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> ADDBAND - FINE");
            }

            return result;
        }
        public IList<GridBand> GetBands()
        {
            ////clsLog.Info(">>> GETBANDS - INIZIO");

            IList<GridBand> lstBands = new List<GridBand>();

            try
            {
                lstBands = this.unitOfWork.Band.GetAll(null, null, "GridColumns").ToList();
                ////clsLog.Info(">>> Record trovati: " + lstBands.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GetBands - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETBANDS - FINE");
            }

            return lstBands;
        }

        public BindingList<GridBand> GetBands(int idGrid)
        {
            ////clsLog.Info(">>> GETBAND - INIZIO");

            IList<GridBand> lstBands = new List<GridBand>();
            BindingList<GridBand> bindingList = new BindingList<GridBand>();

            try
            {
                Expression<Func<GridBand, bool>> expr = e => e.IdGrid == idGrid;

                lstBands = this.unitOfWork.Band.GetAll(expr, null, "GridsColumns.IdTipoColonnaNavigation,GridsColumns.GridsColumnsValues").ToList();
                bindingList = new BindingList<GridBand>(lstBands);

            }
            catch (Exception ex)
            {
                clsLog.Error("GETBAND - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETBAND - FINE");
            }

            return bindingList;
        }

        public GridBand GetBandByName(int idGrid, string bandName)
        {
            GridBand band = new GridBand();
            try
            {
                Expression<Func<GridBand, bool>> expr = e => e.IdGrid == idGrid && e.BandName == bandName;

                band = this.unitOfWork.Band.GetFirstOrDefault(expr);

            }
            catch (Exception ex)
            {
                clsLog.Error("GETBAND - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETBAND - FINE");
            }
            return band;
        }

        public GridBand GetBand(int idBand)
        {
            ////clsLog.Info(">>> GETBAND - INIZIO");

            GridBand band = new GridBand();

            try
            {
                band = this.unitOfWork.Band.Get(idBand);
            }
            catch (Exception ex)
            {
                clsLog.Error("GETBAND - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETBAND - FINE");
            }

            return band;
        }


        public bool UpdateBand(GridBand band)
        {
            ////clsLog.Info(">>> UPDATEBAND - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Band.Update(band);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UpdateBand - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> UPDATEBAND - FINE");
            }

            return result;
        }

        public int GetMaxOrdineBand(int idGrid)
        {
            ////clsLog.Info(">>> GETMAXORDINEBAND - INIZIO");
            ////clsLog.Info("IdGrid = " + idGrid.ToString());
            int result = 0;

            try
            {
                Expression<Func<GridBand, bool>> expr = e => e.IdGrid == idGrid;

                IList<GridBand> lstBands = this.unitOfWork.Band.GetAll(expr).ToList();

                result = lstBands.OrderByDescending(g => g.BandOrder).Select(b=> b.BandOrder).First() + 1;
            }
            catch (Exception ex)
            {
                clsLog.Error("GetMaxOrdineBand - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETMAXORDINEBAND - FINE");
            }

            return result;
        }

        public bool DeleteBand(GridBand band)
        {
            ////clsLog.Info(">>> DELETEBAND - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Band.Remove(band);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETEBAND - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> DELETEBAND - FINE");
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
