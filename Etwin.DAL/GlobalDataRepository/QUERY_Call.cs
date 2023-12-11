using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.DAL.GlobalDataRepository
{
    public class QUERY_Call : IQUERY_Call
    {
        private readonly GlobalDbContext _db;
        private static string ConnectionString = "";

        public QUERY_Call(GlobalDbContext db)
        {
            this._db = db;
            ConnectionString = this._db.Database.GetConnectionString();
          
        }

        public void Dispose()
        {
            this._db.Dispose();
        }

        public void Execute(string sqlQuery, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                sqlConn.Execute(sqlQuery, param, commandType: System.Data.CommandType.Text);
            }
        }

        public IEnumerable<T> List<T>(string sqlQuery, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                return sqlConn.Query<T>(sqlQuery, param, commandType: System.Data.CommandType.Text);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string sqlQuery, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                var result = SqlMapper.QueryMultiple(sqlConn, sqlQuery, param, commandType: System.Data.CommandType.Text);
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();

                if (item1 != null && item2 != null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }

        public T OneRecord<T>(string sqlQuery, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                var value = sqlConn.Query<T>(sqlQuery, param, commandType: System.Data.CommandType.Text);
                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
            }
        }

        public T Single<T>(string sqlQuery, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                sqlConn.Open();
                return (T)Convert.ChangeType(sqlConn.ExecuteScalar<T>(sqlQuery, param, commandType: System.Data.CommandType.Text), typeof(T));
            }
        }
    }
}
