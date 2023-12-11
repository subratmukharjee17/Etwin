﻿using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IOperatorAccessRepository : IRepository<OperatorAccess>
    {
        void Update(OperatorAccess operatorAccess);
    }
}
