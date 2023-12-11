using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Etwin.DAL.Models
{
    public class ReportOrderWithPhaseList
    {
        public string Order { get; set; }
        public string RigaOrdine { get; set; }
        public string Priorita { get; set; }
        public string Protocollo { get; set; }
        public string Week { get; set; }
        public string Cliente { get; set; }
        public string RifOrdine { get; set; }
        public string DataOrdine { get; set; }
        public string DataConsegna { get; set; }
        public string OrderQty { get; set; }
        public string Categoria { get; set; }
        public int? RowId { get; set; }
        public string StatoOrdine { get; set; }
        public string Disegno { get; set; }
        public string StatoDisegno { get; set; }
        public string NoteOrdine { get; set; }
        public string IdModulo { get; set; }
        public string Modello { get; set; }
        public string Tipologia { get; set; }
        public int? OrderRow { get; set; }
        public string Taglio { get; set; }
        public string Alettatura { get; set; }
        public string Piegatura { get; set; }
        public string Montaggio { get; set; }
        public string Mandrinatura { get; set; }
        public string LavaggioPC { get; set; }
        public string SaldaturaCurve { get; set; }
        public string SaldaturaCollettori { get; set; }
        public string CollettoriSuBatteria { get; set; }
        public string Prova { get; set; }
        public string Collaudo { get; set; }
        public string ControlliCND { get; set; }
        public string Decapaggio { get; set; }
        public string ControlliEsterni { get; set; }
        public string ChiusuraTenute { get; set; }
        public string Asciugatura { get; set; }
        public string Assemblaggio { get; set; }
        public string FaseAccessori { get; set; }
        public string Finitura { get; set; }
        public string ControlloQualita { get; set; }
        public string Imballo { get; set; }
        public string RiparazioneBatterie { get; set; }
        public string SaldaturaCamini { get; set; }
        public string SaldaturaStrutture { get; set; }
        public string SaldaturaGambe { get; set; }
        [Column("Taglio/ForCollettori")]
        public string TaglioForCollettori { get; set; }
        public string ErroreProgetto { get; set; }
        public string PuliziaAmbito { get; set; }
        public string FasiProgetto { get; set; }
        public string Ruota { get; set; }
        public string Telaio { get; set; }
        public string Freno { get; set; }
        public string Reggisella { get; set; }
        public string TaglioconLama { get; set; }
        public string TaglioconDisco { get; set; }
        public string TaglioLaser { get; set; }
        public string TaglioPlasma { get; set; }
        public string TaglioconMola { get; set; }
        public string VisualizzaCAD { get; set; }
        public string CartellaCAD { get; set; }
        public string CartellaXOFF { get; set; }
        public string DiametroTubi { get; set; }
        public string SpessoreTubi { get; set; }
        public string SviluppoTubiero { get; set; }
        public string InterasseCurve { get; set; }
        public string AltezzaAletta { get; set; }
        public string SpessoreAletta { get; set; }
        public string SviluppoAlettato { get; set; }
        public string DataConsegnaGestionale { get; set; }
        
        
    }
}
