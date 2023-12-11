﻿using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IPedRepository : IRepository<Ped>
    {
        void Update(Ped ped);
    }
}