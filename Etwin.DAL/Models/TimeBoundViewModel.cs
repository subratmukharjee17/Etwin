using Etwin.Model;
using System;
using System.Collections.Generic;
using System.Text;
using ETwin.BAL.FixModels;

namespace Etwin.DAL.Models
{
    public class TimeBoundViewModel
    {
        public IList<TimbratoreSetup> LvlTimbratore { get; set; }
        public IList<ItemContextButton> LstItemContextButtons { get; set; }
        public IList<ClsTimbratore> LstTimbratore { get; set; }
    }
}
