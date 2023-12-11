using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using LogDll;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using Range = Etwin.Model.Range;
using System;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class RangeController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<RangeController> _logger;
        private readonly BlRange blRange = null;

        #endregion

        public RangeController(ILogger<RangeController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blRange = new BlRange(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddRange/{range}")]
        public async Task<bool> AddRange(Etwin.Model.Range range)
        {
            bool result = true;
            try
            {
                result = this.blRange.AddRange(range);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRanges/")]
        public async Task<IList<Range>> GetRanges()
        {
            IList<Range> lstRange = new List<Range>();
            try
            {
                lstRange = this.blRange.GetRanges();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstRange;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRange/{idRange}")]
        public async Task<Range> GetRange(int idRange)
        {
            Range range = new Range();
            try
            {
                range = this.blRange.GetRange(idRange);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return range;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetRangeFromSeries/{idRange}")]
        public async Task<IList<RangeClient>> GetRangeFromSeries(int idRange)
        {
            IList<RangeClient> lstRange = new List<RangeClient>();
            try
            {
                lstRange = this.blRange.GetRangeFromSeries(idRange);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstRange;
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateRange/{range}")]
        public async Task<bool> UpdateRange(Range range)
        {
            bool result = true;
            try
            {
                result = this.blRange.UpdateRange(range);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteRange/{range}")]
        public async Task<bool> DeleteRange(Range range)
        {
            bool result = true;
            try
            {
                result = this.blRange.DeleteRange(range);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return result;
        }
    }
}