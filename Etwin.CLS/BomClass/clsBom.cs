using Etwin.BAL.BusinnessLogic;
using Etwin.BAL.BusinnessLogic.BLGenericDB;
using Etwin.BAL.BusinnessLogic.BLGlobalDB;
using Etwin.CLS.WareHouseMovementClass;
using Etwin.Model;
using Etwin.Model.GlobalModels;
using ETwin.BAL.FixModels;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etwin.CLS.BomClass
{
    public class clsBom
    {

        #region VARS
        private readonly BlBom blBom = new BlBom();
        private readonly BlItemParameter blItemParameter = new BlItemParameter();
        #endregion

        public void GetBomPhase(IList<PhasesList> lstPhaseList)
        {
            try
            {
                //BlGeneralSettingActive blGeneralSettingDetail = new BlGeneralSettingActive();
                ////I check the settings to see if bomphases are enabled
                //GeneralSettingActive detail = blGeneralSettingDetail.GetgeneralSettingDetailByIdGeneralSetting(1);
                //if (detail.Value == true)
                //{
                //cycle on phaseslists
                foreach (PhasesList pl in lstPhaseList)
                {
                    int ct = 0;
                    using (BlProcessesLists blProcessesLists = new BlProcessesLists())
                    {
                        //I take the ProcessesList
                        ProcessesList prl = blProcessesLists.GetProcessesListById(pl.IdProcessList);

                        using (BlItemValue blItemValue = new BlItemValue())
                        {
                            IList<ItemValue> lstIV = blItemValue.GetItemValueByItem((int)prl.IdItem);
                            //I take the Article type
                            string type = lstIV.Where(x => x.IdItemParameterCompany == 1).Select(x => x.ItemValue1).First().ToString();

                            IList<ItemType> lstItemTypeFiglio = blItemParameter.GetItemType(type);

                            if (lstItemTypeFiglio.Count > 0)
                            {
                                //I take the PhaseItemParameters of that type
                                BlPhaseItemParameter blPhaseItemParameter = new BlPhaseItemParameter();
                                IList<ItemType> lstItemTypePadre = blItemParameter.GetItemType(lstItemTypeFiglio.Select(x => x.IdTypeParent).First().ToString());
                                IList<PhasesItemParameter> lstItemParameter = blPhaseItemParameter.GetPhaseItemParameter(pl.IdPhaseCompany);

                                foreach (PhasesItemParameter pip in lstItemParameter)
                                {
                                    ItemParameter itemP = blItemParameter.GetItemParameter(pip.IdItemParameter);
                                    //Replace the name with the parent's type
                                    if (itemP.ItemParameterName.Contains(lstItemTypeFiglio.Select(x => x.Type).First().ToString()))
                                    {
                                        if (lstItemTypePadre.Count() > 0)
                                        {
                                            //if I find at least one with that name I increase the counter
                                            string risultato = itemP.ItemParameterName.Replace(lstItemTypeFiglio.Select(x => x.Type).First().ToString(), lstItemTypePadre.Select(x => x.Type).First().ToString());
                                            //modItemParameterGlobal IP = blMaterialDb.GetItemParameter("where ItemParameterName = '" + risultato + "'");
                                            ItemParameter IP = blItemParameter.GetItemParameterByName(risultato );
                                            if (IP != null)
                                            {
                                                ct++;
                                            }
                                        }
                                    }
                                }
                                if (ct > 0)
                                {
                                    //if the counter is greater than 0 I insert the bomphase
                                    BomPhase bomPhase = new BomPhase();
                                    bomPhase.IdPhaseList = pl.IdPhaseList;
                                    bomPhase.IdItem = (int)prl.IdItem;
                                    using (BlBomPhases blBomPhases = new BlBomPhases())
                                    {
                                        BomPhase bp = blBomPhases.ExistBomPhase(bomPhase);
                                        if (bp.IdItem == null)
                                        {
                                            blBomPhases.AddBomPhase(bomPhase);
                                        }

                                    }

                                    Bom b = blBom.GetBomByItem((int)prl.IdItem);
                                    clsWareHouseMovement clsWareHouseMovement = new clsWareHouseMovement();
                                    clsWareHouseMovement.InsertMovement(prl, b);

                                }
                            }
                        }
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

    }
}
