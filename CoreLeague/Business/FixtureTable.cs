﻿using DAL.Model;
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
        List<string> shuffledcards;
        int x;
        
        public List<Team> GetAllTeamName()
        {
            TeamRepository rep = new TeamRepository();
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
                    shuffledcards = myMatchingTeamList.OrderBy(a => Guid.NewGuid()).ToList();

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

        public void FillSqlTable()
        {
            TeamRepository repTeam = new TeamRepository();
            // FixtureMockRepository repMockFixture = new FixtureMockRepository();
            FixtureRepository repFixture = new FixtureRepository();
            FixtureDemoContext db = new FixtureDemoContext();
            Fixture[] myfixture = new Fixture[153];
                        
            int count = 0;


            DateTime startDate = new DateTime(2019,09,1);

            var sqlList = FillListProperMatching();

            for(int i = 0; i < sqlList.Count; i++)
            {
                var myArray = SplitForMe(sqlList[i], '-');
                var team1 = repTeam.FindMyTeamWithName(myArray[0]);
                var team2 = repTeam.FindMyTeamWithName(myArray[1]);

                myfixture[i] = new Fixture();
                myfixture[i].Team1 = team1;
                myfixture[i].Team2 = team2;
                myfixture[i].FixtureDate = startDate;
                //repMockFixture.Insert(myfixture[i]);
                //db.Fixtures.Add(myfixture[i]);
                //db.SaveChanges();
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

    }
}
