using Microsoft.AspNetCore.Mvc;
using LogDll;
using Etwin.Model.Context;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using Etwin.BAL.BusinnessLogic;
using Etwin.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.IO;
using ETwin.BAL.FixModels;
using DevExpress.PivotGrid.ServerMode.OperationGraph;
using Etwin.CLS.GenericClass;
//using Etwin.Filter;


namespace ETwin_Next.Controllers
{
    // [OperatorCodeFilter]
    public class DataGridController : Controller
    {

        private readonly ETwinContext _data;
        public clsGenericClass clsgeneric = new clsGenericClass();
        private readonly BlGrids _grids;
        private readonly string _sessionValue;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _cs;

        public DataGridController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            _data = new ETwinContext(_sessionValue);
            _grids = new BlGrids(_sessionValue);
            //  _cs = cs;
        }

        #region ADD ROW

        [HttpPost]
        public IActionResult AddRow([FromBody] JObject data)
        {
            try
            {
                //Get Json of the entered values
                string jsonString = JsonConvert.SerializeObject(data["row"]);
                //I take the grid name
                string gridName = JsonConvert.DeserializeObject<string>(JsonConvert.SerializeObject(data["gridName"]));

                Dictionary<string, string> allValues = (JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString))
                    .Where(x => x.Key != "__KEY__")
                    .ToDictionary(x => x.Key, x => x.Value.ToString());

                //I take the grid with the name = gridName
                string rifTable = this.GetGridName(gridName);
                //I get the list of columns that I will have to insert
                string columnsLst = string.Empty;
                string valuesLst = string.Empty;
                int ctColumn = 0;
                int ctValues = 0;
                foreach (KeyValuePair<string, string> o in allValues)
                {
                    if (!string.IsNullOrEmpty(o.Key))
                    {
                        //analyze the columns
                        if (ctColumn == allValues.Count() - 1)
                        {
                            columnsLst += o.Key;
                        }
                        else
                        {
                            columnsLst += o.Key + ",";
                            ctColumn++;
                        }
                    }
                    ///analyze the value
                    if (!string.IsNullOrEmpty(o.Value))
                    {
                        if (ctValues == allValues.Count() - 1)
                        {
                            valuesLst += "'" + o.Value + "'";
                        }
                        else
                        {
                            valuesLst += "'" + o.Value + "',";
                            ctValues++;
                        }
                    }
                }
                this.InsertRow(rifTable, columnsLst, valuesLst);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return Ok();
        }

