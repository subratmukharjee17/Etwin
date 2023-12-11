using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlToolTipControl : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlToolTipControl(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }
        #region TOOLTIP GRID
        public IList<GridTooltip> GetToolTipGrids(int idGrid)
        {

            IList<GridTooltip> lstToolTipGrid = new List<GridTooltip>();

            try
            {
                Expression<Func<GridTooltip, bool>> expr = e => e.IdGridColumn == idGrid ;
                lstToolTipGrid = this.unitOfWork.ToolTipGrid.GetAll(expr, null, "").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstToolTipGrid;
        }
        
        public GridTooltip GetToolTipGrid(int idToolTipGrid)
        {

            GridTooltip toolTipGrid = new GridTooltip();

            try
            {
                toolTipGrid = this.unitOfWork.ToolTipGrid.Get(idToolTipGrid);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return toolTipGrid;
        }
        #endregion

        #region TOOLTIP CHART
        public IList<ChartCrosshair> GetToolTipCharts(int idChart)
        {

            IList<ChartCrosshair> lstToolTipChart = new List<ChartCrosshair>();

            try
            {
                Expression<Func<ChartCrosshair, bool>> expr = e => e.IdChart == idChart;
                lstToolTipChart = this.unitOfWork.ChartCrosshair.GetAll(expr, null, "").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstToolTipChart;
        }

        public ChartCrosshair GetToolTipChart(int idToolTipChart)
        {

            ChartCrosshair toolTipChart = new ChartCrosshair();

            try
            {
                toolTipChart = this.unitOfWork.ChartCrosshair.Get(idToolTipChart);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return toolTipChart;
        }
        #endregion

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
