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
    public class ThemeController : Controller
    {

        private readonly ETwinContext _data;
        public clsGenericClass clsgeneric = new clsGenericClass();
        private readonly BlCompanyTheme blCompanyTheme;
        private readonly string _sessionValue;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _cs;
        public class Tema
        {
            public string name { get; set; }
            public string theme { get; set; }
        }

        public ThemeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            _data = new ETwinContext(_sessionValue);
            blCompanyTheme = new BlCompanyTheme(_sessionValue);
            //  _cs = cs;
        }

        public IList<Tema> GetAllTheme()
        {
            IList<Tema> temi = new List<Tema>();
            try
            {//I take all the themes to database
                IList<CompanyTheme> theme = blCompanyTheme.GetCompanyTheme();
                foreach (CompanyTheme themeItem in theme)
                {
                    Tema t = new Tema();
                    t.name = themeItem.ThemeName;
                    t.theme = themeItem.ThemeClass;
                    temi.Add(t);
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return temi;
        }

    }
}
