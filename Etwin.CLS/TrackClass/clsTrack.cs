using Etwin.BAL.BusinnessLogic.BLGenericDB;
using Etwin.BAL.BusinnessLogic;
using Etwin.Model;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETwin.BAL;

namespace Etwin.CLS.TrackClass
{
    public class clsTrack
    {
        //public void CreatePlate(IList<Track> lstTrack)
        //{
        //    try
        //    {
        //        using (BlTrack blTrack = new BlTrack())
        //        {
        //            lstTrack = blTrack.GetTrack(1395);
        //            using (BlPlate blPlate = new BlPlate())
        //            {
        //                using (BlItemValue blItemValue = new BlItemValue())
        //                {
        //                    PlateLocation plateToUse = blPlate.GetPlateById(1);
        //                    PlateLocation plateToSave = blPlate.GetPlateById(2);
        //                    string ext = plateToUse.Path.Split('.').Last();
        //                    if (plateToSave.Path.Contains("#YEAR#"))
        //                    {
        //                        plateToSave.Path = plateToSave.Path.Replace("#YEAR#", DateTime.Now.Year.ToString());
        //                    }

        //                    //clsAutoCad2D clsAutoCad = new clsAutoCad2D();

        //                    foreach (Track track in lstTrack)
        //                    {
        //                        if (plateToSave.Path.Contains("#FILE#"))
        //                        {
        //                            plateToSave.Path = plateToSave.Path.Replace("#FILE#", track.Track1);
        //                        }
        //                        plateToSave.Path = plateToSave.Path + track.Track1 + '.' + ext;
        //                        BlMaterialDb blMaterialDb = new BlMaterialDb();
        //                        //IList<mod2DParameters> lstParameter = blMaterialDb.GetParameterWithValue(track.IdItem);
        //                       //clsAutoCad.Document = plateToUse.Path;
        //                        //clsAutoCad.GetParameterNamePlat(lstParameter, plateToSave.Path);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //}
    }
}
