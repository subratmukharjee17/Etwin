using Etwin.BAL.BusinnessLogic;
using LogDll;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ETwin_Next.Controllers
{
    public class MenuController : Controller
    {

        //private readonly BlDepartments blDepartments = null;
        private readonly string _sessionValue;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MenuController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            //this.blDepartments = new BlDepartments(_sessionValue);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var opcodeValue = HttpContext.Session.GetString("opcode");
            var data = TempData["Key"];
            TempData.Keep("Key");
            return View();
        }
        public IActionResult GetMenuList(string MenuId, string Type)

        {
            var Opcode = HttpContext.Session.GetString("opcode");
            if (!string.IsNullOrEmpty(Opcode))
            {
                return GetMenuJsonList(MenuId, Type, Opcode,_sessionValue);
              
            }
            else
            {
                return Json("opcode-empty", new JsonSerializerOptions());
            }
        }
        public JsonResult GetMenuJsonList(string MenuId, string Type, string Opcode,string cs)
        {

            dynamic s = null;
            try
            {
                //s = this.blDepartments.GetMenuJsonlist(MenuId, Type, Opcode,_sessionValue,"0");
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return Json(s);
        }

    }
}
