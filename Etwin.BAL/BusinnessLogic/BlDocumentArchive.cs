using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.ComponentModel;
using LogDll;
using System.Linq.Expressions;
using Etwin.Model.Context;


namespace Etwin.BAL.BusinnessLogic
{
    public class BlDocumentArchive : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlDocumentArchive(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public void AddDocumentArchive(DocumentArchive da)
        {
            try
            {
                this.unitOfWork.DocumentArchive.Add(da);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void AddDocumentArchiveValue(DocumentArchiveValue dav)
        {
            try
            {
                this.unitOfWork.DocumentArchiveValue.Add(dav);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public DocumentArchive GetDocumentArchiveById(int id)
        {
            DocumentArchive docArchive = new DocumentArchive();
            try
            {
                Expression<Func<DocumentArchive, bool>> expr = e => e.Id == id;
                docArchive = this.unitOfWork.DocumentArchive.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return docArchive;
        }

        public IList<DocumentArchive> GetDocumentArchive(string path)
        {
            IList<DocumentArchive> lstDocArchive = new List<DocumentArchive>();
            try
            {
                Expression<Func<DocumentArchive, bool>> expr = e => e.FullPathEtwin == path;
                lstDocArchive = this.unitOfWork.DocumentArchive.GetAll(expr, null, "").ToList();
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstDocArchive;
        }

        public IList<DocumentArchiveValue> GetValueByIdDocument(int id)
        {
            IList<DocumentArchiveValue> lstValue= new List<DocumentArchiveValue>();
            try
            {
                Expression<Func<DocumentArchiveValue, bool>> expr = e => e.IdDocumentArchive == id;
                lstValue = this.unitOfWork.DocumentArchiveValue.GetAll(expr, null, "").ToList();
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstValue;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
