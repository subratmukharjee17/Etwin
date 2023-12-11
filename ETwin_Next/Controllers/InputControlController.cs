using Etwin.BAL.BusinnessLogic;
using Etwin.DAL.Models;
using Etwin.Model;
using LogDll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NuGet.Packaging;
using System.Reflection;
using System.Reflection.Emit;

namespace ETwin_Next.Controllers
{
    public class InputControlController : Controller
    {
        #region VER
        private BlInputControl _blInputControl = null;
        private readonly string _sessionValue;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor 
        public InputControlController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            this._blInputControl = new BlInputControl(_sessionValue);

        }

        #endregion

        #region Methods 
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InputControl(string menuId)
        {
            InputControlPageViewModel inputControlPageViewModel = new InputControlPageViewModel();
            try
            {
                string Opcode = HttpContext.Session.GetString("opcode");
                int? inputControlId = this._blInputControl.GetBIInputControlId(Convert.ToInt32(menuId));
                inputControlPageViewModel = this._blInputControl.GetDynamicPageControlModel(Opcode, _sessionValue, inputControlId);
                TempData["DatabaseTable"] = inputControlPageViewModel.InputControlModel[0].DatabaseTable;
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return View(inputControlPageViewModel);
        }
        [HttpPost]
        public IActionResult SubmitInputControlData(OperatorModel operatorModel)
        {
            bool results = false;
            try
            {
                if (TempData["DatabaseTable"] != null)
                {
                    string tableName = TempData["DatabaseTable"].ToString();
                    results=this._blInputControl.SubmitInputControlData(tableName, operatorModel);
                }

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return Json(results);
        }
        #endregion
    }
}
