using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.IRepository
{
   public interface ITeamRepository : IBaseRepository<Team>
    {
        Team FindMyTeamWithName(string name,FixtureDemoContext db);
       
    }
}
