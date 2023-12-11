using System;
using System.Collections.Generic;
using System.Linq;
using Range = Etwin.Model.Range;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlRange : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlRange(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }



        public bool AddRange(Range range)
        {
            //clsLog.Info(">>> ADDRANGE - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Range.Add(range);
                this.unitOfWork.Save();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("ADDRANGE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> ADDRANGE - FINE");
            }

            return result;
        }


        public IList<Etwin.Model.Range> GetRanges()
        {
            //clsLog.Info(">>> GETRANGES - INIZIO");

            IList<Range> lstRange = new List<Range>();

            try
            {
                lstRange = this.unitOfWork.Range.GetAll(null, null, "").ToList();
                //clsLog.Info(">>> Record trovati: " + lstRange.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRANGES - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETRANGES - FINE");
            }

            return lstRange;
        }

        public Range GetRange(int idRange)
        {
            //clsLog.Info(">>> GETRANGE - INIZIO");

            Range range = new Range();

            try
            {
                range = this.unitOfWork.Range.Get(idRange);
            }
            catch (Exception ex)
            {
                clsLog.Error("GETRANGE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETRANGE - FINE");
            }

            return range;
        }

        public IList<RangeClient> GetRangeFromSeries(int idRange)
        {
            //clsLog.Info(">>> GETRANGEFROMSERIES - INIZIO");


            IList<RangeClient> lstRangeClient = new List<RangeClient>();
            try
            {
                Expression<Func<RangeClient, bool>> expr = e => e.IdRange == idRange;
                lstRangeClient = this.unitOfWork.RangeClient.GetAll(expr, null, "IdAreaChartRangeNavigation,IdChartSeriesNavigation,IdRangeNavigation").ToList();
                //clsLog.Info(">>> Record trovati: " + lstRangeClient.Count());

            }
            catch (Exception ex)
            {
                clsLog.Error("GETRANGEFROMSERIES - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETRANGEFROMSERIES - FINE");
            }

            return lstRangeClient;
        }


        public bool UpdateRange(Range range)
        {
            //clsLog.Info(">>> UPDATERANGE - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Range.Update(range);
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("UPDATERANGE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UPDATERANGE - FINE");
            }

            return result;
        }

        public bool DeleteRange(Range range)
        {
            //clsLog.Info(">>> DELETERANGE - INIZIO");
            bool result = true;

            try
            {
                this.unitOfWork.Range.Remove(range);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                result = false;
                clsLog.Error("DELETERANGE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> DELETERANGE - FINE");
            }

            return result;
        }

        //public IList<RangeClient> GetRangeClient(int idRange)
        //{
        //    //clsLog.Info(">>> GETRANGECLIENT - INIZIO");

        //    IList<RangeClient> lstRangeClient = new List<RangeClient>();

        //    try
        //    {
        //        Expression<Func<RangeClient, bool>> expr = e => e.IdRange == idRange;
        //        lstRangeClient = this.unitOfWork.RangeClient.GetAll(null, null, "IdAreaChartRangeNavigation,IdChartSeriesNavigation").ToList();
        //        //clsLog.Info(">>> Record trovati: " + lstRangeClient.Count());
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error("GETRANGECLIENT - Error: " + ex.ToString());
        //    }
        //    finally
        //    {
        //        //clsLog.Info(">>> GETRANGECLIENT - FINE");
        //    }

        //    return lstRangeClient;
        //}
        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
