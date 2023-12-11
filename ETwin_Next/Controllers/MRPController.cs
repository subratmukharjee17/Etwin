using Etwin.BAL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Etwin.Model;
using Etwin.BAL.BusinnessLogic;
using LogDll;
using Newtonsoft.Json;
using Etwin.DAL.DataRepository;
using Etwin.Model.Context;
//using Etwin.Filter;


namespace ETwin_Next.Controllers
{
    public class MRPController : Controller
    {
        private readonly BlGeneric blGeneric = null;
        private readonly ETwinContext _db;
        public MRPController()
        {
            this.blGeneric = new BlGeneric();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = TempData["Key"];
            TempData.Keep("Key");
            return View();
        }
        
        public void ExecMRP1(int idDepartment, int? idOrderRow = null, int? idItem = null)
        {
            try
            {
                using (SP_Call sp = new SP_Call(this._db))
                {
                    // SP PARAMETER: idCommessa
                    Dapper.DynamicParameters dP = new Dapper.DynamicParameters();
                    dP.Add("IdDepartment", idDepartment);
                    if (idOrderRow != null)
                    {
                        dP.Add("IdOrderRow", idOrderRow);
                    }
                    if (idItem != null)
                    {
                        dP.Add("IdItem", idItem);
                    }
                    // CALL SP :RETURNS A JSON STRING WITH THE JOB PARAMETERS IN COLUMN FORMAT, NOT ROWS
                    string valoriCommessaJson = sp.OneRecordJson("MRP1", dP);
                    var keyValueList = JsonConvert.DeserializeObject<dynamic>(valoriCommessaJson);

                }
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void ExecMRP2(int? idItem = null)
        {
            try
            {
                using (SP_Call sp = new SP_Call(this._db))
                {
                    // SP PARAMETER: idCommessa
                    Dapper.DynamicParameters dP = new Dapper.DynamicParameters();
                    if (idItem != null)
                    {
                        dP.Add("IdItem", idItem);
                    }
                    // CALL SP : RETURNS A JSON STRING WITH THE JOB PARAMETERS IN COLUMN FORMAT, NOT ROWS
                    string valoriCommessaJson = sp.OneRecordJson("MRP2", dP);
                    var keyValueList = JsonConvert.DeserializeObject<dynamic>(valoriCommessaJson);

                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void ExecMRP3(int idDepartment, int? idOrderRow = null, int? idItem = null)
        {
            try
            {
                using (SP_Call sp = new SP_Call(this._db))
                {
                    // SP PARAMETER: idCommessa
                    Dapper.DynamicParameters dP = new Dapper.DynamicParameters();
                    dP.Add("IdDepartment", idDepartment);
                    if (idOrderRow != null)
                    {
                        dP.Add("IdOrderRow", idOrderRow);
                    }
                    if (idItem != null)
                    {
                        dP.Add("IdItem", idItem);
                    }
                    // CALL SP : RETURNS A JSON STRING WITH THE JOB PARAMETERS IN COLUMN FORMAT, NOT ROWS
                    string valoriCommessaJson = sp.OneRecordJson("MRP3", dP);
                    var keyValueList = JsonConvert.DeserializeObject<dynamic>(valoriCommessaJson);

                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
    }
}
