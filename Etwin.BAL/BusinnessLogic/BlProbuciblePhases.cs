using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using LogDll;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Dynamic;
using System.Linq;
using System.Collections.Generic;
using ETwin.Helper.Utilities;
using System;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlProbuciblePhases : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;
        SP_Call spCall = null;

        public BlProbuciblePhases(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
            this.spCall = new SP_Call(_db);
        }

        #region DYNAMIC MODEL
        public IList<ExpandoObject> GetDynamicModel(int idItem)
        {
            IList<ExpandoObject> lstMod = new List<ExpandoObject>();
            ExpandoObject exO = null;
            int ct = 0;
            try
            {
                IList<JProperty> lstProp = new List<JProperty>();
                //using (SP_Call spCall = new SP_Call(this._db))
                //{
                    Dapper.DynamicParameters dP = new Dapper.DynamicParameters();
                    dP.Add("IdItem", idItem);
                    string value = this.spCall.OneRecordJson("etwindb.spGetItemValueWithPhase", dP);
                    if (!string.IsNullOrEmpty(value) && value != "[]")
                    {
                        IList<JObject> parameter = JsonConvert.DeserializeObject<IList<JObject>>(value);
                        lstProp = parameter.Properties().ToList();

                        foreach (JProperty prop in lstProp)
                        {
                            if (prop.Name != null)
                            {
                                if (prop.Name == "IdItem")
                                {
                                    exO = new ExpandoObject();
                                }

                                clsDynamicClass.AddProperty(exO, prop.Name, prop.Value);

                                if (exO.Count() == prop.Parent.Count())
                                    lstMod.Add(exO);

                            }

                        }
                    }
                    this._db.Dispose();
                //}


            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstMod;
        }
        #endregion


        //public void CreateTemporaryTable(int idOrder)
        //{
        //    try
        //    {
        //        //using (SP_Call spCall = new SP_Call(this._db))
        //        //{
        //            Dapper.DynamicParameters dP = new Dapper.DynamicParameters();
        //            dP.Add("IdOrder", idOrder);
        //            dP.Add("CreateTempTable", "True");
        //            spCall.Execute("etwindb.spGetItemValueWithPhase", dP);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //}

        #region DYNAMIC MODEL FOR MANUAL ENTRY
        public IList<ExpandoObject> GetDynamicModelManual(int idBomPadre)
        {
            IList<ExpandoObject> lstMod = new List<ExpandoObject>();
            ExpandoObject exO = null;
            int ct = 0;
            try
            {
                IList<JProperty> lstProp = new List<JProperty>();
                //using (SP_Call spCall = new SP_Call(this._db))
                //{
                Dapper.DynamicParameters dP = new Dapper.DynamicParameters();
                dP.Add("IdBomPadre", idBomPadre);
                dP.Add("CreateTempTable", "False");
                string value = this.spCall.OneRecordJson("etwindb.spGetBomList", dP);
                if (!string.IsNullOrEmpty(value) && value != "[]")
                {
                    IList<JObject> parameter = JsonConvert.DeserializeObject<IList<JObject>>(value);
                    lstProp = parameter.Properties().ToList();

                    foreach (JProperty prop in lstProp)
                    {
                        if (prop.Name != null)
                        {
                            if (prop.Name == "IdItem")
                            {
                                exO = new ExpandoObject();
                            }

                            clsDynamicClass.AddProperty(exO, prop.Name, prop.Value);

                            if (exO.Count() == prop.Parent.Count())
                                lstMod.Add(exO);

                        }

                    }
                }
                this._db.Dispose();
                //}


            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstMod;
        }
        #endregion


        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
