using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
//using LogDll;
using System.Data;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.DAL.DataRepository
{
    public class SP_Call : ISP_Call
    {
        private readonly ETwinContext _db;
        private static string ConnectionString = "";


        public SP_Call(ETwinContext db)
        {
            this._db = db;
            ConnectionString = this._db.Database.GetConnectionString();

            //bool connection = false;
            //if (ConfigurationManager.ConnectionStrings["MbkDbConstr"] == null)
            //{
            //    ConfigurationBuilder AppName = new ConfigurationBuilder();
            //    AppName.AddJsonFile("appsettings.json").Build().GetSection("AppSettings");
            //    //AppName.AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["MbkDbConstr"];
            //}
            //else
            //{
            //ConnectionString = ConfigurationManager.ConnectionStrings["MbkDbConstr"].ConnectionString; // this._db.Database.
            //connection = this.ConnessioneDb(ConnectionString);
            //    if (connection)
            //    {
            //        ConnectionString = ConfigurationManager.ConnectionStrings["MbkDbConstr"].ConnectionString;
            //    }
            //}
        }


        #region CONNESSIONE
        //private bool ConnessioneDb(string connectionString)
        //{
        //    bool connessione = false;
        //    try
        //    {
        //        SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(connectionString);
        //        string server = sqlBuilder.DataSource;

        //        //SE HO CONNESSIONE DEL TIPO: .\SQLEXPRESS DEVO PINGARE IL PC LOCALE
        //        if (server.StartsWith("."))
        //        {
        //            connessione = true;
        //        }
        //        else
        //        {
        //            string[] servers = server.Split(@"\");
        //            IPStatus pingResult = PingServer(servers[0]);
        //            if (pingResult == IPStatus.Success)
        //            {
        //                using (var ConnectionTHD = new SqlConnection(connectionString))
        //                {
        //                    ConnectionTHD.Open();
        //                    if (ConnectionTHD.State == ConnectionState.Open)
        //                        connessione = true;
        //                }
        //            }
        //            else
        //            {
        //                connessione = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //        connessione = false;
        //    }
        //    return connessione;
        //}

        //private static IPStatus PingServer(string server)
        //{
        //    IPStatus result;

        //    Ping ping = new Ping();
        //    int timeOut = 15;

        //    PingReply pingReplay = ping.Send(server, timeOut);

        //    result = pingReplay.Status;

        //    return result;
        //}
        #endregion


        public void Dispose()
        {
            this._db.Dispose();
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                sqlConn.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
        public IDataReader ExecuteReader(string sqlQuery, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                return sqlConn.ExecuteReader(sqlQuery, param, commandType: CommandType.Text);
            }
        }
        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                return sqlConn.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                var result = SqlMapper.QueryMultiple(sqlConn, procedureName, param, commandType: CommandType.StoredProcedure);
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();

                if (item1 != null && item2 != null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }

        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                var value = sqlConn.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
            }
        }

        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                return (T)Convert.ChangeType(sqlConn.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }

        public string OneRecordJson(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                var value = sqlConn.Query(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                return JsonConvert.SerializeObject(value);
            }
        }
    }
}
