using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class ProcessingMethod
    {
        [Key]
        public int IdProcessingMethodology { get; set; }
        public string ProcessingMethodology { get; set; }
    }
}
