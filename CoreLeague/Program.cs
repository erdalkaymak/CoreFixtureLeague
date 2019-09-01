
using CoreLeague.Business;
using DAL.Model;
using DAL.Repositorys;
using System;
using System.Collections.Generic;

namespace CoreLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FixtureTable table = new FixtureTable();

            table.FillTeamTable();
            table.FillFixtureSqlTable();

            Console.WriteLine("You can close this and look LeagueDB in SqlServer");
            Console.ReadLine();


        }

    }
        

}

