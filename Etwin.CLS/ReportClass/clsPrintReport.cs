using DevExpress.DocumentView;
using Etwin.BAL.BusinnessLogic.BLGenericDB;
using Etwin.BAL.BusinnessLogic;
using Etwin.Model;
using ETwin.BAL.FixModels;
using LogDll;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETwin.Documentations;
using ETwin.BAL;
using DevExpress.XtraReports.UI;
using Etwin.BAL.BusinnessLogic.BLogin;
using Etwin.CLS.DocumentClass;
using Etwin.CLS.GenericClass;
using BlLogin = Etwin.BAL.BusinnessLogic.BLogin.BlLogin;
using Etwin.Model.GlobalModels;

namespace Etwin.CLS.ReportClass
{
    public class clsPrintReport
    {
        public void PrintReport(object[] lstIdProcess)
        {
            try
            {

                using (BlPhasesList blPhasesList = new BlPhasesList())
                {
                    IList<modSchedaDiProcesso> lstHeader = new List<modSchedaDiProcesso>();
                    //loop over all processes that don't have a tab
                    foreach (object id in lstIdProcess)
                    {
                        IList<IDictionary<int, int>> lstDocValue = new List<IDictionary<int, int>>();
                        BlProcessesLists blProcessesLists = new BlProcessesLists();
                        ProcessesList pl = blProcessesLists.GetProcessesListById(int.Parse(id.ToString()));

                        //LOAD LIST Phase PER PROCESS
                        IList<PhasesList> lstPhaseList = blPhasesList.GetPhasePerIdProcessList(pl.IdProcessList);
                        //modSchedaDiProcessoHeader modHeader = new modSchedaDiProcessoHeader();
                        modSchedaDiProcesso modHeader = new modSchedaDiProcesso();

                        using (BlOrders blOrders = new BlOrders())
                        {
                            ////I get all the data I need to create the card
                            OrderRow ord = blOrders.GetOrderById((int)pl.IdOrderRow);
                            Order o = blOrders.GetOrdersById((int)ord.IdOrderParent);
                            BlCustomers blCustomers = new BlCustomers();
                            Customer cliente = blCustomers.GetCustomerByID((int)ord.IdCustomer);
                            BlOrderValues blOrderValues = new BlOrderValues();
                            IList<OrderValue> lstOrderValue = blOrderValues.GetOrderValueByIdOrderRow(ord.IdOrderRow);
                            BlOrderParameters blOrderParameters = new BlOrderParameters();
                            IList<OrderParameter> lstParam = blOrderParameters.GetAllOrderParameter();

                            lstDocValue.Add(new Dictionary<int, int>
                            {
                                { 1, (int)ord.IdItem },
                                { 3, ord.IdOrderRow },
                                { 4, pl.IdProcessList }
                            });

                            string nOrdine = o.Norder + "." + ord.OrderRow1;

                            var lstJoin = from ov in lstOrderValue
                                          join op in lstParam on ov.IdOrderParameter equals op.IdOrderParameter
                                          select new { op.OrderParameter1, ov.Value };


                            //Add all values ​​to the card template
                            foreach (var property in lstJoin)
                            {
                                if (!string.IsNullOrEmpty(property.Value.ToString()))
                                {
                                    switch (property.OrderParameter1)
                                    {
                                        case "IdModulo":
                                            modHeader.IdModulo = int.Parse(property.Value);
                                            break;
                                        case "Cliente":
                                            modHeader.Cliente = property.Value;
                                            break;
                                        case "Protocollo":
                                            modHeader.Protocollo = property.Value;
                                            break;
                                        case "Order":
                                            modHeader.NumeroOrdine = property.Value;
                                            break;
                                        case "Modello":
                                            modHeader.Modello = property.Value;
                                            break;
                                        case "Revisione":
                                            modHeader.Revisione = "00";
                                            break;
                                        case "Disegno":
                                            modHeader.Disegno = property.Value;
                                            break;
                                        case "NoteOrdine":
                                            modHeader.NoteOrdine = property.Value;
                                            break;
                                        case "OrderQty":
                                            modHeader.QuantitaOrdine = int.Parse(property.Value);
                                            break;
                                    }
                                }
                            }
                            modHeader.Revisione = "00";




                            if (lstJoin.Count() > 0)
                            {
                                //LOAD MODEL FOR DETAIL COMPILATION
                                foreach (PhasesList phaseLst in lstPhaseList)
                                {
                                    // loop through all the rows that will be inserted and add them to the model
                                    if (string.IsNullOrEmpty(phaseLst.MinOperatorLimit.ToString()))
                                    {
                                        phaseLst.MinOperatorLimit = 1;
                                    }

                                    BlPhasesCompany blPhaseCompany = new BlPhasesCompany();
                                    PhasesCompany pc = blPhaseCompany.GetPhaseCompanyById(phaseLst.IdPhaseCompany);
                                    BlMaterialDb blMaterialDb = new BlMaterialDb();
                                    modPhase mph = blMaterialDb.GetPhaseById(pc.IdPhase);

                                    modSchedaDiProcesso modSpd = new modSchedaDiProcesso();

                                    modSpd.IdModulo = modHeader.IdModulo;
                                    if (!string.IsNullOrEmpty(cliente.BusinessName))
                                    {
                                        modSpd.Cliente = cliente.BusinessName;
                                    }
                                    modSpd.Protocollo = modHeader.Protocollo;
                                    modSpd.NumeroOrdine = nOrdine;
                                    modSpd.Modello = modHeader.Modello;
                                    modSpd.Revisione = modHeader.Revisione;
                                    modSpd.Disegno = modHeader.Disegno;
                                    modSpd.NoteOrdine = modHeader.NoteOrdine;
                                    modSpd.QuantitaOrdine = modHeader.QuantitaOrdine;
                                    modSpd.NomeFase = mph.Phase;
                                    modSpd.NumeroOperatori = (int)phaseLst.MinOperatorLimit;
                                    modSpd.Tempo = (int?)phaseLst.EstimatedOperatorTime;
                                    //modSpd.NoteFase = phaseLst.IdPhaseNavigation.Description;


                                    lstHeader.Add(modSpd);

                                    lstDocValue.Add(new Dictionary<int, int>
                                    {
                                        { 5, phaseLst.IdPhaseList }
                                    });
                                }




                                //Load the datasource with the values ​​in the models
                                modSchedaDiProcesso schedaDiProcesso = new modSchedaDiProcesso();
                                SchedaDiProcesso sdp = new SchedaDiProcesso();
                                sdp.DataSource = lstHeader;
                                sdp.CreateDocument();
                                //create the document, add it to the database and the documents folder
                                clsGenericClass clsGrid = new clsGenericClass();
                                string cs = clsGrid.GetConnectionString();
                                BlLogin blLogin = new BlLogin();
                                cs = cs.Replace(" ", "");
                                string azienda = blLogin.GetCompanyByCs(cs);
                                string nomeFile = pl.ProcessCode.Replace("/", "");
                                string FilePath = "X:\\Virevo_area_dati\\DocumentiClienti\\" + azienda + "\\SchedeDiProcesso\\" + nomeFile + ".pdf";
                                sdp.ExportToPdf(FilePath);

                                clsArchive clsArchive = new clsArchive();
                                clsArchive.DocumentArchiveInsert(FilePath, 8, lstDocValue);
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
    }
}
