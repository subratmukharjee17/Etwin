using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewDurataCommesse
    {
        [Required]
        [StringLength(15)]
        public string Commessa { get; set; }
        public int? DurataCommessaSecondi { get; set; }
    }
}
