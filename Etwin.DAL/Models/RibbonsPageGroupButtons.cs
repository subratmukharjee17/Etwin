using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Etwin.DAL.Models
{
 public  class RibbonsPageGroupButtons
    {
        [Key]
        public int Id { get; set; }
        public int IdRibbonPageGroup { get; set; }
        public int IdRibbonPageButtonType { get; set; }
        //public string RibbonPageGroupButtonName 
        //{
        //    get { return RibbonPageGroupButtonName ?? "Null"; }
        //    set { RibbonPageGroupButtonName = value; }
        //}
        public string RibbonPageGroupButtonTitle { get; set; }
        public string  RibbonPageGroupButtonImage { get; set; }
        public int? IdRibbonPageGroupButtonActionType { get; set; }
        //public string RibbonPageGroupButtonAction { get; set; }
        public int? IdControl { get; set; }
        public int? IdControlType { get; set; }
        public int Ordine { get; set; }
        public int? RibbonStyle { get; set; }
        public bool? IsMdiParent { get; set; }
     
    }
}
