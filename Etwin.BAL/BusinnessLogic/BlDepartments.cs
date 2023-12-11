using System.Collections.Generic;
using System.Linq;
using Etwin.Model;
using System.ComponentModel;
using LogDll;
using System.Linq.Expressions;
using Etwin.Model.Context;
using Newtonsoft.Json;
using Etwin.DAL.Models;
using System.Data;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using ETwin.BAL.FixModels;
using Etwin.BAL.BusinnessLogic.BLGenericDB;
using Etwin.Model.GlobalModels;
using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.DAL.GlobalDataRepository;
using System;
using ETwin.Helper.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlDepartments : IDisposable
    {
        IUnitOfWork GlobalUnitOfWork = null;
        DAL.DataRepository.IRepository.IUnitOfWork EtwinUnitOfWork = null;
        private readonly GlobalDbContext _dbGlobal;
        private readonly ETwinContext _dbEtwin;
        string IdAmbito = "0";

        public BlDepartments(string cs = "")
        {
            this._dbGlobal = new GlobalDbContext();
            this._dbEtwin = new ETwinContext(cs);
            this.GlobalUnitOfWork = new UnitOfWork(_dbGlobal);
            this.EtwinUnitOfWork = new DAL.DataRepository.UnitOfWork(_dbEtwin);
        }

        #region Authentication
        public BindingList<Department> GetDepartment(int idDepartment)
        {
            IList<Department> lstDepartment = new List<Department>();
            BindingList<Department> bindingListDepartment = new BindingList<Department>();
            try
            {
                Expression<Func<Department, bool>> expr = e => e.IdDepartment == idDepartment;

                lstDepartment = this.GlobalUnitOfWork.Departments.GetAll(expr).ToList();
                bindingListDepartment = new BindingList<Department>(lstDepartment);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListDepartment;
        }

        public IList<Department> GetDepartments()
        {
            IList<Department> lstDepartment = new List<Department>();
            try
            {
                lstDepartment = this.GlobalUnitOfWork.Departments.GetAll().ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstDepartment;
        }


        public Object GetDepartmentAccess(string OperatorCode)
        {
            IList<DepartmentAccess> lstDepartmentAccess = new List<DepartmentAccess>();
            IList<Department> lstDepartment = new List<Department>();
            BlMaterialDb blMaterial = new BlMaterialDb();
            IList<modGlobalDepartments> lstGlobalDepartment = blMaterial.GetGlobalDepartment();


            dynamic joinedList = null;

            try
            {
                Expression<Func<DepartmentAccess, bool>> expr = e => e.OperatorCode == OperatorCode;
                lstDepartmentAccess = this.EtwinUnitOfWork.DepartmentAccess.GetAll(expr, null, null).ToList();

                lstDepartment = this.GlobalUnitOfWork.Departments.GetAll().ToList();

                joinedList = (from department in lstDepartment
                              join departmentAccess in lstDepartmentAccess
                              on department.IdDepartment equals departmentAccess.IdDepartment
                              join globalDepartment in lstGlobalDepartment
                              on department.Name equals globalDepartment.Name
                              select new modGlobalDepartments
                              {
                                  IdDepartment = department.IdDepartment,
                                  Name = department.Name,
                                  Description = department.Description,
                                  IconName = globalDepartment.IconName
                              });

            }
            catch (Exception ex)
            {
                clsLog.Error("GETOPERATOR - Error: " + ex.ToString());
            }

            return joinedList;
        }
        #endregion

        #region LeftMenu
        public Object GetByIdRibbonPage(int id)
        {
            dynamic joinedList = null;

            IList<RibbonsPageGroup> lstRibbonsPageGroup = new List<RibbonsPageGroup>();
            IList<RibbonsPage> lstRibbonPage = new List<RibbonsPage>();

            lstRibbonsPageGroup = this.EtwinUnitOfWork.RibbonPageGroups.GetAll().ToList();
            lstRibbonPage = this.EtwinUnitOfWork.RibbonPages.GetAll().ToList();



            joinedList = from rpg in lstRibbonsPageGroup
                         where rpg.IdRibbonPage == (from rp in lstRibbonPage
                                                    where rp.IdDepartment == id
                                                    select rp.Id).FirstOrDefault()
                         select rpg;

            return joinedList;

        }

        public Object GetByIdRibbonPage1(int id)
        {

            IList<RibbonsPageGroup> lstRibbonsPageGroup = new List<RibbonsPageGroup>();
            IList<RibbonsPage> lstRibbonPage = new List<RibbonsPage>();

            lstRibbonsPageGroup = this.EtwinUnitOfWork.RibbonPageGroups.GetAll().ToList();
            lstRibbonPage = this.EtwinUnitOfWork.RibbonPages.GetAll().ToList();



            var joinedList = from rpg in lstRibbonsPageGroup
                             where rpg.IdRibbonPage == (from rp in lstRibbonPage
                                                        where rp.IdDepartment == id
                                                        select rp.Id).FirstOrDefault()
                             select rpg;

            return joinedList;
        }


        public Object RibbonsPageGroupButtonsById(int id)
        {
            IList<RibbonsPageGroupButton> lstRibbonsPageGroupButton = new List<RibbonsPageGroupButton>();
            //Expression<Func<RibbonsPageGroupButton, bool>> expr = e => e.Id == id;

            lstRibbonsPageGroupButton = this.EtwinUnitOfWork.RibbonPageGroupButtons.GetAll().ToList();

            var query = from o in lstRibbonsPageGroupButton
                        where o.IdRibbonPageGroup == id
                        select o;
            return query;
        }

        public Object GetControlTypeAndQueryDetails(string storedProcedureName, int ribbonPageGroupId)
        {

            Dapper.DynamicParameters parameters = new Dapper.DynamicParameters();
            parameters.Add("RibbonPageGroupId", ribbonPageGroupId);
            var result = this.EtwinUnitOfWork.SP_Call.List<ReportModeList>(storedProcedureName, parameters).FirstOrDefault();
            return result;
        }
        #endregion

        #region Grid and Chart
        public Object ReportPhaseModel(string sqlQuery)

        {
            dynamic d = new ExpandoObject();
            IList<ExpandoObject> result = new List<ExpandoObject>();
            try
            {
                Dapper.DynamicParameters parameters = new Dapper.DynamicParameters();
                if (sqlQuery.Contains("exec"))
                {

                    parameters.Add("idAmbito", Convert.ToInt32(sqlQuery.Split(" ").GetValue(2).ToString()));
                    d = this.EtwinUnitOfWork.SP_Call.List<dynamic>(sqlQuery.Split(" ").GetValue(1).ToString(), parameters).ToList();

                }
                else
                {
                    d = this.EtwinUnitOfWork.QUERY_Call.List<dynamic>(sqlQuery.ToString(), parameters).ToList();
                }
                /*Create dynamic model*/
                string jsonResult = JsonConvert.SerializeObject(d);
                if (!string.IsNullOrEmpty(jsonResult) && jsonResult != "[]")
                {
                    IList<JObject> jobject = JsonConvert.DeserializeObject<IList<JObject>>(jsonResult);
                    if (jobject != null && jobject.Count > 0)
                    {
                        IList<JProperty> lstJProperties = jobject.Properties().ToList();
                        dynamic model = new ExpandoObject();
                        foreach (JProperty jProperty in lstJProperties)
                        {
                            clsDynamicClass.AddProperty(model, jProperty.Name.ToLower(), jProperty.Value);
                            if (jProperty.Next == null)
                            {
                                //Finished to analyzed row properties
                                result.Add(model);
                                model = new ExpandoObject();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            //return result.ToList();
            return result;
        }
        public Object ReportChartModel(string sqlQuery, string param = null, string cs = null)
        {

            var result = new List<ReportChartModeList>();
            Dapper.DynamicParameters parameters = new Dapper.DynamicParameters();
            if (sqlQuery.Contains("exec"))
            {

                parameters.Add("idAmbito", Convert.ToInt32(sqlQuery.Split(" ").GetValue(2).ToString()));
                result = this.EtwinUnitOfWork.SP_Call.List<ReportChartModeList>(sqlQuery.Split(" ").GetValue(1).ToString(), parameters).ToList();

            }
            else
            {
                result = this.EtwinUnitOfWork.QUERY_Call.List<ReportChartModeList>(sqlQuery.ToString(), parameters).ToList();
            }
            return result.ToList();
        }
        public Object GetBandDetails(int Id)
        {
            var lstBand = this.EtwinUnitOfWork.Band.GetAll(i => i.IdGrid == Id).ToList();
            return lstBand;
        }
        public IList<GridsColumn> GetGridColumnDetails(int Id)
        {
            List<GridsColumn> lstGridsColumns = new List<GridsColumn>();
            List<GridBand> lstBands = new List<GridBand>();
            lstGridsColumns = this.EtwinUnitOfWork.GridsColumns.GetAll().ToList();
            lstBands = this.EtwinUnitOfWork.Band.GetAll().ToList();

            var joinedList = lstGridsColumns
             .Join(lstBands.Where(grid => grid.IdGrid == Id), column => column.IdBand, grid => grid.Id, (column, grid) => column)
             .ToList();
            var submenu = joinedList.ToList();

            return submenu;
        }


        public Object GetChartName(int IdControl)
        {
            IList<Chart> lstChartSeries = new List<Chart>();
            lstChartSeries = this.EtwinUnitOfWork.Chart.GetAll().ToList();
            var joinedList = from chart in lstChartSeries
                             where chart.Id == IdControl
                             select chart.ChartName;
            return joinedList.ToList().FirstOrDefault();
        }

        #endregion


        public dynamic GetMenuJsonlist(string MenuId, string Type, string Opcode, string cs, string idDepartment)
        {
            string jsonresult = null;
            try
            {
                int idmenu = int.Parse(MenuId);
                int intType = int.Parse(Type);

                //Check if the id matches the timebound
                if (Type == "6")
                {
                    RibbonsPageGroupButton rpgb = null;
                    using (BlRibbonsPageGroupButtons blButton = new BlRibbonsPageGroupButtons(cs))
                    {
                        rpgb = blButton.GetRibbonPageButtonById(idmenu);
                        if (rpgb != null && rpgb.RibbonPageGroupButtonName.Equals("TimeBound"))
                        {
                            var lstDepartment = this.RibbonsPageGroupButtonsById(Convert.ToInt32(MenuId));
                            //var MenuDet = new { lstDepartment, MenuType = "6", page = "TimeBound" };
                            modLeftMenu leftMenuModel = new modLeftMenu()
                            {
                                LstData = lstDepartment,
                                MenuType = "6",
                                contrlNme = "TimeBound",
                            };
                            return leftMenuModel;
                        }
                        else if (rpgb != null && rpgb.IdControlType == 14)
                        {
                            var lstDepartment = this.RibbonsPageGroupButtonsById(Convert.ToInt32(MenuId));

                            modLeftMenu leftMenuModel = new modLeftMenu()
                            {
                                LstData = lstDepartment,
                                MenuType = "6",
                                contrlNme = "InputControl"
                            };
                            //var MenuDet = new { lstDepartment, MenuType = "6", page = "InputControl" }; // 3rd menu cjild item
                            return leftMenuModel;
                        }
                    }
                }

                if ((idmenu == 0 && intType == 0 && !string.IsNullOrEmpty(Opcode)) || intType == 5)
                {
                    //If it is the first menu I take the enabled Departments
                    Object lstDepartment = this.GetDepartmentAccess(Opcode);
                    var MenuDet = new { lstDepartment, MenuType = "1" };
                    return MenuDet;
                }
                else if (intType == 1 || intType == 4)
                {
                    //If it's the second menu I take the groups
                    Object lstDepartment = this.GetByIdRibbonPage1(Convert.ToInt32(MenuId));
                    var MenuDet = new { lstDepartment, MenuType = "2" };// 2ndlevel menu cjild item
                    return MenuDet;
                }
                else if (intType == 2)
                {
                    //if it's the third menu I take the last levels
                    var lstDepartment = this.RibbonsPageGroupButtonsById(Convert.ToInt32(MenuId));
                    var MenuDet = new { lstDepartment, MenuType = "6" }; // 3rd menu cjild item
                    return MenuDet;
                }


                else if (intType == 6)
                {
                    //Grid Level
                    dynamic result = this.GetControlTypeAndQueryDetails("dbo.spGetRibbonPageGroupButtonData", Convert.ToInt32(MenuId));// Convert.ToInt32(Convert.ToInt32("266"))
                    if (result == null)
                        return "PNF";
                    var contrlNme = ((ReportModeList)result).ControlName;
                    var sqlqury = "";
                    sqlqury = ((ReportModeList)result).SqlQuery;
                    if (((ReportModeList)result).SqlQuery.Contains("#AMBITO#"))
                    {
                        sqlqury = ((ReportModeList)result).SqlQuery.Replace("#AMBITO#", idDepartment);
                    }

                    int Idcontrol = Convert.ToInt32(((ReportModeList)result).IdControl);
                    int Idcontroltype = Convert.ToInt32(((ReportModeList)result).IdControlType);
                    bool treeList = false;
                    if (((ReportModeList)result).TreeList != null)
                    {
                        treeList = (bool)((ReportModeList)result).TreeList;
                    }
                    string allowDragDrop = "";
                    if (!string.IsNullOrEmpty(((ReportModeList)result).AllowDragDrop))
                    {
                        allowDragDrop = ((ReportModeList)result).AllowDragDrop;
                    }
                    else
                    {
                        //View not found, nothing load
                        clsLog.Error("View not found");
                    }

                    if (contrlNme == "GridControl")
                    {
                        //load data
                        var results = this.ReportPhaseModel(sqlqury);
                        //Load Band
                        var lstBand = this.GetBandDetails(Idcontrol);

                        //Load GridColumn
                        IList<GridsColumn> lstColumn = this.GetGridColumnDetails(Idcontrol);


                        dynamic lstDepartment = new
                        {
                            Data = results,
                            GridBands = lstBand,
                            GridColumns = lstColumn,
                            MenuType = "8",
                            treeList = treeList,
                            AllowDragDrop = allowDragDrop,
                        };
                        modLeftMenu leftMenuModel = new modLeftMenu()
                        {
                            LstData = lstDepartment,
                            MenuType = "8",
                            Columns = lstColumn.Where(x => x.QueryTypeCombo != null).ToList<GridsColumn>(),
                            contrlNme = contrlNme,
                        };
                        return leftMenuModel;
                    }
                    else if (contrlNme == "ChartControl")
                    {
                        var chartname = this.GetChartName(Idcontrol);
                        var lstDepartment = this.ReportChartModel(sqlqury, null, cs);
                        modLeftMenu leftMenuModel = new modLeftMenu()
                        {
                            LstData = lstDepartment,
                            MenuType = "7",
                            contrlNme = contrlNme,
                        };
                        return leftMenuModel;
                    }
                    else if (contrlNme == "SchedulerControl")
                    {
                        using (BlSchedulers blSchedulers = new BlSchedulers(cs))
                        {
                            using (BlSchedulerAppointment blSchedulerAppointment = new BlSchedulerAppointment(cs))
                            {
                                using (BlSchedulerResource blSchedulerResource = new BlSchedulerResource(cs))
                                {
                                    var schedulerName = blSchedulers.GetScheduler(Idcontrol);
                                    SchedularViewModel schedularViewModel = new SchedularViewModel();
                                    schedularViewModel.ClsschedulerAppointmentMapping = blSchedulerAppointment.GetSchedulerAppointment(schedulerName.Id);
                                    schedularViewModel.ClsschedulerResourceMapping = blSchedulerResource.GetSchedulerResources(schedulerName.Id);
                                    using (BlGeneric blGeneric = new BlGeneric(cs))
                                    {
                                        //Appointement
                                        SchedulerAppointmentMapping appointment = schedularViewModel.ClsschedulerAppointmentMapping[0];
                                        var appointmentData = blGeneric.ExecuteSqlQuery<object>(appointment.QueryDatasource);
                                        //Resources
                                        SchedulerResourceMapping resource = schedularViewModel.ClsschedulerResourceMapping[0];
                                        var resourceData = blGeneric.ExecuteSqlQuery<object>(resource.QueryDatasource);

                                        dynamic lstDepartment = new
                                        {
                                            Schedulersettings = schedulerName,
                                            Appointments = appointmentData,
                                            Resources = resourceData,
                                            MenuType = "9",
                                        };
                                        modLeftMenu leftMenuModel = new modLeftMenu()
                                        {
                                            LstData = lstDepartment,
                                            MenuType = "9",
                                            contrlNme = contrlNme,
                                        };
                                        return leftMenuModel;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        jsonresult = JsonConvert.SerializeObject("opcode-empty'");

                    }
                    if (intType == 4)
                    {
                        using (BlRibbonPageGroups blRibbonPageGroup = new BlRibbonPageGroups())
                        {
                            var lstRibbonPageGroups = blRibbonPageGroup.GetRibbonPageGroups(idmenu);
                            var MenuDet = new { lstRibbonPageGroups, MenuType = "4" };
                            jsonresult = JsonConvert.SerializeObject(MenuDet);
                        }
                    }
                    else if (intType == 5)
                    {
                        Object lstDepartment = this.GetDepartmentAccess(Opcode);
                        var MenuDet = new { lstDepartment, MenuType = "1" };
                        jsonresult = JsonConvert.SerializeObject(lstDepartment);
                    }
                }
                // }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
                jsonresult = JsonConvert.SerializeObject("An error occurred");
            }
            return jsonresult;
        }

        #region SearchBar
        public DataTable GetAllDepartmentsDataForSearchBar(string cs, string Opcode)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Page", typeof(string));
            dataTable.Columns.Add("IdDepartment", typeof(string));
            try
            {
                var result = this.GetDepartmentAccess(Opcode);
                IList<int> lstAccess = new List<int>();
                if (result is IEnumerable<modGlobalDepartments> lstRibbonPages)
                {
                    foreach (var ribbonPages in lstRibbonPages)
                    {
                        lstAccess.Add(ribbonPages.IdDepartment);
                    }
                }
                IList<int> lstAccessGroup = new List<int>();
                IList<RibbonsPageGroup> lstRibbonPageGroups = new List<RibbonsPageGroup>();
                IList<RibbonsPageGroup> filteredRibbonPageGroups = new List<RibbonsPageGroup>();
                using (BlRibbonPageGroups blRibbonPageGroup = new BlRibbonPageGroups(cs))
                {
                    lstRibbonPageGroups = blRibbonPageGroup.GetRibbonPageGroups();

                    // Filter lstRibbonPageGroups based on IdDepartment values in dataTable
                    filteredRibbonPageGroups = lstRibbonPageGroups.Where(item => lstAccess.Contains(item.IdRibbonPage)).ToList();
                    foreach (var i in filteredRibbonPageGroups)
                    {
                        lstAccessGroup.Add(i.Id);
                    }
                }
                using (BlRibbonsPageGroupButtons blRibbonPageGroupButtons = new BlRibbonsPageGroupButtons(cs))
                {
                    var lstRibbonPageGroupButtons = blRibbonPageGroupButtons.GetRibbonsPageGroupButtons();
                    var filteredRibbonPageGroupButtons = lstRibbonPageGroupButtons.Where(item => lstAccessGroup.Contains(item.IdRibbonPageGroup));
                    BlRibbonPages blRibbonPages = new BlRibbonPages(cs);
                    IList<RibbonsPage> page = blRibbonPages.GetRibbonPages();

                    foreach (var item in filteredRibbonPageGroupButtons)
                    {

                        int idPage = filteredRibbonPageGroups.Where(x => x.Id == item.IdRibbonPageGroup).First().IdRibbonPage;


                        dataTable.Rows.Add(item.Id, item.RibbonPageGroupButtonTitle, page.Where(x=>x.Id == idPage).First().RibbonPageTitle, page.Where(x => x.Id == idPage).First().IdDepartment);


                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return dataTable;
        }
        #endregion


        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
