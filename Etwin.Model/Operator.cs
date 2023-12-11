using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class Operator
    {
        public Operator()
        {
            AssignmentOperatorCodeAssignedByNavigations = new HashSet<Assignment>();
            AssignmentOperatorCodeAssignedToNavigations = new HashSet<Assignment>();
            CompanyCalendars = new HashSet<CompanyCalendar>();
            Declarations = new HashSet<Declaration>();
            DeclarationsFutures = new HashSet<DeclarationsFuture>();
            DepartmentAccesses = new HashSet<DepartmentAccess>();
            OperatorValues = new HashSet<OperatorValue>();
            OperatorsCalendars = new HashSet<OperatorsCalendar>();
            PresenceDeclarations = new HashSet<PresenceDeclaration>();
        }

        [Key]
        [StringLength(30)]
        public string OperatorCode { get; set; }
        [StringLength(15)]
        public string BadgeCode { get; set; }
        public int? IdOperatorLogin { get; set; }
        public int IdOperatorRole { get; set; }
        public int IdDepartment { get; set; }
        public int IdOperatorState { get; set; }
        [Required]
        [StringLength(50)]
        public string NameSurname { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(15)]
        public string TelephoneNumber { get; set; }
        [StringLength(15)]
        public string Ip { get; set; }
        [StringLength(70)]
        public string Username { get; set; }
        [StringLength(15)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public int? IdOperatorAccess { get; set; }
        public bool? IsGeneric { get; set; }
        [StringLength(400)]
        public string AccountImage { get; set; }
        public int Active { get; set; }

        [InverseProperty(nameof(Assignment.OperatorCodeAssignedByNavigation))]
        public virtual ICollection<Assignment> AssignmentOperatorCodeAssignedByNavigations { get; set; }
        [InverseProperty(nameof(Assignment.OperatorCodeAssignedToNavigation))]
        public virtual ICollection<Assignment> AssignmentOperatorCodeAssignedToNavigations { get; set; }
        [InverseProperty(nameof(CompanyCalendar.OperatorCodeNavigation))]
        public virtual ICollection<CompanyCalendar> CompanyCalendars { get; set; }
        [InverseProperty(nameof(Declaration.OperatorCodeNavigation))]
        public virtual ICollection<Declaration> Declarations { get; set; }
        [InverseProperty(nameof(DeclarationsFuture.OperatorCodeNavigation))]
        public virtual ICollection<DeclarationsFuture> DeclarationsFutures { get; set; }
        [InverseProperty(nameof(DepartmentAccess.OperatorCodeNavigation))]
        public virtual ICollection<DepartmentAccess> DepartmentAccesses { get; set; }
        [InverseProperty(nameof(OperatorValue.OperatorCodeNavigation))]
        public virtual ICollection<OperatorValue> OperatorValues { get; set; }
        [InverseProperty(nameof(OperatorsCalendar.OperatorCodeNavigation))]
        public virtual ICollection<OperatorsCalendar> OperatorsCalendars { get; set; }
        [InverseProperty(nameof(PresenceDeclaration.OperatorCodeNavigation))]
        public virtual ICollection<PresenceDeclaration> PresenceDeclarations { get; set; }
    }
}
