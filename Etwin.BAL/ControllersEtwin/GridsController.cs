using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
using System.Collections.Generic;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class GridsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<GridsController> _logger;
        private readonly BlGrids blGrids = null;

        #endregion

        public GridsController(ILogger<GridsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blGrids = new BlGrids(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddGrid/{grid}")]
        public async Task<bool> AddGrids(Grid grid)
        {
            bool result = true;
            try
            {
                result = this.blGrids.AddGrid(grid);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetGrids/")]
        public async Task<IList<Grid>> GetGrids()
        {
            IList<Grid> lstGrids = new List<Grid>();
            try
            {
                lstGrids = this.blGrids.GetGrids();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstGrids;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetDetailsGrids/{idGridParent}")]
        public async Task<IList<Grid>> GetDetailsGrids(int idGridParent)
        {
            IList<Grid> lstGrids = new List<Grid>();
            try
            {
                lstGrids = this.blGrids.GetDetailsGrids(idGridParent);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstGrids;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetGrid/{gridName}")]
        public async Task<BindingList<Grid>> GetDetailsGrids(string gridName)
        {
            BindingList<Grid> bindingList = new BindingList<Grid>();
            try
            {
                bindingList = this.blGrids.GetGrid(gridName);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingList;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetGrid/{idGrid}")]
        public async Task<Grid> GetGrid(int idGrid)
        {
            Grid grid = new Grid();
            try
            {
                grid = this.blGrids.GetGrid(idGrid);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return grid;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateGrid/{grid}")]
        public async Task<bool> UpdateGrid(Grid grid)
        {
            bool result = true;
            try
            {
                result = this.blGrids.UpdateGrid(grid);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteGrid/{grid}")]
        public async Task<bool> DeleteGrid(Grid grid)
        {
            bool result = true;
            try
            {
                result = this.blGrids.DeleteGrid(grid);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetMaxOrdineDetailGrid/{idParentGrid}")]
        public async Task<int> GetMaxOrdineDetailGrid(int idParentGrid)
        {
            int result = 1;
            try
            {
                result = this.blGrids.GetMaxOrdineDetailGrid(idParentGrid);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetGridByName/{caption}")]
        public async Task<Grid> GetGridByName(string caption)
        {
            Grid grid = new Grid();
            try
            {
                grid = this.blGrids.GetGridByName(caption);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return grid;
        }
    }
}