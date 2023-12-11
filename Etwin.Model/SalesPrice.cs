using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class SalesPrice
    {
        [Key]
        public int Id { get; set; }
        public int IdOrderRow { get; set; }
        public int IdCurrency { get; set; }
        public int IdTaxCode { get; set; }
        public double Price { get; set; }

        [ForeignKey(nameof(IdOrderRow))]
        [InverseProperty(nameof(OrderRow.SalesPrices))]
        public virtual OrderRow IdOrderRowNavigation { get; set; }
    }
}
