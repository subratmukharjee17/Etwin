using Etwin.BAL.BusinnessLogic;
using Etwin.BAL.BusinnessLogic.BLGenericDB;
using Etwin.BAL.BusinnessLogic.BLGlobalDB;
using Etwin.CLS.GenericClass;
using Etwin.Model;
using Etwin.Model.GlobalModels;
using ETwin.BAL.FixModels;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etwin.CLS.MacroProcessClass
{
    public class clsMacroProcess
    {
        #region VARS
        IList<PhasesList> LstPhasesList = new List<PhasesList>();
        IList<ProcessesList> LstProcessList = new List<ProcessesList>();
        clsGenericClass clsGenericClass = new clsGenericClass();
        #endregion

        #region CREATE PROCESSES

        #region GET MACRO PROCESSES
        public async void GetMacroProcesses(/*IList<int>? lstIdProposal = null*/)
        {
            try
            {
                BlMacroProcesses blMacroProcess = new BlMacroProcesses(this.clsGenericClass.GetConnectionString());
                BlOrders blOrders = new BlOrders(this.clsGenericClass.GetConnectionString());
                BlProcessesLists blProcessesLists = new BlProcessesLists(this.clsGenericClass.GetConnectionString());
                //if (lstIdProposal == null)
                //{
                //LANDING VERSION WITHOUT WAREHOUSE

                //GET ALL ORDER ROWS WITH STATE "Confermato"("open")
                IList<OrderRow> orderRows = blOrders.GetOrderRowsByState(5);

                foreach (OrderRow or in orderRows)
                {
                    //GET PROCESSES OF ORDER
                    IList<ProcessesList> processes = blProcessesLists.GetProcessesListByOrder(or.IdOrderRow);

                    if (processes.Count() == 0)
                    {
                        //THE ORDER HAS NO PROCESSES SO IT'S ADD TO LIST
                        this.AnalysingItem(or);
                    }
                }

                //}
                //else
                //{
                //    //PART WITH PROPOSAL ORDER
                //}
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #region ANALYSING ITEM
        public void AnalysingItem(OrderRow orderRow)
        {

            try
            {
                BlBom blBom = new BlBom(this.clsGenericClass.GetConnectionString());
                BlItemValue blItemValue = new BlItemValue(this.clsGenericClass.GetConnectionString());
                BlPhaseItemParameter blPhasesItemParameters = new BlPhaseItemParameter();

                if (orderRow.IdItem != null)
                {
                    //LIST TO SAVE PHASES THAT CAN BE PRODUCIBLE
                    IList<modPhaseProducible> lstPhaseProducible = new List<modPhaseProducible>();

                    //GET BOM BY ID ITEM
                    Bom b = blBom.GetBomByItem((int)orderRow.IdItem);
                    //GET ITEM VALUES
                    IList<ItemValue> lstValue = blItemValue.GetItemValueByItem((int)orderRow.IdItem);
                    //BASED ON THE PARAMETERS, GET PHASE LINK WITH PARAMETER
                    IList<PhasesItemParameter> lstPhaseItemparameter = blPhasesItemParameters.GetPhaseItemParameter();
                    //GET PARAMETERS WITH VALUE
                    List<int> lstParameterId = lstValue.Select(p => p.IdItemParameterCompany).ToList();
                    //FOR EACH PHASE, CHECK WHAT ARE THE PARAMETERS THAT I NEED
                    foreach (var group in lstPhaseItemparameter.GroupBy(x => x.IdPhase))
                    {
                        //COMPARE THE LIST lstParameterID WITH THE group
                        IEnumerable<int> intersectingIds = group.Select(p => p.IdItemParameter).Intersect(lstParameterId);
                        //IF THE NUMBER OF PARAMETERS ARE THE SAME
                        if (intersectingIds.Count() == group.Count())
                        {
                            bool trovato = false;
                            //CHECK IF THE PHASES ARE ALREADY INSERTED
                            foreach (modPhaseProducible pp in lstPhaseProducible)
                            {
                                if (pp.IdPhase == group.Key)
                                {
                                    trovato = true;
                                    break;
                                }
                            }
                            if (!trovato)
                            {
                                modPhaseProducible m = new modPhaseProducible();
                                m.IdPhase = group.Key;
                                m.IdBom = b.Id;
                                if (b.IdBomParent == null)
                                {
                                    m.IdBomParent = b.Id;
                                }
                                else
                                {
                                    m.IdBomParent = (int)b.IdBomParent;
                                }
                                //Add all the producible phases to the list
                                lstPhaseProducible.Add(m);
                            }
                        }
                    }
                    this.CreateMacroProcesses(lstPhaseProducible, b, orderRow);
                }

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #region CREATE MACRO PROCESSES
        public void CreateMacroProcesses(IList<modPhaseProducible> lstPhaseProducible, Bom b, OrderRow orderRow)
        {
            try
            {
                IList<int> lstMacroProcess = new List<int>();

                if (lstPhaseProducible.Count() > 0)
                {
                    using (BlPhasesSequences blPhasesSequences = new BlPhasesSequences())
                    {
                        IList<PhasesSequence> lstPhaseSequences = blPhasesSequences.GetAllPhasesSequence();
                        var relevantPhases = lstPhaseProducible.Where(x => x.IdBom == b.Id || x.IdBomParent == b.Id).Select(x => x.IdPhase).Distinct().ToList();
                        lstMacroProcess = lstPhaseSequences.Where(x => relevantPhases.Contains((int)x.IdPhaseCompany)).Select(x => x.IdMacroProcesses).Distinct().ToList();
                    }
                }


                using (BlMacroProcesses blMacroProcesses = new BlMacroProcesses(this.clsGenericClass.GetConnectionString()))
                {

                    using (BlGeneric blGeneric = new BlGeneric(this.clsGenericClass.GetConnectionString()))
                    {
                        // Loop through all the macroprocesses given to me by the Phases
                        foreach (int id in lstMacroProcess)
                        {
                            using (BlProcessesLists blProcessesLists = new BlProcessesLists(this.clsGenericClass.GetConnectionString()))
                            {
                                using (BlPhasesList blPhasesList = new BlPhasesList(this.clsGenericClass.GetConnectionString()))
                                {
                                    MacroProcess mp = blMacroProcesses.GetMacroProceeById(id);
                                    //Check if the macroprocess is active
                                    if (mp.Enabled == 1)
                                    {
                                        mp.Condition = mp.Condition.Replace("#IdBom#", b.Id.ToString());
                                        IList<int> lstInt = blGeneric.ExecuteSqlQuery<int>(mp.Condition);
                                        if (lstInt != null && lstInt.Count > 0)
                                        {
                                            int isVerify = lstInt[0];
                                            //I run the query to see if it is verified and can be added
                                            if (isVerify == null)
                                                isVerify = 0;

                                            string code = mp.MacroProcessCode + "." + Int32.Parse(DateTime.Now.Year.ToString().Substring(DateTime.Now.Year.ToString().Length - 2)) + "/" + (this.GetProgressivo()).ToString().PadLeft(5, '0');


                                            if (isVerify == 1)
                                            {
                                                //I create the processeslist
                                                ProcessesList pl = new ProcessesList();
                                                pl.IdOrderRow = orderRow.IdOrderRow;
                                                pl.IdMacroProcess = mp.IdMacroProcess;
                                                pl.ProcessCode = code;
                                                pl.ModifierUser = "eTwin";
                                                pl.ModifierDate = DateTime.Now;
                                                pl.IdItem = b.IdItem;
                                                blProcessesLists.AddProcessList(pl);

                                                this.LstProcessList.Add(pl);
                                                using (BlPhasesSequences blPhasesSequences = new BlPhasesSequences())
                                                {
                                                    //CREATE PHASE LIST BASED ON PHASE SEQUENCE
                                                    IList<int> lstPhasesSeq = blPhasesSequences.GetPhasesSequenceByIdProcess(mp.IdMacroProcess);
                                                    foreach (int i in lstPhasesSeq)
                                                    {
                                                        //from the Process I create the phaselists by checking if they don't already exist
                                                        PhasesList phasesList = new PhasesList();
                                                        phasesList.IdProcessList = pl.IdProcessList;
                                                        phasesList.IdPhaseCompany = i;
                                                        phasesList.ModifierUser = "eTwin";
                                                        phasesList.ModifierDate = DateTime.Now;
                                                        phasesList.IdPhaseListState = 3;
                                                        phasesList.LastStateChange = DateTime.Now;

                                                        bool Exist = blPhasesList.ExistPhaseList(phasesList);
                                                        if (Exist == false)
                                                        {
                                                            blPhasesList.AddPhaseslist(phasesList);
                                                            this.LstPhasesList.Add(phasesList);
                                                        }
                                                        else
                                                        {
                                                            blPhasesList.DeletePhasesList(phasesList);
                                                            blPhasesList.AddPhaseslist(phasesList);
                                                            this.LstPhasesList.Add(phasesList);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #endregion

        #region GET PROGRESSIVO
        public int GetProgressivo()
        {
            int progressivo = 0;
            try
            {
                using (BlProcessesLists blProcessesLists = new BlProcessesLists(this.clsGenericClass.GetConnectionString()))
                {
                    int year = DateTime.Now.Year % 100;
                    IList<ProcessesList> lstProcess = blProcessesLists.GetAllProcessesListOfYear(year);
                    progressivo = lstProcess.Select(p => Int32.Parse(p.ProcessCode.Split('/')[1].Split('.')[0]))
                            .DefaultIfEmpty(0)
                            .Max() + 1;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return progressivo;
        }
        #endregion
    }
}
