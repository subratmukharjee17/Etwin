using ETwin.BAL.FixModels;
using LogDll;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace Etwin.BAL.BusinnessLogic.BLGenericDB
{
    public class BlMaterialDb
    {
        #region VARS
        string CSGeneric = "data source=host8728.shserver.it,1438;initial catalog=GlobalDb;persist security info=True;user id=sa;password=NmlILt68qnWCQT7Eog;MultipleActiveResultSets=True;App=EntityFramework";
        #endregion

        #region GET PARAMETER FROM TYPE
        public IList<modItemParameterGeneric> GetParameterFromType(string filtro)
        {
            IList<modItemParameterGeneric> lstParameters = new List<modItemParameterGeneric>();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();
                    // DEFINISCO IL FILTRO
                    string sqlQueryFiltro = !string.IsNullOrEmpty(filtro) ? " WHERE " + filtro : "";
                    string Query = "select * from ItemParameters " + sqlQueryFiltro;

                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                int execOrder = 0;
                                bool isFilt = true;
                                modItemParameterGeneric mod = new modItemParameterGeneric()
                                {
                                    IdItemParameter = (int)rdr["IdItemParameter"],
                                    ItemParameterName = rdr["ItemParameterName"].ToString().ToLower(),
                                    ItemParameterDescription = rdr["ItemParameterDescription"].ToString(),
                                    IdItemType = int.TryParse(rdr["IdItemType"].ToString(), out execOrder) ? (int)rdr["IdItemType"] : 0,
                                    IdDataType = int.TryParse(rdr["IdDataType"].ToString(), out execOrder) ? (int)rdr["IdDataType"] : 0,
                                    Calculation = !string.IsNullOrEmpty(rdr["Calculation"].ToString()) ? rdr["Calculation"].ToString() : "",
                                    ExecutionOrder = int.TryParse(rdr["Calculation"].ToString(), out execOrder) ? (int)rdr["Calculation"] : 0,
                                    isFilter = bool.TryParse(rdr["IsFilter"].ToString(), out isFilt) ? (bool)rdr["Calculation"] : true,
                                    FilterCommand = !string.IsNullOrEmpty(rdr["FilterCommand"].ToString()) ? rdr["FilterCommand"].ToString() : "",
                                };
                                lstParameters.Add(mod);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstParameters;
        }
        #endregion

        #region GET ITEM TYPE
        public IList<modItemType> GetItemType(string filtro)
        {
            IList<modItemType> lstItemsType = new List<modItemType>();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();
                    // DEFINISCO IL FILTRO
                    string sqlQueryFiltro = !string.IsNullOrEmpty(filtro) ? " WHERE " + filtro : "";
                    string Query = "select * from ItemType " + sqlQueryFiltro;

                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                int execOrder = 0;
                                modItemType mod = new modItemType()
                                {
                                    Id = (int)rdr["Id"],
                                    Type = rdr["Type"].ToString(),
                                    IdTypeParent = int.TryParse(rdr["IdTypeParent"].ToString(), out execOrder) ? (int)rdr["IdTypeParent"] : 0,
                                    Description = !string.IsNullOrEmpty(rdr["Description"].ToString()) ? rdr["Description"].ToString() : ""
                                };
                                lstItemsType.Add(mod);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstItemsType;
        }
        #endregion

        #region GET ITEM PARAMETERS
        public IList<modItemParameterGlobal> GetItemParameters()
        {
            IList<modItemParameterGlobal> list = new List<modItemParameterGlobal>();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(this.CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();
                    string Query = "select * from GlobalDb.dbo.ItemParameters ";
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                modItemParameterGlobal mod = new modItemParameterGlobal();
                                mod.IdItemParameter = int.Parse(rdr["IdItemParameter"].ToString());
                                mod.ItemParameterName = rdr["ItemParameterName"].ToString();
                                mod.ItemParameterDescription = rdr["ItemParameterDescription"].ToString();
                                if (!string.IsNullOrEmpty(rdr["IdItemType"].ToString()))
                                {
                                    mod.IdItemType = int.Parse(rdr["IdItemType"].ToString());
                                }
                                if (!string.IsNullOrEmpty(rdr["IdDataType"].ToString()))
                                {
                                    mod.IdDataType = int.Parse(rdr["IdDataType"].ToString());
                                }
                                mod.Calculation = rdr["Calculation"].ToString();
                                if (!string.IsNullOrEmpty(rdr["ExecutionOrder"].ToString()))
                                {
                                    mod.ExecutionOrder = int.Parse(rdr["ExecutionOrder"].ToString());
                                }
                                if (!string.IsNullOrEmpty(rdr["IsFilter"].ToString()))
                                {
                                    mod.IsFilter = bool.Parse(rdr["IsFilter"].ToString());
                                }
                                mod.FilterCommand = rdr["FilterCommand"].ToString();
                                mod.CreationDate = DateTime.Parse(rdr["CreationDate"].ToString());

                                list.Add(mod);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return list;
        }
        #endregion

        public modItemParameterGlobal GetItemParameter(string filtro)
        {
            modItemParameterGlobal mod = null;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(this.CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();
                    string Query = "select * from GlobalDb.dbo.ItemParameters " + filtro;
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                mod = new modItemParameterGlobal();
                                mod.IdItemParameter = int.Parse(rdr["IdItemParameter"].ToString());
                                mod.ItemParameterName = rdr["ItemParameterName"].ToString();
                                mod.ItemParameterDescription = rdr["ItemParameterDescription"].ToString();
                                if (!string.IsNullOrEmpty(rdr["IdItemType"].ToString()))
                                {
                                    mod.IdItemType = int.Parse(rdr["IdItemType"].ToString());
                                }
                                if (!string.IsNullOrEmpty(rdr["IdDataType"].ToString()))
                                {
                                    mod.IdDataType = int.Parse(rdr["IdDataType"].ToString());
                                }
                                if (!string.IsNullOrEmpty(rdr["Calculation"].ToString()))
                                {
                                    mod.Calculation = rdr["Calculation"].ToString();
                                }
                                if (!string.IsNullOrEmpty(rdr["ExecutionOrder"].ToString()))
                                {
                                    mod.ExecutionOrder = int.Parse(rdr["ExecutionOrder"].ToString());
                                }
                                if (!string.IsNullOrEmpty(rdr["IsFilter"].ToString()))
                                {
                                    mod.IsFilter = bool.Parse(rdr["IsFilter"].ToString());
                                }
                                if (!string.IsNullOrEmpty(rdr["FilterCommand"].ToString()))
                                {
                                    mod.FilterCommand = rdr["FilterCommand"].ToString();
                                }
                                mod.CreationDate = DateTime.Parse(rdr["CreationDate"].ToString());

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return mod;
        }

        public int GetIdParameterByName(string name)
        {
            int Id = 0;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(this.CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();

                    string Query = "select IdItemParameter from GlobalDb.dbo.ItemParameters where ItemParameterName = '" + name + "'";
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                Id = int.Parse(rdr["IdItemParameter"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return Id;
        }

        public modPhase GetPhaseByName(string Phase)
        {
            modPhase modPhase = new modPhase();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(this.CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();

                    string Query = "select * from Phases where Phase = '" + Phase + "'";
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                modPhase.IdPhase = int.Parse(rdr["IdPhase"].ToString());
                                modPhase.IdDepartment = int.Parse(rdr["IdDepartment"].ToString());
                                modPhase.PhaseCode = rdr["PhaseCode"].ToString();
                                modPhase.Phase = rdr["Phase"].ToString();
                                modPhase.CreationDate = DateTime.Parse(rdr["CreationDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return modPhase;
        }

        public modPhase GetPhaseById(int idPhase)
        {
            modPhase modPhase = new modPhase();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(this.CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();

                    string Query = "select * from Phases where IdPhase = " + idPhase;
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                modPhase.IdPhase = int.Parse(rdr["IdPhase"].ToString());
                                modPhase.IdDepartment = int.Parse(rdr["IdDepartment"].ToString());
                                modPhase.PhaseCode = rdr["PhaseCode"].ToString();
                                modPhase.Phase = rdr["Phase"].ToString();
                                modPhase.CreationDate = DateTime.Parse(rdr["CreationDate"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return modPhase;
        }

        #region GET DEPARTMENT GLOBAL
        public IList<modGlobalDepartments> GetGlobalDepartment()
        {
            IList<modGlobalDepartments> departments = new List<modGlobalDepartments>();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(this.CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();

                    string Query = "select * from GlobalDb.dbo.Departments";
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            var dataTable = new System.Data.DataTable();
                            dataTable.Load(rdr);

                            var serializedMyObjects = JsonConvert.SerializeObject(dataTable);
                            departments = (List<modGlobalDepartments>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<modGlobalDepartments>));

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return departments;
        }
        #endregion

        #region INSERT BYTE 
        public void InsertAnalysisDrawings(modDrawing drawing, string cs, int? idPadre=null)
        {
            try
            {
                using (var ConnectionOutput = new SqlConnection(CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = ConnectionOutput;
                    ConnectionOutput.Open();
                    if (ConnectionOutput.State == ConnectionState.Open)
                    {
                        // DEFINISCO LA QUERY
                        string Query="";
                        if (idPadre != null)
                        {
                            Query = "insert into GlobalDb.dbo.AnalysisDrawings (ByteOfFile, ConnectionString, IdDrawingState,FileName,Path, IdMainDrawing)" +
                               "values(@ValoreDaCambiare, '" + cs + "', 1, '" + drawing.FileName + "', '" + drawing.Path + "',"+idPadre+")";
                        }
                        else
                        {
                            Query = "insert into GlobalDb.dbo.AnalysisDrawings (ByteOfFile, ConnectionString, IdDrawingState,FileName,Path)" +
                               "values(@ValoreDaCambiare, '" + cs + "', 1, '" + drawing.FileName + "', '" + drawing.Path + "')";
                        }
                        cmd.Parameters.Add("@ValoreDaCambiare", SqlDbType.VarBinary).Value = drawing.ByteOfFile;
                        cmd.CommandText = Query;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        public int GetIdAnalysisDrawings(modDrawing d)
        {
            int id =0;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(this.CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();

                    string Query = "SELECT top 1 Id FROM [GlobalDb].[dbo].[AnalysisDrawings] where IdDrawingState = 1 and FileName = '"+d.FileName+"' order by CreationDate desc";
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            id = int.Parse(rdr["Id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return id;
        }

        public IList<modItemGraphicCondition> GetAllItemCondition()
        {
            IList<modItemGraphicCondition> condition = new List<modItemGraphicCondition>();
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(this.CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();

                    string Query = "select * from GlobalDb.dbo.ItemGraphicConditions";
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                modItemGraphicCondition c = new modItemGraphicCondition();
                                c.Id = int.Parse(rdr["Id"].ToString());
                                c.ItemType = int.Parse(rdr["IdItemType"].ToString());
                                c.Condition = rdr["Condition"].ToString();
                                condition.Add(c);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return condition;
        }
    }
}
