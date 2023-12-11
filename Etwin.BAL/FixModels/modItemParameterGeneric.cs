
namespace ETwin.BAL.FixModels
{
    public class modItemParameterGeneric
    {
        public int IdItemParameter { get; set; }
        public string ItemParameterName { get; set; }    
        public string ItemParameterDescription { get; set; }
        public int IdItemType { get; set; }
        public int IdDataType { get; set; }
        public string Calculation { get;set; }
        public int ExecutionOrder { get; set; }
        public bool isFilter { get; set; }
        public string FilterCommand { get; set; }
        public string Value { get; set; }
        public string Drawing { get; set; }
    }
}
