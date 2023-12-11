using Etwin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text;

namespace Etwin.DAL.Models
{
    public class InputControlPageViewModel
    {
        public string PageTitle { get; set; }
        //public Dictionary<string, object> PageControls { get; set; }
        public InputControlPageViewModel() { }

        public List<InputControlModel> InputControlModel { get; set; }
        public OperatorModel OperatorModel { get; set; }
    }

    public class OperatorModel
    {
        public string TableName { get; set; }
        public string OperatorCode { get; set; }
        public string BadgeCode { get; set; }
        public int IdOperatorRole { get; set; }
        public int IdDepartment { get; set; }
        public int IdOperatorState { get; set; }
        public string NameSurname { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? IdOperatorAccess { get; set; }
        public bool? IsGeneric { get; set; }
        public string AccountImage { get; set; }
        public int Active { get; set; } = 1;
    }
    public class InputKeyValuePair
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class InputControlModel
    {
        public int Id { get; set; }
        public int IdCustomStepWizard { get; set; }
        public string DatabaseTable { get; set; }
        public string TableColumn { get; set; }
        public int? IdPvt { get; set; }
        public string ColumnText { get; set; }
        public int IdColumnValueType { get; set; }
        public string ColumnValueType { get; set; }
        public int IdControlType { get; set; }
        public string ControlType { get; set; }
        public int? Length { get; set; }
        public int Sequences { get; set; }
        public string EffectiveValue { get; set; }
        public string Autocomplete { get; set; }
        public List<KeyValuePair<string, string>> Datasource { get; set; }
        public bool? ReadOnly { get; set; }
        public bool? Visible { get; set; }
        public bool Required { get; set; }
        public bool IsUnique { get; set; }
        public int Active { get; set; } = 1;
        // Add other properties here
    }
}