        #region INSERT ROW
        private void InsertRow(string gridName, string columnsList, string valuesList)
        {
            try
            {
                string cs = clsgeneric.GetConnectionString();
                using (var ConnectionTHD = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = ConnectionTHD;
                    ConnectionTHD.Open();
                    if (ConnectionTHD.State == ConnectionState.Open)
                    {
                        string sqlQuery = "INSERT INTO " + gridName + "(" + columnsList + ") VALUES (" + valuesList + ")";
                        cmd.CommandText = sqlQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #region UPDATE ROW
        private void UpdateRow(string gridName, string setFilter, string whereFilter)
        {
            try
            {
                using (var ConnectionTHD = new SqlConnection(_sessionValue))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = ConnectionTHD;
                    ConnectionTHD.Open();
                    if (ConnectionTHD.State == ConnectionState.Open)
                    {
                        string sqlQuery = "UPDATE " + gridName + " SET " + setFilter + " WHERE " + whereFilter;
                        cmd.CommandText = sqlQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #region EXECUTE GENERIC QUERY
        [HttpPost]
        public string ExecuteGenericQuery(string query)
        {
            IList<modIdValue> list = new List<modIdValue>();
            try
            {
                if (query != null)
                {
                    // Prendo la connection string
                    string cs = clsgeneric.GetConnectionString();
                    using (SqlConnection sqlcon = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = sqlcon;
                        sqlcon.Open();
                        string Query = query;
                        cmd.CommandText = Query;
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr != null)
                            {
                                while (rdr.Read())
                                {
                                    modIdValue md = new modIdValue()
                                    {
                                        //id = rdr["Id"].ToString(),
                                        id = int.Parse(rdr["Id"].ToString()),
                                        valore = rdr["Valore"].ToString()
                                    };
                                    list.Add(md);

                                }
                            }
                        }
                        sqlcon.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return JsonConvert.SerializeObject(list);

        }
        #endregion

        #endregion

        #region EDIT ROW
        [HttpPost]
        public IActionResult EditRow([FromBody] JObject data)
        {
            try
            {

                string oldData = JsonConvert.SerializeObject(data["oldData"]);
                string newData = JsonConvert.SerializeObject(data["newData"]);
                //Take the name of the grid
                string gridName = JsonConvert.DeserializeObject<string>(JsonConvert.SerializeObject(data["gridName"]));

                //I create a dictionary with old data
                Dictionary<string, string> oldDataDict = (JsonConvert.DeserializeObject<Dictionary<string, string>>(oldData))
                   .Where(x => x.Key != "__KEY__" && x.Value != null)
                   .ToDictionary(x => x.Key, x => x.Value.ToString());

                //I create a dictionary with new data
                Dictionary<string, string> newDataDict = (JsonConvert.DeserializeObject<Dictionary<string, string>>(newData))
                   .Where(x => x.Key != "__KEY__")
                   .ToDictionary(x => x.Key, x => x.Value.ToString());

                //I take the grid with the name = gridName
                string rifTable = this.GetGridName(gridName);

                //Declare where filter
                string filterString = string.Empty;
                int ctColumnWhere = 0;
                ctColumnWhere = ctColumnWhere - newDataDict.Count();
                //Loop through the dictionary with old data and create the where filter
                foreach (KeyValuePair<string, string> kpOld in oldDataDict)
                {
                    if (!string.IsNullOrEmpty(kpOld.Key) && !(newDataDict.ContainsKey(kpOld.Key) && newDataDict[kpOld.Key] == kpOld.Value))
                    {
                        //If it's the last round I don't put the AND

                        if (ctColumnWhere == oldDataDict.Count() - 1 - newDataDict.Count())
                        {
                            filterString += kpOld.Key + " = '" + kpOld.Value + "'";
                        }
                        else
                        {
                            filterString += kpOld.Key + " = '" + kpOld.Value + "' AND ";

                        }

                    }
                    ctColumnWhere++;
                }

                //I declare SET filter
                string setString = string.Empty;
                int ctColumnSET = 0;
                //Loop through the dictionary with new data and create the set
                foreach (KeyValuePair<string, string> kpNew in newDataDict)
                {
                    //If last round I don't put the comma
                    if (ctColumnSET == newDataDict.Count() - 1)
                    {
                        setString += kpNew.Key + " = '" + kpNew.Value + "'";
                    }
                    else
                    {
                        setString += kpNew.Key + " = '" + kpNew.Value + "' ,";
                        ctColumnSET++;
                    }
                }


                this.UpdateRow(rifTable, setString, filterString);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return Ok();
        }
        #endregion

        [HttpDelete]
        public void Delete(int key)
        {
            _data.SaveChanges();
        }

        #region GET GRID NAME
        private string GetGridName(string gridName)
        {
            string tableReference = string.Empty;
            try
            {
                Grid g = _grids.GetGridByName(gridName);
                tableReference = g.ReferenceTableModel;
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return tableReference;
        }
        #endregion

        public string GetGridNameById(int idGrid)
        {
            string name = string.Empty;
            try
            {
                Grid grid = _grids.GetGrid(idGrid);
                name = grid.GridName;
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return name;
        }

        [HttpPost]
        public IActionResult SetRank([FromBody] JObject data)
        {
            try
            {

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return Ok();
        }

    }
}
