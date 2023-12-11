
using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.ComponentModel;
using System.Linq.Expressions;
using LogDll;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlRibbonPageGroups : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlRibbonPageGroups(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddRibbonPageGroup(RibbonsPageGroup ribbonPageGroup)
        {
            ////clsLog.Info(">>> ADDRIBBONPAGEGROUP - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RibbonPageGroups.Add(ribbonPageGroup);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDRIBBONPAGEGROUP - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> ADDRIBBONPAGEGROUP - FINE");
            }

            return result;
        }


        public IList<RibbonsPageGroup> GetRibbonPageGroups()
        {
            ////clsLog.Info(">>> GETRIBBONPAGEGROUPS - INIZIO");

            IList<RibbonsPageGroup> lstRibbonPageGroups = new List<RibbonsPageGroup>();

            try
            {
                lstRibbonPageGroups = this.unitOfWork.RibbonPageGroups.GetAll(null, null, "").ToList();
                ////clsLog.Info(">>> Record trovati: " + lstRibbonPageGroups.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGEGROUPS - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGEGROUPS - FINE");
            }

            return lstRibbonPageGroups;
        }

        public IList<RibbonsPageGroup> GetRibbonPageGroups(int idRibbonPage)
        {
            ////clsLog.Info(">>> GETRIBBONPAGEGROUPS - INIZIO");
            ////clsLog.Info(">>> idRibbonPage: " + idRibbonPage);

            IList<RibbonsPageGroup> lstRibbonPageGroups = new List<RibbonsPageGroup>();

            try
            {
                Expression<Func<RibbonsPageGroup, bool>> expr = e => e.IdRibbonPage == idRibbonPage;

                lstRibbonPageGroups = this.unitOfWork.RibbonPageGroups.GetAll(expr, null, "").ToList();
                ////clsLog.Info(">>> Record trovati: " + lstRibbonPageGroups.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGEGROUPS - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGEGROUPS - FINE");
            }

            return lstRibbonPageGroups;
        }


        public BindingList<RibbonsPageGroup> GetRibbonPageGroup(string ribbonPageGroupName)
        {
            ////clsLog.Info(">>> GETRIBBONPAGEGROUP - INIZIO");

            IList<RibbonsPageGroup> lstRibbonPageGroups = new List<RibbonsPageGroup>();
            BindingList<RibbonsPageGroup> bindingList = new BindingList<RibbonsPageGroup>();

            try
            {
                Expression<Func<RibbonsPageGroup, bool>> expr = e => e.RibbonPageGroupName == ribbonPageGroupName;

                lstRibbonPageGroups = this.unitOfWork.RibbonPageGroups.GetAll(expr, null, "").ToList();
                bindingList = new BindingList<RibbonsPageGroup>(lstRibbonPageGroups);

            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGEGROUP - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGEGROUP - FINE");
            }

            return bindingList;
        }

        public RibbonsPageGroup GetRibbonPageGroup(int idRibbonPageGroup)
        {
            ////clsLog.Info(">>> GETRIBBONPAGEGROUP - INIZIO");

            RibbonsPageGroup toolbarRibbonGroup = new RibbonsPageGroup();

            try
            {
                //Expression<Func<RibbonPage, bool>> expr = e => e.Id == idRibbonPage;

                toolbarRibbonGroup = this.unitOfWork.RibbonPageGroups.Get(idRibbonPageGroup);
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGEGROUP - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGEGROUP - FINE");
            }

            return toolbarRibbonGroup;
        }

        public int GetRibbonPageGroupId(string name)
        {
            int id = 0;
            RibbonsPageGroup rbn = new RibbonsPageGroup();

            try
            {
                Expression<Func<RibbonsPageGroup, bool>> expr = e => e.RibbonPageGroupTitle == name;
                rbn = this.unitOfWork.RibbonPageGroups.GetFirstOrDefault(expr);
                id = rbn.Id;
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return id;
        }


        public bool UpdateRibbonPageGroup(RibbonsPageGroup toolbarRibbonGroup)
        {
            ////clsLog.Info(">>> UPDATERIBBONPAGEGROUP - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RibbonPageGroups.Update(toolbarRibbonGroup);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATERIBBONPAGEGROUP - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> UPDATERIBBONPAGEGROUP - FINE");
            }

            return result;
        }

        public bool DeleteRibbonPageGroup(RibbonsPageGroup toolbarRibbonGroup)
        {
            ////clsLog.Info(">>> DELETERIBBONPAGEGROUP - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RibbonPageGroups.Remove(toolbarRibbonGroup);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETERIBBONPAGEGROUP - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> DELETERIBBONPAGEGROUP - FINE");
            }

            return result;
        }

       

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
