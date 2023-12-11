using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ItemContextButton", Schema = "ETwin")]
    public partial class ItemContextButton
    {
        [Key]
        public int Id { get; set; }
        public int IdItem { get; set; }
        public int IdTimbratoreSetup { get; set; }
        [Column("HPosition")]
        public int Hposition { get; set; }
        [Column("VPosition")]
        public int Vposition { get; set; }
        public string BackColor { get; set; }
        public int? AnimationType { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string Font { get; set; }
        public int? FontStyle { get; set; }
        public int? FontSize { get; set; }
        public string ForeColor { get; set; }
        public int? IdActionType { get; set; }
        public string Action { get; set; }
        public int? IdControl { get; set; }

        [ForeignKey(nameof(IdTimbratoreSetup))]
        public virtual TimbratoreSetup IdTimbratoreSetupNavigation { get; set; }
    }
}
