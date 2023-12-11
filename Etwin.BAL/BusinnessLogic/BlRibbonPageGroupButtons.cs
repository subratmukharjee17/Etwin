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
    public class BlRibbonsPageGroupButtons : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlRibbonsPageGroupButtons(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddRibbonsPageGroupButton(RibbonsPageGroupButton toolbarRibbonGroupButton)
        {
            ////clsLog.Info(">>> ADDRIBBONPAGEGROUPBUTTON - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RibbonPageGroupButtons.Add(toolbarRibbonGroupButton);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDRIBBONPAGEGROUPBUTTON - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> ADDRIBBONPAGEGROUPBUTTON - FINE");
            }

            return result;
        }


        public IList<RibbonsPageGroupButton> GetRibbonsPageGroupButtons()
        {
            ////clsLog.Info(">>> GETRIBBONPAGEGROUPBUTTONS - INIZIO");

            IList<RibbonsPageGroupButton> lstRibbonsPageGroupButtons = new List<RibbonsPageGroupButton>();

            try
            {
                lstRibbonsPageGroupButtons = this.unitOfWork.RibbonPageGroupButtons.GetAll(null, null, "").ToList();
                ////clsLog.Info(">>> Record trovati: " + lstRibbonsPageGroupButtons.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGEGROUPBUTTONS - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGEGROUPBUTTONS - FINE");
            }

            return lstRibbonsPageGroupButtons;
        }

        public IList<RibbonsPageGroupButton> GetRibbonsPageGroupButtons(int idRibbonPageGroup)
        {
            ////clsLog.Info(">>> GETRIBBONPAGEGROUPBUTTONS - INIZIO");

            IList<RibbonsPageGroupButton> lstRibbonsPageGroupButtons = new List<RibbonsPageGroupButton>();

            try
            {
                Expression<Func<RibbonsPageGroupButton, bool>> expr = e => e.IdRibbonPageGroup == idRibbonPageGroup;
                
                lstRibbonsPageGroupButtons = this.unitOfWork.RibbonPageGroupButtons.GetAll(expr, null, "").ToList();
                ////clsLog.Info(">>> Record trovati: " + lstRibbonsPageGroupButtons.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGEGROUPBUTTONS - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGEGROUPBUTTONS - FINE");
            }

            return lstRibbonsPageGroupButtons;
        }


        public BindingList<RibbonsPageGroupButton> GetRibbonsPageGroupButton(string toolbarRibbonGroupButtonName)
        {
            ////clsLog.Info(">>> GETRIBBONPAGEGROUPBUTTON - INIZIO");

            IList<RibbonsPageGroupButton> lstRibbonsPageGroupButtons = new List<RibbonsPageGroupButton>();
            BindingList<RibbonsPageGroupButton> bindingList = new BindingList<RibbonsPageGroupButton>();

            try
            {
                Expression<Func<RibbonsPageGroupButton, bool>> expr = e => e.RibbonPageGroupButtonName == toolbarRibbonGroupButtonName;

                lstRibbonsPageGroupButtons = this.unitOfWork.RibbonPageGroupButtons.GetAll(expr, null, "").ToList();
                bindingList = new BindingList<RibbonsPageGroupButton>(lstRibbonsPageGroupButtons);

            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGEGROUPBUTTON - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGEGROUPBUTTON - FINE");
            }

            return bindingList;
        }

        public RibbonsPageGroupButton GetRibbonsPageGroupButton(int idRibbonsPageGroupButton)
        {
            ////clsLog.Info(">>> GETRIBBONPAGEGROUPBUTTON - INIZIO");

            RibbonsPageGroupButton toolbarRibbonGroupButton = new RibbonsPageGroupButton();

            try
            {
                //Expression<Func<RibbonPage, bool>> expr = e => e.Id == idRibbonPage;

                toolbarRibbonGroupButton = this.unitOfWork.RibbonPageGroupButtons.Get(idRibbonsPageGroupButton);
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGEGROUPBUTTON - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGEGROUPBUTTON - FINE");
            }

            return toolbarRibbonGroupButton;
        }


        public bool UpdateRibbonsPageGroupButton(RibbonsPageGroupButton toolbarRibbonGroupButton)
        {
            ////clsLog.Info(">>> UPDATERIBBONPAGEGROUPBUTTON - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RibbonPageGroupButtons.Update(toolbarRibbonGroupButton);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATERIBBONPAGEGROUPBUTTON - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> UPDATERIBBONPAGEGROUPBUTTON - FINE");
            }

            return result;
        }

        public bool DeleteRibbonsPageGroupButton(RibbonsPageGroupButton toolbarRibbonGroupButton)
        {
            ////clsLog.Info(">>> DELETERIBBONPAGEGROUPBUTTON - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RibbonPageGroupButtons.Remove(toolbarRibbonGroupButton);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETERIBBONPAGEGROUPBUTTON - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> DELETERIBBONPAGEGROUPBUTTON - FINE");
            }

            return result;
        }

        #region GET RIBBON BUTTON BY ID
        public RibbonsPageGroupButton GetRibbonPageButtonById(int idRibbonPageGroupButton)
        {
            ////clsLog.Info(">>> GETRIBBONPAGEGROUPBUTTONS - INIZIO");

            RibbonsPageGroupButton ribbonsPageGroupButtons = new RibbonsPageGroupButton();

            try
            {
                Expression<Func<RibbonsPageGroupButton, bool>> expr = e => e.Id == idRibbonPageGroupButton;

                ribbonsPageGroupButtons = this.unitOfWork.RibbonPageGroupButtons.GetFirstOrDefault(expr);
                ////clsLog.Info(">>> Record trovati: " + lstRibbonsPageGroupButtons.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGEGROUPBUTTONS - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGEGROUPBUTTONS - FINE");
            }

            return ribbonsPageGroupButtons;
        }
        #endregion

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
