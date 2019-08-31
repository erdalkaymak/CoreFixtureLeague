using DAL.Model;
using DAL.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositorys
{
    public class FixtureMockRepository : BaseGenericRepository<Fixture>, IFixtureRepository
    {
        public static List<Fixture> myMockFixture;

        public override void Insert(Fixture entity)
        {
            myMockFixture = new List<Fixture>();
            myMockFixture.Add(entity);
        }
    }
}
