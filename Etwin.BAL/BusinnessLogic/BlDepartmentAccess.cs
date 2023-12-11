using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using Etwin.Model.Context;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ETwin.BAL.FixModels;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlDepartmentAccess : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlDepartmentAccess(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public DepartmentAccess GetDepartmentAccess(int idDepartmentAccess)
        {
            //clsLog.Info(">>> GETOPERATORE - INIZIO");

            DepartmentAccess departmentAccess = new DepartmentAccess();
            try
            {
                Expression<Func<DepartmentAccess, bool>> expr = e => e.IdDepartmentAccess == idDepartmentAccess;

                departmentAccess = this.unitOfWork.DepartmentAccess.GetFirstOrDefault(expr, "");
            }
            catch (Exception ex)
            {
                departmentAccess = null;
                clsLog.Error("GETOPERATORE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETOPERATORE - FINE");
            }

            return departmentAccess;
        }

        public IList<DepartmentAccess> GetDepartmentAccess(string OperatorCode)
        {
            //clsLog.Info(">>> GETOPERATOR - INIZIO");

            IList<DepartmentAccess> lstDepartmentAccess = new List<DepartmentAccess>();

            try
            {
                Expression<Func<DepartmentAccess, bool>> expr = e => e.OperatorCode == OperatorCode;
                lstDepartmentAccess = this.unitOfWork.DepartmentAccess.GetAll(expr, null, null).ToList();
                //clsLog.Info(">>> Record trovati: " + lstOperator.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETOPERATOR - Error: " + ex.ToString());
            }

            return lstDepartmentAccess;
        }


        public IList<DepartmentAccess> GetAllDepartmentAccess()
        {
            //clsLog.Info(">>> GETOPERATOR - INIZIO");

            IList<DepartmentAccess> lstDepartmentAccess = new List<DepartmentAccess>();

            try
            {
                lstDepartmentAccess = this.unitOfWork.DepartmentAccess.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstOperator.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETOPERATOR - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETOPERATOR - FINE");
            }

            return lstDepartmentAccess;
        }

        public string GetMenuJsonlist(string MenuId, string Type, string Opcode)
        {
            string jsonresult = null;
            try
            {
                int idmenu = int.Parse(MenuId);
                int intType = int.Parse(Type);

                if (idmenu == 0 && intType == 0 && !string.IsNullOrEmpty(Opcode))
                {
                    IList<DepartmentAccess> lstDepartment = this.GetDepartmentAccess(Opcode);
                    modMenuDetailDepartment MenuDet = new modMenuDetailDepartment()
                    {
                        LstDepartmentAccess = lstDepartment,
                        MenuId = "1"
                    };
                    jsonresult = JsonConvert.SerializeObject(MenuDet);
                }
                else if (intType == 1)
                {
                    using (BlRibbonPages blRibbonPages = new BlRibbonPages())
                    {
                        var lstRibbonPage = blRibbonPages.GetRibbonPageByDepartment(idmenu);
                        var MenuDet = new { lstRibbonPage, MenuType = "3" };
                        jsonresult = JsonConvert.SerializeObject(MenuDet);
                    }
                }
                else if (intType == 3)
                {
                    using (BlRibbonPageGroups blRibbonPageGroups = new BlRibbonPageGroups())
                    {
                        var lstRibbonPageGroup = blRibbonPageGroups.GetRibbonPageGroups(idmenu);
                        var MenuDet = new { lstRibbonPageGroup, MenuType = "6" }; // 3rd menu cjild item
                        jsonresult = JsonConvert.SerializeObject(MenuDet);
                    }
                }
                //else if (intType == 4)
                //{

                //}
                //else if (intType == 5)
                //{

                //}
                //else if (intType == 6)
                //{

                //}
                else
                {
                    jsonresult = JsonConvert.SerializeObject("No Data");
                }

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
                jsonresult = JsonConvert.SerializeObject("An error occurred");
            }
            return jsonresult;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
