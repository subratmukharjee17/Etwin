using Etwin.DAL.DataRepository.IRepository;
using Dapper;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.DAL.GlobalDataRepository
{
    public class SP_Call : ISP_Call
    {
        private readonly GlobalDbContext _db;
        private static string ConnectionString = "";


        public SP_Call(GlobalDbContext db)
        {
            this._db = db;
            ConnectionString = this._db.Database.GetConnectionString();
        }


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
