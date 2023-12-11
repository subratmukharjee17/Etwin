using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using  Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace  Etwin.DAL.GlobalDataRepository
{
    public class WebTagsRepository : Repository<WebTag>, IWebTagsRepository
    {
        private readonly GlobalDbContext _db;

        public WebTagsRepository(GlobalDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WebTag WebTag)
        {
            var objFromDb = _db.WebTags.FirstOrDefault(s => s.IdWebTag == WebTag.IdWebTag);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                _db.Entry(objFromDb).CurrentValues.SetValues(WebTag);

                // SALVO A DB
                _db.SaveChanges();
            }
        }
    }
}
