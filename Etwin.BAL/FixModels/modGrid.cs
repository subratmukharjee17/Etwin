using Etwin.Model;
using System.ComponentModel;

namespace ETwin.BAL.FixModels
{
    public class modGrid
    {
        public int Id { get; set; }
        public string GridName { get; set; } = null!;
        public string Caption { get; set; } = null!;
        public BindingList<GridsColumn> GridsColumns { get; set; }
    }
}
