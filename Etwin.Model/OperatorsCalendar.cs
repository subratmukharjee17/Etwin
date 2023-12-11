using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("OperatorsCalendar")]
    public partial class OperatorsCalendar
    {
        [Key]
        public int IdOperatorCalendar { get; set; }
        [Required]
        [StringLength(30)]
        public string OperatorCode { get; set; }
        public int IdIndividualState { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        public int Interval { get; set; }
        [StringLength(50)]
        public string ModifierUser { get; set; }
        [StringLength(50)]
        public string Progress { get; set; }
        public bool? Allday { get; set; }

        [ForeignKey(nameof(OperatorCode))]
        [InverseProperty(nameof(Operator.OperatorsCalendars))]
        public virtual Operator OperatorCodeNavigation { get; set; }
    }
}
