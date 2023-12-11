using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
//using Etwin.Filter;
using System.Text.Json;

namespace Etwin1.Controllers
{
   // [OperatorCodeFilter]

    public class DepartmentAccessController : Controller
    {
        #region VARS

        private readonly BlDepartmentAccess blDepartmentAccess = null;

        #endregion

        #region CONSTRUCTOR
        public DepartmentAccessController()
        {
            this.blDepartmentAccess = new BlDepartmentAccess();
        }
        #endregion

        //ETWIN LOCAL METHODS

        #region GET DEPARTMENT ACCESS
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetDepartmentAccess/{idDepartmentAccess}")]
        public async Task<DepartmentAccess> GetDepartmentAccess(int idDepartmentAccess)
        {
            DepartmentAccess departmentAccess = new DepartmentAccess();
            try
            {
                departmentAccess = this.blDepartmentAccess.GetDepartmentAccess(idDepartmentAccess);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return departmentAccess;
        }
        #endregion

        #region GET DEPARTMENT ACCESS BY OPERATOR CODE
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetDepartmentAccess/{OperatorCode}")]
        public IList<DepartmentAccess> GetDepartmentAccess(string OperatorCode)
        {
            IList<DepartmentAccess> lstDepartmentAccess = new List<DepartmentAccess>();
            try
            {
                lstDepartmentAccess = this.blDepartmentAccess.GetDepartmentAccess(OperatorCode);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstDepartmentAccess;
        }
        #endregion

        #region GET ALL DEPARTMENT ACCESS
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetAllDepartmentAccess/")]
        public async Task<IList<DepartmentAccess>> GetAllDepartmentAccesss()
        {
            IList<DepartmentAccess> lstDepartmentAccess = new List<DepartmentAccess>();
            try
            {
                lstDepartmentAccess = this.blDepartmentAccess.GetAllDepartmentAccess();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstDepartmentAccess;
        }
        #endregion

        #region GET MENU JSON LIST

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetMenuJsonList")]
        public string GetMenuJsonList(string MenuId, string Type, string Opcode)
        {
            string s = string.Empty;
            try
            {
                s = this.blDepartmentAccess.GetMenuJsonlist(MenuId, Type, Opcode);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return s;
        }
        #endregion





        //WEB APP METHODS

        #region INDEX
        [HttpGet]
        public IActionResult Index()
        {
            var opcodeValue = HttpContext.Session.GetString("opcode");
            var data = TempData["Key"];
            TempData.Keep("Key");
            return View();
        }
        #endregion

        #region DEPARTMENT VIEW
        [HttpPost]
        public JsonResult DepartmentView()
        {
            var result = this.GetAllDepartmentAccesss();
            return Json(result, new JsonSerializerOptions());
        }
        #endregion

        #region GET MENU LIST
        public IActionResult GetMenuList(string MenuId, string Type)
        {
            var Opcode = HttpContext.Session.GetString("opcode");
            if (!string.IsNullOrEmpty(Opcode))
            {
                JsonResult jr = Json(this.GetMenuJsonList(MenuId, Type, Opcode), new JsonSerializerSettings());
                //return GetMenuJsonlist(MenuId, Type, Opcode);
                return jr;
            }
            else
            {
                //return Json("opcode-empty", new JsonSerializerOptions());
                return Json("opcode-empty", new JsonSerializerSettings());
            }
        }
        #endregion


    }
}