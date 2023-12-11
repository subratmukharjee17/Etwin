using Microsoft.AspNetCore.Mvc;
using LogDll;
using Etwin.Model.Context;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using Etwin.BAL.BusinnessLogic;
using Etwin.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.IO;
using ETwin.BAL.FixModels;
using DevExpress.PivotGrid.ServerMode.OperationGraph;
using Etwin.CLS.GenericClass;
//using Etwin.Filter;


namespace ETwin_Next.Controllers
{
    // [OperatorCodeFilter]
    public class OperatorCompanyController : Controller
    {

        private readonly ETwinContext _data;
        public clsGenericClass clsgeneric = new clsGenericClass();
        private readonly BlOperators blOperators;
        private readonly string _sessionValue;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _cs;

        public OperatorCompanyController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            _data = new ETwinContext(_sessionValue);
            blOperators = new BlOperators(_sessionValue);
          //  _cs = cs;
        }
         
        #region GET ACCOUNT IMAGE
        public IActionResult GetAccountImage(string opCode)
        {
              Etwin.Model.Operator o = this.blOperators.GetOperatorFromCode(opCode);
              return Json(o.AccountImage);
            //return Json(null);
        }
        #endregion

    }
}
