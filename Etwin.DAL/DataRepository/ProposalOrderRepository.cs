using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class ProposalOrderRepository : Repository<ProposalOrder>, IProposalOrderRepository
    {
        private readonly ETwinContext _db;

        public ProposalOrderRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(ProposalOrder proposal)
        {
            var objFromDb = this._db.ProposalOrders.FirstOrDefault(s => s.Id == proposal.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(proposal);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
