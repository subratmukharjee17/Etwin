﻿using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.GlobalModels;

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IMaterialCodeValueRepository : IRepository<MaterialCodeValue>
    {
        void Update(MaterialCodeValue materialCodeValue);
    }
}
