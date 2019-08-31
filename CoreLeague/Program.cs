
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
            //fillTable();
            FixtureTable table = new FixtureTable();
            table.FillSqlTable();

            Console.ReadLine();


        }

        //tabloyu doldurmak için kullandım 1 kez

        //private static void fillTable()
        //{
        //    FixtureDemoContext db = new FixtureDemoContext();

        //    for (int i = 65; i < 83; i++)
        //    {
        //        int j = 1;
        //        int unicode = i;
        //        char character = (char)unicode;
        //        string text = character.ToString();
        //        Team[] myteam = new Team[16];
        //        myteam[j] = new Team();
        //        myteam[j].TeamName = text;
        //        db.Teams.Add(myteam[j]);
        //        db.SaveChanges();
        //        j++;
        //    }

        //}
    }
        

}

