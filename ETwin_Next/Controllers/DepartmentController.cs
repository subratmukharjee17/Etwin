using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Etwin.Model;
using Etwin.BAL.BusinnessLogic;
using LogDll;
using ETwin.BAL.FixModels;
using Etwin.Model.GlobalModels;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Data;
using DevExpress.Xpo;
using DevExpress.CodeParser;
using System.Reflection.Emit;

namespace ETwin_Next.Controllers
{
	public class DepartmentController : Controller
	{
		#region VARS
		private readonly BlDepartments blDepartments = null;
		private readonly string _sessionValue;
		private readonly string _connectionString;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly DataGridController dataGridController = null;
		#endregion

		#region CONSTRUCTOR
		public DepartmentController(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
			this.blDepartments = new BlDepartments(_sessionValue);

		}
		#endregion

		#region INDEX
		[HttpGet]
		public IActionResult Index(string Active)
		{
			var opcodeValue = HttpContext.Session.GetString("opcode");
			BlOperators blOperators = new BlOperators(HttpContext.Session.GetString("cn"));
			Operator o = blOperators.GetOperatorFromCode(opcodeValue);
			var data = TempData["Key"];
			TempData.Keep("Key");
			return View(o);
		}
		#endregion

		#region DEPARTMENT VIEW
		[HttpPost]
		public JsonResult DepartmentView()
		{
			var result = this.GetAllDepartments();
			return Json(result, new JsonSerializerOptions());
		}
		#endregion

		#region GET DEPARTMENT GRID DATA
		public IActionResult GetDepartmentGridData(string MenuId, string Type)
		{
			dynamic s = null;
			string Opcode = HttpContext.Session.GetString("opcode");
			try
			{
				s = this.blDepartments.GetMenuJsonlist(MenuId, Type, Opcode, _sessionValue, "0");
			}
			catch (Exception ex)
			{
				clsLog.Error(ex.ToString());
			}
			return Json(s);

		}
		#endregion

		#region GET MENU LIST
		public IActionResult GetMenuList(string MenuId, string Type, string idDepartment)

		{
			var Opcode = HttpContext.Session.GetString("opcode");
			if (!string.IsNullOrEmpty(Opcode))
			{
				return GetMenuJsonList(MenuId, Type, Opcode, _sessionValue, idDepartment);
			}
			else
			{
				return Json("opcode-empty", new JsonSerializerOptions());
			}
		}
		#endregion

		#region GET MENU JSON LIST
		public JsonResult GetMenuJsonList(string MenuId, string Type, string Opcode, string cs, string idDepartment)
		{

			dynamic s = null;
			try
			{
				//I get the actions or data from the menu or controls
				s = this.blDepartments.GetMenuJsonlist(MenuId, Type, Opcode, cs, idDepartment);
				if (Type == "6")
				{
					modLeftMenu ml = s;
					if (ml.contrlNme == "GridControl")
					{
						IList<IDictionary<string, string>> columnJson = new List<IDictionary<string, string>>();
						// I run combo queries
						DataGridController dataGridController = new DataGridController(_httpContextAccessor);

						foreach (GridsColumn gc in ml.Columns.Where(x => x.QueryTypeCombo != null))
						{
							string jsonMenuCombo = dataGridController.ExecuteGenericQuery(gc.QueryTypeCombo);
							// Add a new property to the expanded object for this column
							IDictionary<string, string> dct = new Dictionary<string, string>();
							dct.Add(gc.ColumnName, jsonMenuCombo);
							if (dct != null)
							{
								columnJson.Add(dct);
							}
						}

						s = new
						{
							lstDepartment = ml.LstData,
							MenuType = ml.MenuType,
							jsonCombo = columnJson

						};
					}
				}
			}
			catch (Exception ex)
			{
				clsLog.Error(ex.ToString());
			}
			return Json(s);
		}
		#endregion

		#region GET ALL DEPARTMENTS
		public async Task<IList<Department>> GetAllDepartments()
		{
			IList<Department> lstDepartment = new List<Department>();
			try
			{
				lstDepartment = this.blDepartments.GetDepartments();
			}
			catch (Exception ex)
			{
				clsLog.Error(ex.ToString());
			}
			return lstDepartment;
		}
		#endregion

		#region GET SearchBar Search Result

		[HttpPost]
		public ActionResult GetSearchResult(string searchText)
		{
			dynamic result = null;
			try
			{
				var Opcode = HttpContext.Session.GetString("opcode");
				DataTable dataTable = blDepartments.GetAllDepartmentsDataForSearchBar(_sessionValue, Opcode);

				var filteredRows = dataTable.AsEnumerable().Where(row => row.Field<string>("Name").ToLower().Contains(searchText.ToLower())).ToList();

				result = filteredRows.Select(row => new
				{
					Id = row.Field<int>("Id"),
					Name = row.Field<string>("Name"),
					Page = row.Field<string>("Page"),
					IdDepartment = row.Field<string>("IdDepartment")
				}).ToList();
			}
			catch (Exception ex)
			{
				clsLog.Error(ex.ToString());

			}
			return Json(result);

		}
		#endregion
	}
}
