using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewTimeLine
    {
        [Required]
        [StringLength(50)]
        public string NomeCognome { get; set; }
        [Required]
        [StringLength(50)]
        public string Processo { get; set; }
        [StringLength(150)]
        public string FaseProcesso { get; set; }
        [Required]
        [StringLength(15)]
        public string StatoFaseProcesso { get; set; }
        [Required]
        [StringLength(50)]
        public string FaseDiLavoro { get; set; }
        [Required]
        [StringLength(15)]
        public string StatoFaseLavoro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
    }
}
