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
    public class BlGrids : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlGrids(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddGrid(Grid grid)
        {
            ////clsLog.Info(">>> ADDGRID - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Grid.Add(grid);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDGRID - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> ADDGRID - FINE");
            }

            return result;
        }


        public IList<Grid> GetGrids()
        {
            ////clsLog.Info(">>> GETGRIDS - INIZIO");

            IList<Grid> lstGrids = new List<Grid>();

            try
            {
                lstGrids = this.unitOfWork.Grid.GetAll(null, null, "Bands.GridsColumns").ToList();
                ////clsLog.Info(">>> Record trovati: " + lstGrids.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GetGrids - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETGRIDS - FINE");
            }

            return lstGrids;
        }

        public IList<Grid> GetDetailsGrids(int idGridParent)
        {
            ////clsLog.Info(">>> GETDETAILSGRIDS - INIZIO");

            IList<Grid> lstGrids = new List<Grid>();

            try
            {
                Expression<Func<Grid, bool>> expr = e => e.IdgridParent == idGridParent;

                lstGrids = this.unitOfWork.Grid.GetAll(expr, null, "Bands.GridsColumns").ToList();
                ////clsLog.Info(">>> Record trovati: " + lstGrids.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETDETAILSGRIDS - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETDETAILSGRIDS - FINE");
            }

            return lstGrids;
        }

        public BindingList<Grid> GetGrid(string gridName)
        {
            ////clsLog.Info(">>> GETGRID - INIZIO");

            IList<Grid> lstGrids = new List<Grid>();
            BindingList<Grid> bindingList = new BindingList<Grid>();

            try
            {
                Expression<Func<Grid, bool>> expr = e => e.GridName == gridName;

                lstGrids = this.unitOfWork.Grid.GetAll(expr, null, "Band.GridsColumn.GridsColumnsValue,GridsColumn.IdTipoColonnaNavigation").ToList();
                bindingList = new BindingList<Grid>(lstGrids);

            }
            catch (Exception ex)
            {
                clsLog.Error("GetGrid - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETGRID - FINE");
            }

            return bindingList;
        }

        public Grid GetGrid(int idGrid)
        {
            ////clsLog.Info(">>> GETGRID - INIZIO");

            Grid grid = new Grid();

            try
            {
                //Expression<Func<Grid, bool>> expr = e => e.Id == idGrid;

                grid = this.unitOfWork.Grid.Get(idGrid);
            }
            catch (Exception ex)
            {
                clsLog.Error("GetGrid - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETGRID - FINE");
            }

            return grid;
        }


        public int GetIdColumnByName(string columnName)
        {
            GridsColumn grid = new GridsColumn();
            int id = 0;
            try
            {
                Expression<Func<GridsColumn, bool>> expr = e => e.ColumnName == columnName;

                grid = this.unitOfWork.GridsColumns.GetFirstOrDefault(expr);
                if (grid != null)
                {
                    id = grid.Id;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return id;
        }

        public bool UpdateGrid(Grid grid)
        {
            ////clsLog.Info(">>> UPDATEGRID - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Grid.Update(grid);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UpdateGrid - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> UPDATEGRID - FINE");
            }

            return result;
        }

        public bool DeleteGrid(Grid grid)
        {
            ////clsLog.Info(">>> DELETEGRID - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Grid.Remove(grid);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETEGRID - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> DELETEGRID - FINE");
            }

            return result;
        }

        public int GetMaxOrdineDetailGrid(int idParentGrid)
        {
            ////clsLog.Info(">>> GETMAXORDINEDETAILGRID - INIZIO");
            ////clsLog.Info("idParentGrid = " + idParentGrid.ToString());
            int result = 1;

            try
            {
                Expression<Func<Grid, bool>> expr = e => e.IdgridParent == idParentGrid;

                IList<Grid> lstGrids = this.unitOfWork.Grid.GetAll(expr).ToList();

                int? ordineGrid = lstGrids.OrderByDescending(g => g.Ordine).Select(b => b.Ordine).FirstOrDefault();
                if (ordineGrid != null)
                {
                    result = (int)ordineGrid + 1;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error("GETMAXORDINEDETAILGRID - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETMAXORDINEDETAILGRID - FINE");
            }

            return result;
        }

        public Grid GetGridByName(string caption)
        {
            Grid grid = null;
            try
            {
                Expression<Func<Grid, bool>> expr = e => e.GridName == caption;

                grid = this.unitOfWork.Grid.GetFirstOrDefault(expr, "");
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return grid;
        }


        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
