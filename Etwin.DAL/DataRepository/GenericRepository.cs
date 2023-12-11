using Etwin.DAL.Models;
using Etwin.Model.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;



namespace Etwin.DAL.DataRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ETwinContext _context;
        private DbSet<T> _entity = null;
        private readonly IConfiguration _config;

        public GenericRepository(ETwinContext context, IConfiguration config)
        {
            _context = context;
            _entity = _context.Set<T>();
            _config = config;
        }
        protected virtual DbSet<T> _entitys
        {
            get
            {
                if (_entity == null)
                    _entity = _context.Set<T>();

                return _entity;
            }
        }

        public ICollection<TType> GetWithFilters<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class
        {
            return _entity.Where(where).Select(select).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(object id)
        {
            return _entity.Find(id);
        }
        public virtual IQueryable<T> Table => _entitys;
        public void Insert(T obj)
        {
            _entity.Add(obj);
        }

        public void Update(T obj)
        {
            _entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _entity.Find(id);
            _entity.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        //public List<ReportChartModeList> ReportChartModel(string sqlQuery)
        //{

        //    var connectionString = _config.GetConnectionString("MbkDbConstr");
        //    var result = new List<ReportChartModeList>();
        //    var res = _context.ReportChartModel;
        //    if (sqlQuery.Contains("exec"))
        //    {
        //        var t = _context.ReportOrderWithPhaseListModel.FromSqlRaw(sqlQuery).ToList();
        //    }
        //    else
        //    {
        //        var d = _context.ReportChartModel.FromSqlRaw(sqlQuery).ToList();
        //        result.AddRange(d);
        //    }
        //    return result;
        //}
        public List<ReportOrderWithPhaseList> ReportPhaseModel(string sqlQuery)
        {

            var connectionString = _config.GetConnectionString("MbkDbConstr");
            var result = new List<ReportOrderWithPhaseList>();

            if (sqlQuery.Contains("exec"))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(sqlQuery.Split(" ").GetValue(1).ToString(), connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idAmbito", Convert.ToInt32(sqlQuery.Split(" ").GetValue(2).ToString()));

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (!reader.IsDBNull(0))
                                    {

                                        ReportOrderWithPhaseList orderPhase = new ReportOrderWithPhaseList()
                                        {
                                            RowId = Convert.ToInt32(reader.GetValue(0)),
                                            Order = reader.GetValue(1).ToString(),
                                            RigaOrdine = reader.GetValue(2).ToString(),
                                            Priorita = reader.GetValue(3).ToString(),
                                            Week = reader.GetValue(4).ToString(),
                                            Protocollo = reader.GetValue(5).ToString(),
                                            Cliente = reader.GetValue(6).ToString(),
                                            RifOrdine = reader.GetValue(7).ToString(),
                                            DataOrdine = reader.GetValue(8).ToString(),
                                            DataConsegna = reader.GetValue(9).ToString(),
                                            OrderQty = reader.GetValue(10).ToString(),
                                        };
                                        result.Add(orderPhase);
                                    }
                                }
                            }
                        }
                    }
                }
                // var t = _context.ReportOrderWithPhaseListModel.FromSqlRaw(sqlQuery).ToList();
                //result.AddRange(t);
            }
            //else
            //{
            //    var d = _context.ReportChartModel.FromSqlRaw(sqlQuery).ToList();
            //    result.AddRange(d);
            //}
            return result.Take(500).ToList();
        }
        //public List<ReportChartModeList> ExecuteStoredProcedure(string sqlQuery)
        //{
        //    //var parameterNames = Enumerable.Range(0, parameters.Length).Select(i => "@p" + i).ToArray();
        //    //var parameterNames = Enumerable.Range(0, parameters.Length).Select(i => i == 0 ? "@RibbonPageGroupId" : "@p" + i).ToArray();

        //    //var parameterList = string.Join(",", parameterNames);
        //    //var sql = $"EXEC {storedProcedureName} {parameterList}";
        //    var connectionString = _config.GetConnectionString("MbkDbConstr");
        //    var result = new List<ReportChartModeList>();
        //    var res = _context.ReportChartModel;
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (var command = new SqlCommand(storedProcedureName, connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@RibbonPageGroupId", Convert.ToInt32(parameters[0]));

        //            using (var reader = command.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        if (!reader.IsDBNull(0))
        //                        {
        //                            var sqlQuery = reader.GetString(0);
        //                            if (sqlQuery.Contains("exec"))
        //                            {
        //                                //var d = _context.Database.ExecuteSqlRaw(sqlQuery);
        //                                //var c = _entity.FromSqlRaw(sqlQuery).ToList();
        //                                var t = _context.ReportOrderWithPhaseListModel.FromSqlRaw(sqlQuery).ToList();
        //                                //.GroupBy(r => r.IdOrderRow).Select(g => g.FirstOrDefault());

        //                            }
        //                            else
        //                            {
        //                                var d = _context.ReportChartModel.FromSqlRaw(sqlQuery).ToList();
        //                                result.AddRange(d);
        //                            }
        //                            var controlName = reader.GetString(1);
        //                            // use sqlQuery and controlName to create your report model



        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    //var result = _entities.FromSqlRaw(storedProcedureName, Convert.ToInt32(parameters[0])).ToList();
        //    return result;
        //}
        public List<ReportModeList> GetControlTypeAndQueryDetails(string storedProcedureName, object[] parameters)
        {
            
            var connectionString = _config.GetConnectionString("MbkDbConstr");
            var result = new List<ReportModeList>();
            //var res = _context.ReportChartModel;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RibbonPageGroupId", Convert.ToInt32(parameters[0]));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    var sqlQuery = reader.GetInt32(2);
                                    //if (sqlQuery.Contains("exec"))
                                    //{
                                    //    //var d = _context.Database.ExecuteSqlRaw(sqlQuery);
                                    //    //var c = _entity.FromSqlRaw(sqlQuery).ToList();
                                    //    var t = _context.ReportOrderWithPhaseListModel.FromSqlRaw(sqlQuery).ToList();
                                    //    //.GroupBy(r => r.IdOrderRow).Select(g => g.FirstOrDefault());

                                    //}
                                    //else
                                    //{
                                    //    var d = _context.ReportChartModel.FromSqlRaw(sqlQuery).ToList();
                                    //    result.AddRange(d);
                                    //}

                                    // use sqlQuery and controlName to create your report model
                                    var reprt = new ReportModeList()
                                    {
                                        SqlQuery = reader.GetString(0),
                                        ControlName = reader.GetString(1),
                                        IdControl = reader.GetInt32(2),
                                        IdControlType = reader.GetInt32(3)
                                    };
                                    result.Add(reprt);


                                }
                            }
                        }
                    }
                }
            }
            //var result = _entities.FromSqlRaw(storedProcedureName, Convert.ToInt32(parameters[0])).ToList();
            return result;
        }
     

    }

}
