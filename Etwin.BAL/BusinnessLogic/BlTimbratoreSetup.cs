using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using Etwin.Model.Context;
using ETwin.Helper.Utilities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Dynamic;
using Etwin.DAL.Models;
using ETwin.BAL.FixModels;
using Dapper;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlTimbratoreSetup : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlTimbratoreSetup(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddTimbratoreSetup(TimbratoreSetup timbratoreSetup)
        {
            //clsLog.Info(">>> ADDTimbratoreSetup - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.TimbratoreSetup.Add(timbratoreSetup);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDTimbratoreSetup - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADDTimbratoreSetup - FINE");
            }

            return result;
        }


        public IList<TimbratoreSetup> GetTimbratoreSetup(int? idTimbratoreSetup = null)
        {
            //clsLog.Info(">>> GETTimbratoreSetup - INIZIO");

            IList<TimbratoreSetup> lstTimbratoreSetup = new List<TimbratoreSetup>();

            try
            {
                Expression<Func<TimbratoreSetup, bool>> expr = null;
                if (idTimbratoreSetup != null)
                {
                    expr = e => e.IdTimbratoreSetup == idTimbratoreSetup;
                }

                lstTimbratoreSetup = this.unitOfWork.TimbratoreSetup.GetAll(expr, null, "").ToList();
               // var result = this.unitOfWork.SP_Call.List<modTimbratore>(storedProcedureName, parameters).FirstOrDefault();
                //clsLog.Info(">>> Record trovati: " + lstTimbratoreSetup.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETTimbratoreSetup - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETTimbratoreSetup - FINE");
            }

            return lstTimbratoreSetup;
        }

        //public object GetOperators(string storedProcedureName, string parameters)
        //{
        //    using (BlGeneric blGeneric = new BlGeneric())
        //    {
        //        lstTimbratore = blGeneric.ExecuteSqlQuery<modTimbratore>(this.SqlQuery);
        //    }


        //    return null; 
        //}    

        public TimbratoreSetup GetChildLevel(int idparent)
        {
            TimbratoreSetup timbratoreSetup = new TimbratoreSetup();

            try
            {
                Expression<Func<TimbratoreSetup, bool>> expr = e => e.IdParent == idparent;
                timbratoreSetup = this.unitOfWork.TimbratoreSetup.GetFirstOrDefault(expr, "");
            }
            catch (Exception ex)
            {
                clsLog.Error("GETTimbratoreSetup - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETTimbratoreSetup - FINE");
            }

            return timbratoreSetup;
        }

        public TimbratoreSetup GetTimbratoreSetup(int idTimbratoreSetup)
        {
            //clsLog.Info(">>> GETTimbratoreSetup - INIZIO");

            TimbratoreSetup timbratoreSetup = new TimbratoreSetup();

            try
            {
                timbratoreSetup = this.unitOfWork.TimbratoreSetup.Get(idTimbratoreSetup);
            }
            catch (Exception ex)
            {
                clsLog.Error("GETTimbratoreSetup - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETTimbratoreSetup - FINE");
            }

            return timbratoreSetup;
        }


        public bool UpdateTimbratoreSetup(TimbratoreSetup timbratoreSetup)
        {
            //clsLog.Info(">>> UPDATETimbratoreSetup - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.TimbratoreSetup.Update(timbratoreSetup);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATETimbratoreSetup - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATEtimbratoreSetup - FINE");
            }

            return result;
        }

        public TimbratoreSetup GetLevelByName(string name)
        {

            TimbratoreSetup timbSetup = new TimbratoreSetup();

            try
            {
                Expression<Func<TimbratoreSetup, bool>> expr = e => e.PageName == name;
                timbSetup = this.unitOfWork.TimbratoreSetup.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error("GetLevelByName - Error: " + ex.ToString());
            }
            return timbSetup;
        }

        public bool DeleteTimbratoreSetup(TimbratoreSetup timbratoreSetup)
        {
            //clsLog.Info(">>> DELETETimbratoreSetup - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.TimbratoreSetup.Remove(timbratoreSetup);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETETimbratoreSetup - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETETimbratoreSetup - FINE");
            }

            return result;
        }
        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }


        public ExpandoObject GetDeclarationDynamicModel()
        {
            //DICHIARAZIONE MODELLO DINAMICO
            ExpandoObject declarationModel = new ExpandoObject();

            try
            {
                //PRENDO LA LISTA DELLE PROPRIETA'
                IList<JProperty> lstJProperties = new List<JProperty>();
                using (SP_Call spCall = new SP_Call(this._db))
                {
                    string declarationValue = spCall.OneRecordJson("spGetModelDeclarations");
                    if (!string.IsNullOrEmpty(declarationValue) && declarationValue != "[]")
                    {
                        IList<JObject> parameter = JsonConvert.DeserializeObject<IList<JObject>>(declarationValue);
                        lstJProperties = parameter.Properties().ToList();

                        foreach (JProperty property in lstJProperties)
                        {
                            clsDynamicClass.AddProperty(declarationModel, property.Name, "");
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return declarationModel;
        }


        public IList<T> ExecuteSqlQuery<T>(string sqlQuery, DynamicParameters param = null, string cs = null)
        {
            //clsLog.Info(">>> EXECUTESQLQUERY - INIZIO");
            IList<T> result = new List<T>();
            try
            {
                result = this.unitOfWork.QUERY_Call.List<T>(sqlQuery, param).ToList();
            }
            catch (Exception ex)
            {
                result = null;
                clsLog.Error("EXECUTESQLQUERY - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> EXECUTESQLQUERY - FINE");
            }

            return result;
        }

        //public IList<ItemContextButton> GetItemContextButtons(int idItem, int idTimbratore)
        //{

        //    IList<ItemContextButton> lstItemContextButtons = new List<ItemContextButton>();

        //    try
        //    {
        //        Expression<Func<ItemContextButton, bool>> expr = e => e.IdItem == idItem && e.IdTimbratoreSetup == idTimbratore;
        //        lstItemContextButtons = this.unitOfWork.ItemContextButton.GetAll(expr, null, "").ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error("GetItemContextButtons - Error: " + ex.ToString());
        //    }
        //    return lstItemContextButtons;
        //}



        public string GetColoreStatoOperatore(string idItem)
        {
            string s = "";
            // clsTimbratore configTimbratore = new clsTimbratore();
            return s;
        }



    }
}
