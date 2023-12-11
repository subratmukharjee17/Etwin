using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.DAL.Models;
using Etwin.Model.Context;
using LogDll;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlLogin
    {

        private readonly IConfiguration _configuration;
        IUnitOfWork unitOfWork = null;
        private ETwinContext _db;

        public BlLogin(IConfiguration configuration = null)
        {
            _configuration = configuration;
        }

        public Operator GetOperator(string username, string password, string cs = null)
        {
            Etwin.DAL.Models.Operator operatore = new Operator();
            Companies companies = new Companies();

            string connectionString = _configuration.GetConnectionString("MbkDbConstr");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM login.dbo.operators WHERE Username = @Username AND Password = @password and active=1";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // User found, process the results
                            while (reader.Read())
                            {
                                operatore.Username = reader["Username"].ToString();
                                operatore.NameSurname = reader["NameSurname"].ToString();
                                operatore.IdOperator = Convert.ToInt16(reader["IdOperator"]);
                                operatore.IdCompany = Convert.ToInt16(reader["IdCompany"]);

                                //companies = GetConnectionOfOperator(operatore.IdCompany, connectionString);

                                return operatore;
                            }


                        }
                        else
                        {
                            // User not found
                        }
                    }
                }
            }

            return null;
        }

        public Companies GetConnectionOfOperator(int IdCompany)
        {

            Companies companies = new Companies();

            string connectionString = _configuration.GetConnectionString("MbkDbConstr");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Companies WHERE IdCompany = @IdCompany ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdCompany", IdCompany);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // User found, process the results
                            while (reader.Read())
                            {
                                companies.IdCompany = int.Parse(reader["IdCompany"].ToString());
                                companies.CompanyName = reader["CompanyName"].ToString();
                                companies.ConnectionString = reader["ConnectionString"].ToString();
                                companies.CompanyLogo = reader["CompanyLogo"] == null ? "" : reader["CompanyLogo"].ToString();
                                companies.WebSite = reader["WebSite"] == null ? "" : reader["WebSite"].ToString();
                                return companies;
                            }
                        }
                        else
                        {
                            // User not found
                        }
                    }
                }
            }
            return null;
        }


        public Etwin.Model.Operator GetOperatorFromCompany(string username, string password, string cs)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);

            Etwin.Model.Operator operatore = new Etwin.Model.Operator();
            try
            {
                Expression<Func<Etwin.Model.Operator, bool>> expr = e => e.Username == username && e.Password == password;

                operatore = this.unitOfWork.Operators.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                operatore = null;
                clsLog.Error("GETOPERATORE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETOPERATORE - FINE");
            }

            return operatore;
        }

        public Etwin.Model.Operator GetOperatorFromCode(string matricola, string cs)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);

            Etwin.Model.Operator operatore = new Etwin.Model.Operator();
            try
            {
                Expression<Func<Etwin.Model.Operator, bool>> expr = e => e.OperatorCode == matricola;

                operatore = this.unitOfWork.Operators.GetFirstOrDefault(expr, ""/*"IdOperatorRoleNavigation,IdOperatorStateNavigation"*/);
            }
            catch (Exception ex)
            {
                operatore = null;
                clsLog.Error("GETOPERATORE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETOPERATORE - FINE");
            }

            return operatore;
        }
    }
}
