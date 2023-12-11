using Etwin.Model;
using System.ComponentModel;
using System.Linq.Expressions;
using LogDll;
using System;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.DAL.DataRepository;
using System.Collections.Generic;
using System.Linq;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlProposalOrder : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlProposalOrder(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public ProposalOrder GetProposalById(int idProposal)
        {
            ProposalOrder proposal = new ProposalOrder();
            try
            {
                Expression<Func<ProposalOrder, bool>> expr = e => e.Id == idProposal;

                proposal = this.unitOfWork.Proposal.GetFirstOrDefault(expr);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return proposal;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
