using DevExpress.DataProcessing.InMemoryDataProcessor;
using Etwin.BAL.BusinnessLogic;
using Etwin.Model;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etwin.CLS.DocumentClass
{
    public class clsArchive
    {
        public void DocumentArchiveInsert(string path, int DocumentType, IList<IDictionary<int, int>> lstValue)
        {
            try
            {
                //I take the documents
                BlDocumentArchive blDocumentArchive = new BlDocumentArchive();
                IList<DocumentArchive> lstDoc = blDocumentArchive.GetDocumentArchive(path);
                int rev = 0;
                if (lstDoc.Count() > 0)
                {
                    DocumentArchive isPresent = lstDoc.OrderByDescending(r => r.CreationDate).First();
                    IList<DocumentArchiveValue> value = blDocumentArchive.GetValueByIdDocument(isPresent.Id);
                    rev = int.Parse(value.Where(x => x.IdDocumentArchiveParameter == 2).First().Value);

                }
                //I'll take the latest revision
                lstValue.Add(new Dictionary<int, int>
                    {
                        {2, rev }
                    });
                //I create the document
                FileInfo file = new FileInfo(path);
                DocumentArchive da = new DocumentArchive();
                da.IdDocumentType = DocumentType;
                da.FileName = file.Name;
                da.FullPathEtwin = file.FullName;
                da.FileDimension = (file.Length / (1024 * 1024)).ToString();
                da.FileCreationDate = file.CreationTime;
                da.LastModifyDate = file.LastWriteTime;
                da.Content = File.ReadAllBytes(path);
                da.CreatedBy = "ETwin";
                blDocumentArchive.AddDocumentArchive(da);
                //I add all the parameters
                foreach (IDictionary<int, int> v in lstValue)
                {
                    foreach (KeyValuePair<int, int> kvp in v)
                    {
                        DocumentArchiveValue dav = new DocumentArchiveValue();
                        dav.IdDocumentArchive = da.Id;
                        dav.IdDocumentArchiveParameter = kvp.Key;
                        dav.Value = kvp.Value.ToString();
                        blDocumentArchive.AddDocumentArchiveValue(dav);
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
    }
}
