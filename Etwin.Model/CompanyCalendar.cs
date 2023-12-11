using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("CompanyCalendar")]
    public partial class CompanyCalendar
    {
        [Key]
        public int IdCompanyCalendar { get; set; }
        [Required]
        [StringLength(30)]
        public string OperatorCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        public int? IdIndividualState { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [ForeignKey(nameof(OperatorCode))]
        [InverseProperty(nameof(Operator.CompanyCalendars))]
        public virtual Operator OperatorCodeNavigation { get; set; }
    }
}
