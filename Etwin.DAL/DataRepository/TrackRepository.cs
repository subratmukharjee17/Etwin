using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using Etwin.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository
{
    public class TrackRepository : Repository<Track>, ITrackRepository
    {
        private readonly ETwinContext _db;

        public TrackRepository(ETwinContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(Track track)
        {
            var objFromDb = this._db.Tracks.FirstOrDefault(s => s.Id == track.Id);

            if (objFromDb != null)
            {
                // AGGIORNO I VALORI
                this._db.Entry(objFromDb).CurrentValues.SetValues(track);

                // SALVO A DB
                this._db.SaveChanges();
            }
        }
    }
}
