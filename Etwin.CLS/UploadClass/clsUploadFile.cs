using Etwin.BAL.BusinnessLogic.BLGenericDB;
using Etwin.BAL.BusinnessLogic.BLGlobalDB;
using Etwin.Model.GlobalModels;
using ETwin.BAL.FixModels;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etwin.CLS.UploadClass
{
    public class clsUploadFile
    {
        public async Task UploadDrawing(IList<AnalysisDrawing> lstFileToLoad, string cs)
        {
            try
            {
                AnalysisDrawing drawingPadre = new AnalysisDrawing();
                int idpadre = 0;
                //BlMaterialDb blMaterialDb = new BlMaterialDb();
                BlAnalysisDrawing blAnalysisDrawing = new BlAnalysisDrawing();
                int ct = 0;

                //load the parent assembly and remove it from the list
                if (lstFileToLoad.Count() > 1)
                {

                    if (lstFileToLoad.Where(x => x.FileName.Split('.').Last() == "iam").Count() > 0)
                    {
                        blAnalysisDrawing.InsertAnalysisDrawings(lstFileToLoad.Where(x => x.FileName.Split('.').Last() == "iam").First(), cs);
                        drawingPadre = blAnalysisDrawing.GetIdAnalysisDrawings(lstFileToLoad.Where(x => x.FileName.Split('.').Last() == "iam").First());
                        lstFileToLoad.Remove(lstFileToLoad.Where(x => x.FileName.Split('.').Last() == "iam").First());
                    }
                    else
                    {
                        blAnalysisDrawing.InsertAnalysisDrawings(lstFileToLoad.OrderBy(x => x.Path.Split('/').Length).First(), cs);
                        drawingPadre = blAnalysisDrawing.GetIdAnalysisDrawings(lstFileToLoad.OrderBy(x => x.Path.Split('/').Length).First());
                        lstFileToLoad.Remove(lstFileToLoad.OrderBy(x => x.Path.Split('/').Length).First());
                    }
                }
                //Load the children by binding them to the parent
                foreach (AnalysisDrawing modDrawing in lstFileToLoad.OrderBy(x => x.Path.Split('/').Length))
                {
                    if (idpadre != 0)
                    {
                        blAnalysisDrawing.InsertAnalysisDrawings(modDrawing, cs, idpadre);
                    }                    
                }
                
            }
            catch(Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
    }
}
