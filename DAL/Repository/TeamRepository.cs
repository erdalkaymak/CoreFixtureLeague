using DAL.Model;
using DAL.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositorys
{
    public class TeamRepository : BaseGenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(FixtureDemoContext db) : base(db)
        {
        }

        public Team FindMyTeamWithName(string name,FixtureDemoContext db)
        {
            return db.Teams.Where(c => c.TeamName == name).FirstOrDefault();
        }
    }
}
