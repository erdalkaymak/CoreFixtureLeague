using DAL.Model;
using DAL.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLeague.Business
{
    public class FixtureTable
    {
        string matchedTeams;
        int count;
        List<string> myMatchingTeamList;
        List<string> myProperList;
        int x;
        FixtureDemoContext db = new FixtureDemoContext();

        public List<Team> GetAllTeamName()
        {
            TeamRepository rep = new TeamRepository(db);
            var list = rep.GetAll();
            return list;
        }

         public List<string> GetAllAvalilableMatchings()
         {
            myMatchingTeamList = new List<string>();
            var myTeamList = GetAllTeamName();
            var tempList = myTeamList;

            for (int i = 0; i < myTeamList.Count; i++)
            {
                for (int j = i; j < myTeamList.Count - 1; j++)
                {
                    matchedTeams = myTeamList[i].TeamName + "-" + myTeamList[j+1].TeamName;
                    myMatchingTeamList.Add(matchedTeams);                  
                }
            }
            return myMatchingTeamList;
        }

        public List<string> FillListProperMatching()
        {
            myProperList = new List<string>();
            myMatchingTeamList = GetAllAvalilableMatchings();

            for (int i = 0; i < GetAllTeamName().Count; i++)
            {
                
                for(int j = 0; j < myMatchingTeamList.Count; j++)
                {
                    var array = SplitForMe(myMatchingTeamList[j], '-');
                     
                    var list = myProperList.Skip(x).Take(9).Where(c => c.Contains(array[0]) || c.Contains(array[1])).FirstOrDefault();
                                       
                    if (list == null && !myProperList.Contains(myMatchingTeamList[j]))
                    {                       
                        myProperList.Add(myMatchingTeamList[j]);                      
                    }                   
                    
                }

                if (x != 153)
                {
                    x += 9;
                    count++;
                }
            }
           
            return myProperList;
           
        }

        public void FillFixtureSqlTable()
        {           
            TeamRepository repTeam = new TeamRepository(db);
            // FixtureMockRepository repMockFixture = new FixtureMockRepository();
            FixtureRepository repFixture = new FixtureRepository(db);

            if (repFixture.GetAll().Count == 153)
            {
                return;
            }

            Fixture[] myfixture = new Fixture[153];
                        
            int count = 0;

            DateTime startDate = new DateTime(2019,09,1);

            var sqlList = FillListProperMatching();

            for(int i = 0; i < sqlList.Count; i++)
            {
                var myArray = SplitForMe(sqlList[i], '-');
                var team1 = repTeam.FindMyTeamWithName(myArray[0],db);
                var team2 = repTeam.FindMyTeamWithName(myArray[1],db);

                myfixture[i] = new Fixture();
                myfixture[i].Team1 = team1;
                myfixture[i].Team2 = team2;
                myfixture[i].FixtureDate = startDate;
                repFixture.Insert(myfixture[i]);
                count++;

                if (count == 9)
                {
                    startDate = startDate.AddDays(7);
                    count = 0;
                }

            }
        }

        public string[] SplitForMe(string mystring,char separator)
        {
            var array = mystring.Split(separator);

            return array;
        }


        public void FillTeamTable()
        {
            TeamRepository repTeam = new TeamRepository(db);
            if(repTeam.GetAll().Count == 18)
            {
                return;
            }
            for (int i = 65; i < 83; i++)
            {
                int j = 1;
                int unicode = i;
                char character = (char)unicode;
                string text = character.ToString();
                Team[] myteam = new Team[16];
                myteam[j] = new Team();
                myteam[j].TeamName = text;
                repTeam.Insert(myteam[j]);
                j++;
            }

        }

    }
}
