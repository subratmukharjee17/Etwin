using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class Customer
    {
        public Customer()
        {
            OrderRows = new HashSet<OrderRow>();
            SalesLists = new HashSet<SalesList>();
        }

        [Key]
        public int IdCustomer { get; set; }
        [StringLength(50)]
        public string CustomerIdentityCode { get; set; }
        [StringLength(50)]
        public string BusinessName { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Cap { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string Province { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string TelephoneNumber { get; set; }
        [StringLength(50)]
        public string Fax { get; set; }
        [StringLength(50)]
        public string VatNumber { get; set; }
        [StringLength(50)]
        public string FiscalCode { get; set; }
        [StringLength(400)]
        public string Note { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [InverseProperty(nameof(OrderRow.IdCustomerNavigation))]
        public virtual ICollection<OrderRow> OrderRows { get; set; }
        [InverseProperty(nameof(SalesList.IdCustomerNavigation))]
        public virtual ICollection<SalesList> SalesLists { get; set; }
    }
}
