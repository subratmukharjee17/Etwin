using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.ComponentModel;
using LogDll;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlGeneric : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlGeneric(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        #region SELECT * FROM ...

        public IList<T> GetAll<T>(string sqlQuery)
        {
            IList<T> lstResult = new List<T>();
            try
            {
                lstResult = this.unitOfWork.QUERY_Call.List<T>(sqlQuery).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstResult;
        }

        #endregion

        #region EXEC QUERY

        public BindingList<object> ExecQuery(string query)
        {
            //clsLog.Info(">>> EXECQUERY - INIZIO");

            BindingList<object> result = new BindingList<object>();

            try
            {
                IList<object> lstResult = this.unitOfWork.QUERY_Call.List<object>(query).ToList();
                result = new BindingList<object>(lstResult);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> EXECQUERY - FINE");
            }
            return result;
        }


        #endregion

        #region CHECK DB CONNECTION

        public bool CheckDbConnection()
        {
            //clsLog.Info(">>> CHECKDBCONNECTION - INIZIO");
            bool result = true;
            try
            {
                IList<object> lstConnection = new List<object>();

                IList<Grid> lstResult = this.unitOfWork.QUERY_Call.List<Grid>("SELECT * FROM ETwin.Grids").ToList();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("CHECKDBCONNECTION - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> CHECKDBCONNECTION - FINE");
            }

            return result;
        }

        #endregion

        #region EXECUTE QUERY

        public IList<T> ExecuteSqlQuery<T>(string sqlQuery, DynamicParameters param = null)
        {
            //clsLog.Info(">>> EXECUTESQLQUERY - INIZIO");
            IList<T> result = new List<T>();
            try
            {
                result = this.unitOfWork.QUERY_Call.List<T>(sqlQuery, param).ToList();
            }
            catch (Exception ex)
            {
                result = null;
                clsLog.Error("EXECUTESQLQUERY - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> EXECUTESQLQUERY - FINE");
            }

            return result;
        }

        #endregion

        //#region EXECUTE QUERY VOID

        //public void ExecuteSqlQuery<T>(string sqlQuery, DynamicParameters param = null)
        //{
        //    //clsLog.Info(">>> EXECUTESQLQUERY - INIZIO");
        //    IList<T> result = new List<T>();
        //    try
        //    {
        //        result = this.unitOfWork.QUERY_Call.List<T>(sqlQuery, param).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        clsLog.Error("EXECUTESQLQUERY - Error: " + ex.ToString());
        //    }
        //    finally
        //    {
        //        //clsLog.Info(">>> EXECUTESQLQUERY - FINE");
        //    }

        //    return result;
        //}

        //#endregion

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
