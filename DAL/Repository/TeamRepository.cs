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
        public Team FindMyTeamWithName(string name)
        {
            return _db.Teams.Where(c => c.TeamName == name).FirstOrDefault();
        }
    }
}
