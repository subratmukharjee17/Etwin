using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;

namespace Etwin.BAL.ControllersEtwin
{
    
    public class GridsColumnsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<GridsColumnsController> _logger;
        private readonly BlGridsColumns blGridsColumns = null;

        #endregion

        public GridsColumnsController(ILogger<GridsColumnsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blGridsColumns = new BlGridsColumns(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddGridsColumn/{gridsColumn}")]
        public async Task<bool> AddGridsColumn(GridsColumn gridsColumn)
        {
            bool result = true;
            try
            {
                result = this.blGridsColumns.AddGridsColumn(gridsColumn);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetGridsColumns/{idBand}")]
        public async Task<BindingList<GridsColumn>> GetGridsColumns(int idBand)
        {
            BindingList<GridsColumn> result = new BindingList<GridsColumn>();
            try
            {
                result = this.blGridsColumns.GetGridsColumns(idBand);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetGridsColumn/{idColumn}")]
        public async Task<GridsColumn> GetGridsColumn(int idColumn)
        {
            GridsColumn column = new GridsColumn();
            try
            {
                column = this.blGridsColumns.GetGridsColumn(idColumn);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return column;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateGridsColumn/{column}")]
        public async Task<bool> UpdateGridsColumn(GridsColumn column)
        {
            bool result = true;
            try
            {
                result = this.blGridsColumns.UpdateGridsColumn(column);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetColumnByName/{idBand}/{nameColumn}")]
        public async Task<GridsColumn> GetColumnByName(int idBand, string nameColumn)
        {
            GridsColumn columns = new GridsColumn();
            try
            {
                columns = this.blGridsColumns.GetColumnByName(idBand, nameColumn);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return columns;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetMaxOrdineGridsColumn/{idBand}")]
        public async Task<int> GetMaxOrdineGridsColumn(int idBand)
        {
            int result = 1;
            try
            {
                result = this.blGridsColumns.GetMaxOrdineGridsColumn(idBand);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteGridsColumn/{column}")]
        public async Task<bool> DeleteGridsColumn(GridsColumn column)
        {
            bool result = true;
            try
            {
                result = this.blGridsColumns.DeleteGridsColumn(column);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}