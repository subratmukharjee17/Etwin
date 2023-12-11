using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.ComponentModel;
using LogDll;
using Etwin.Model.Context;
using Newtonsoft.Json;
using Etwin.DAL.Models;
using ETwin.Helper.Utilities;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using Org.BouncyCastle.Crmf;
using Etwin.Model.GlobalModels;
using Etwin.DAL.GlobalDataRepository.IRepository;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using Etwin.DAL.GlobalDataRepository;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlInputControl : IDisposable
    {
        DAL.DataRepository.IRepository.IUnitOfWork unitOfWork = null;
        DAL.GlobalDataRepository.IRepository.IUnitOfWork unitOfWorkGlobal = null;
        private readonly ETwinContext _db;
        public readonly GlobalDbContext _Globaldb;

        public BlInputControl(string cs = null)
        {
            this._db = new ETwinContext(cs);

            this.unitOfWork = new DAL.DataRepository.UnitOfWork(_db);

            this._Globaldb = new GlobalDbContext();

            this.unitOfWorkGlobal = new DAL.GlobalDataRepository.UnitOfWork(_Globaldb);
        }
        public int? GetBIInputControlId(int IdControl)
        {
            return this.unitOfWork.RibbonPageGroupButtons.GetAll().Where(c => c.Id == IdControl).Select(i => i.IdControl).FirstOrDefault();
        }
        public InputControlPageViewModel GetDynamicPageControlModel(string Opcode, string cs ,int? inputControlId)
        {
            InputControlPageViewModel inputControlPageViewModel = new InputControlPageViewModel();
            dynamic joinedList = null;
            //Get main Input Wizard Name
            IList<InputWizard> inputWizard = new List<InputWizard>();
            inputWizard = this.unitOfWork.InputWizard.GetAll().Where(i=>i.Id== inputControlId).ToList();
            //Get input step
            IList<InputStepWizard> inputStepWizard = new List<InputStepWizard>();
            inputStepWizard = this.unitOfWork.InputStepWizard.GetAll().Where(i => i.IdCustomWizard == inputControlId).ToList();
            //Get all the contrl of the input
            IList<InputControl> inputControl = new List<InputControl>();
            foreach (InputStepWizard step in inputStepWizard)
            {
                inputControl = this.unitOfWork.InputControl.GetAll().Where(i => i.IdCustomStepWizard == step.Id).ToList();
            }
            //Get type of values
            IList<Model.GlobalModels.ValueType> inputColumnValueType = new List<Model.GlobalModels.ValueType>();
            inputColumnValueType = this.unitOfWorkGlobal.ValueTypes.GetAll().ToList();
            //Get type of control
            IList<InputControlType> inputControlType = new List<InputControlType>();
            inputControlType = this.unitOfWorkGlobal.InputControlType.GetAll().ToList();
            try
            {
                inputControlPageViewModel.PageTitle = inputWizard.FirstOrDefault().Title;
                inputControlPageViewModel.InputControlModel = new List<InputControlModel>();
                foreach (var cntrl in inputControl)
                {
                    InputControlModel ic = new InputControlModel();
                    ic.Id = cntrl.Id;
                    ic.ColumnText = cntrl.ColumnText;
                    ic.IdColumnValueType = cntrl.IdColumnValueType;
                    //ic.ColumnValueType = inputColumnValueType.Where(cvt => cvt.Id == cntrl.IdColumnValueType).FirstOrDefault().ColumnValueType1;
                    ic.IdControlType = cntrl.IdControlType;
                    //ic.ControlType = inputControlType.Where(cvt => cvt.Id == cntrl.IdControlType).FirstOrDefault().ControlType;
                    ic.IsUnique = cntrl.IsUnique;
                    ic.Visible = cntrl.Visible;
                    ic.Sequences = cntrl.Sequences;
                    ic.Required = cntrl.Required;
                    if (cntrl.Datasource != null)
                    {
                        //load data
                        ic.Datasource = this.GetInputControlDataSource(cntrl.Datasource);
                    }
                    ic.TableColumn = cntrl.TableColumn;
                    ic.DatabaseTable = cntrl.DatabaseTable;
                    inputControlPageViewModel.InputControlModel.Add(ic);

                }
                inputControlPageViewModel.InputControlModel=inputControlPageViewModel.InputControlModel.OrderBy(o => o.Sequences).ToList();
                return inputControlPageViewModel;
            }
            catch (Exception ex)
            {
                clsLog.Error("GetDynamicPageControlModel - Error: " + ex.ToString());
            }
            return joinedList;
        }
        public dynamic ConvertJsonObjectKeyValuePair(string json)
        {
            //json = @"[{\"IdOperatorRole\":1,\"Description\":\"Description\"},{\"IdOperatorRole\":2,\"Description\":\"Operatore Generico\"},{\"IdOperatorRole\":3,\"Description\":\"Operatore Generico\"}]";
            //json=json.Replace("\",""");
            //// Deserialize the JSON array
            //List<KeyValuePair<string, string>> keyValuePairs = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(json);

            //// Create a new JSON array with objects containing key-value pairs
            //JArray resultArray = new JArray();
            //foreach (var kvp in keyValuePairs)
            //{
            //    JObject keyValueObject = new JObject();
            //    keyValueObject.Add(new JProperty(kvp.Key, kvp.Value));
            //    resultArray.Add(keyValueObject);
            //}

            //// Convert the result array back to a JSON string
            //return resultArray.ToString(Formatting.None);

            ////Console.WriteLine(resultJson);

            // Deserialize the input JSON into a list of JObject
            List<JObject> inputObjects = JsonConvert.DeserializeObject<List<JObject>>(json);

            // Create a new list to store the transformed objects
            List<JObject> transformedObjects = new List<JObject>();

            foreach (JObject inputObject in inputObjects)
            {
                foreach (var property in inputObject.Properties())
                {
                    string key = property.Value.ToString();
                    string value = property.Value.ToString();

                    // Create a new JObject with the key-value pair
                    JObject transformedObject = new JObject(new JProperty(key, value));

                    // Add the transformed object to the result list
                    transformedObjects.Add(transformedObject);
                }
            }

            // Serialize the transformed list back to JSON
            return JsonConvert.SerializeObject(transformedObjects, Formatting.Indented);
        }
        public List<KeyValuePair<string, string>> GetInputControlDataSource(string sqlQuery)
        {
            dynamic d = new ExpandoObject();
            IList<ExpandoObject> result = new List<ExpandoObject>();
            List<KeyValuePair<string, string>> valuePairs = new List<KeyValuePair<string, string>>();
            try
            {
                Dapper.DynamicParameters parameters = new Dapper.DynamicParameters();
                if (sqlQuery.Contains("exec"))
                {
                    parameters.Add("idAmbito", Convert.ToInt32(sqlQuery.Split(" ").GetValue(2).ToString()));
                    d = this.unitOfWork.SP_Call.List<dynamic>(sqlQuery.Split(" ").GetValue(1).ToString(), parameters).ToList();
                }
                else
                {
                    d = this.unitOfWork.QUERY_Call.List<dynamic>(sqlQuery.ToString(), parameters).ToList();
                }
                /*Create dynamic model*/
                string jsonResult = JsonConvert.SerializeObject(d);
                if (!string.IsNullOrEmpty(jsonResult) && jsonResult != "[]")
                {
                    IList<JObject> inputObjects = JsonConvert.DeserializeObject<IList<JObject>>(jsonResult);
                    if (inputObjects != null && inputObjects.Count > 0)
                    {
                        IList<JProperty> lstJProperties = inputObjects.Properties().ToList();
                        dynamic model = new ExpandoObject();

                        foreach (JObject inputObject in inputObjects)
                        {
                            foreach (JProperty jProperty in inputObject.Properties().ToList())
                            {
                                if (jProperty.Next != null)
                                {
                                    valuePairs.Add(new KeyValuePair<string, string>(jProperty.Value.ToString(), ((Newtonsoft.Json.Linq.JValue)((Newtonsoft.Json.Linq.JProperty)jProperty.Next).Value).Value.ToString()));
                                    break;
                                }

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsLog.Error("GetInputControlDataSource - Error: " + ex.ToString());
            }
            return valuePairs;
        }
        public bool SubmitInputControlData(string TableName, OperatorModel operatorModel)
        {
            bool result = false;
            try
            {
                if (TableName == "Operators")
                {
                    Model.Operator op = JsonConvert.DeserializeObject<Model.Operator>(JsonConvert.SerializeObject(operatorModel));
                    this.unitOfWork.Operators.Add(op);
                    this.unitOfWork.Save();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error("SubmitInputControlData - Error: " + ex.ToString());
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
