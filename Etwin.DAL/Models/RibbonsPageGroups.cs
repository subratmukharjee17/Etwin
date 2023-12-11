using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Etwin.DAL.Model
{
    public class RibbonsPageGroups
    {
        [Key]
        public int Id { get; set; }
        public int IdRibbonPage { get; set; }
        public string RibbonPageGroupName { get; set; }
        public string RibbonPageGroupTitle { get; set; }
        public int IdItemLayout { get; set; }
        public int Ordine { get; set; }
     
    }
} 
