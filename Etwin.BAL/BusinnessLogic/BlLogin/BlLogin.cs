
using ETwin.BAL.FixModels;
using ETwin.DAL.Models;
using LogDll;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection.Metadata;



namespace Etwin.BAL.BusinnessLogic.BLogin
{
    public class BlLogin
    {
        #region VARS
        string CSGeneric = "data source=host8728.shserver.it,1438;initial catalog=Login;persist security info=True;user id=sa;password=NmlILt68qnWCQT7Eog;MultipleActiveResultSets=True;App=EntityFramework";
        #endregion

        public int GetIdCompanyByOperator(int idOperator)
        {
            int id = 0;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();
                    string Query = "select IdCompany from Login.dbo.Operators where IdOperator =  " + idOperator;
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                id = int.Parse(rdr["IdCompany"].ToString());
                            }
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

        public string GetCSCompany(int idCompany)
        {
            string cs = "";
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();
                    string Query = "select ConnectionString from Login.dbo.Companies where IdCompany = " + idCompany;
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                cs = rdr["ConnectionString"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return cs;
        }

        public string GetCompanyByCs(string cs)
        {
            string company = "";
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(CSGeneric))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlcon;
                    sqlcon.Open();
                    string Query = "SELECT CompanyName FROM Login.dbo.Companies WHERE REPLACE(ConnectionString, ' ', '') LIKE REPLACE('%" + cs + "%','\r\n','')";
                    cmd.CommandText = Query;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr != null)
                        {
                            while (rdr.Read())
                            {
                                company = rdr["CompanyName"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return company;
        }
    }
}
