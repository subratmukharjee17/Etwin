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
    public class BlGridsColumns : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlGridsColumns(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public bool AddGridsColumn(GridsColumn gridsColumn)
        {
            ////clsLog.Info(">>> ADDCOLUMN - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.GridsColumns.Add(gridsColumn);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDCOLUMN - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> ADDCOLUMN - FINE");
            }

            return result;
        }
        public BindingList<GridsColumn> GetGridsColumns(int idBand = 0)
        {
            ////clsLog.Info(">>> GETCOLUMNS - INIZIO");

            IList<GridsColumn> lstColumns = new List<GridsColumn>();
            BindingList<GridsColumn> result = new BindingList<GridsColumn>();

            try
            {
                Expression<Func<GridsColumn, bool>> expr = null;
                if (idBand > 0)
                {
                    expr = e => e.IdBand == idBand;
                }

                lstColumns = this.unitOfWork.GridsColumns.GetAll(expr, null, "GridsColumnsValues,IdTipoColonnaNavigation,IdbandNavigation").OrderBy(g=> g.ColumnOrder).ToList();

                result = new BindingList<GridsColumn>(lstColumns);
            }
            catch (Exception ex)
            {
                clsLog.Error("GetColumns - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETCOLUMNS - FINE");
            }

            return result;
        }

        public GridsColumn GetGridsColumn(int idColumn)
        {
            ////clsLog.Info(">>> GETCOLUMN - INIZIO");

            GridsColumn column = new GridsColumn();

            try
            {
                column = this.unitOfWork.GridsColumns.Get(idColumn);
            }
            catch (Exception ex)
            {
                clsLog.Error("GETCOLUMN - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETCOLUMN - FINE");
            }

            return column;
        }

        public bool UpdateGridsColumn(GridsColumn column)
        {
            ////clsLog.Info(">>> UPDATECOLUMNS - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.GridsColumns.Update(column);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UpdateColumns - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> UPDATECOLUMNS - FINE");
            }

            return result;
        }

        public GridsColumn GetColumnByName(int idBand, string nameColumn)
        {
            GridsColumn columns = new GridsColumn();
            try
            {
                Expression<Func<GridsColumn, bool>> expr = e => e.IdBand == idBand && e.ColumnName == nameColumn;

                columns = this.unitOfWork.GridsColumns.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error("GetMaxOrdineColumn - Error: " + ex.ToString());
            }

            return columns;
        }

        public int GetMaxOrdineGridsColumn(int idBand)
        {
            ////clsLog.Info(">>> GETMAXORDINECOLUMN - INIZIO");
            ////clsLog.Info("IdBand = " + idBand.ToString());
            int result = 1;

            try
            {
                Expression<Func<GridsColumn, bool>> expr = e => e.IdBand == idBand;

                IList<GridsColumn> lstColumns = this.unitOfWork.GridsColumns.GetAll(expr).ToList();

                int? ordineColonna = lstColumns.OrderByDescending(g => g.ColumnOrder).Select(b => b.ColumnOrder).FirstOrDefault();
                if(ordineColonna != null)
                {
                    result = (int)ordineColonna + 1;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error("GetMaxOrdineColumn - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETMAXORDINECOLUMN - FINE");
            }

            return result;
        }

        public bool DeleteGridsColumn(GridsColumn column)
        {
            ////clsLog.Info(">>> DELETECOLUMN - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.GridsColumns.Remove(column);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETECOLUMN - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> DELETECOLUMN - FINE");
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
