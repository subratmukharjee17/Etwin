using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewTimeLine1
    {
        public long? Id { get; set; }
        [StringLength(50)]
        public string NomeCognome { get; set; }
        [Required]
        [StringLength(50)]
        public string Processo { get; set; }
        [StringLength(150)]
        public string FaseProcesso { get; set; }
        [StringLength(15)]
        public string StatoFaseProcesso { get; set; }
        public int? OrdineFaseProcesso { get; set; }
        [Required]
        [StringLength(50)]
        public string FaseDiLavoro { get; set; }
        [StringLength(15)]
        public string StatoFaseLavoro { get; set; }
        public int OrdineFaseDiLavoro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataInizio { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataFine { get; set; }
        public TimeSpan? TempoImpiegato { get; set; }
    }
}
