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
using System.Threading.Tasks;
using System.Data.Entity.Core.Mapping;
using Org.BouncyCastle.Asn1.X500;
using System.Xml.Linq;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlRibbonPages : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlRibbonPages(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddRibbonPage(RibbonsPage ribbonPage)
        {
            ////clsLog.Info(">>> ADDRIBBONPAGE - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RibbonPages.Add(ribbonPage);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDRIBBONPAGE - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> ADDRIBBONPAGE - FINE");
            }

            return result;
        }

        public IList<RibbonsPage> GetRibbonPages()
        {
            ////clsLog.Info(">>> GETRIBBONPAGES - INIZIO");

            IList<RibbonsPage> lstRibbonPages = new List<RibbonsPage>();

            try
            {
                lstRibbonPages = this.unitOfWork.RibbonPages.GetAll(null, null, "").ToList();
                ////clsLog.Info(">>> Record trovati: " + lstRibbonPages.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGES - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGES - FINE");
            }

            return lstRibbonPages;
        }


        public BindingList<RibbonsPage> GetRibbonPage(string ribbonPageName)
        {
            ////clsLog.Info(">>> GETRIBBONPAGE - INIZIO");

            IList<RibbonsPage> lstRibbonPages = new List<RibbonsPage>();
            BindingList<RibbonsPage> bindingList = new BindingList<RibbonsPage>();

            try
            {
                Expression<Func<RibbonsPage, bool>> expr = e => e.RibbonPageName == ribbonPageName;

                lstRibbonPages = this.unitOfWork.RibbonPages.GetAll(expr, null, "").ToList();
                bindingList = new BindingList<RibbonsPage>(lstRibbonPages);

            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGE - Error: " + ex.ToString());
            }
            return bindingList;
        }

        public async Task<RibbonsPage> GetRibbonPageByDepartment(int idDepartment)
        {
            RibbonsPage rp = new RibbonsPage();
            try
            {
                Expression<Func<RibbonsPage, bool>> expr = e => e.IdDepartment == idDepartment;

                rp = this.unitOfWork.RibbonPages.GetFirstOrDefault(expr);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return rp;
        }

        public RibbonsPage GetRibbonPage(int idRibbonPage)
        {
            ////clsLog.Info(">>> GETRIBBONPAGE - INIZIO");

            RibbonsPage toolbarRibbon = new RibbonsPage();

            try
            {
                //Expression<Func<RibbonPage, bool>> expr = e => e.Id == idRibbonPage;

                toolbarRibbon = this.unitOfWork.RibbonPages.Get(idRibbonPage);
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGE - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> GETRIBBONPAGE - FINE");
            }

            return toolbarRibbon;
        }

        public int GetRibbonPageId(string name)
        {
            int id = 0;
            RibbonsPage rbn = new RibbonsPage();

            try
            {
                Expression<Func<RibbonsPage, bool>> expr = e => e.RibbonPageTitle == name;
                rbn = this.unitOfWork.RibbonPages.GetFirstOrDefault(expr);
                id = rbn.Id;
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRIBBONPAGE - Error: " + ex.ToString());
            }

            return id;
        }

        public bool UpdateRibbonPage(RibbonsPage ribbonPage)
        {
            ////clsLog.Info(">>> UPDATERIBBONPAGE - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RibbonPages.Update(ribbonPage);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATERIBBONPAGE - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> UPDATERIBBONPAGE - FINE");
            }

            return result;
        }

        public bool DeleteRibbonPage(RibbonsPage ribbonPage)
        {
            ////clsLog.Info(">>> DELETERIBBONPAGE - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.RibbonPages.Remove(ribbonPage);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETERIBBONPAGE - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> DELETERIBBONPAGE - FINE");
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
