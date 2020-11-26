using System;
using System.Collections.Generic;
using System.Text;


namespace SoccerLeagues
{
    // https://docs.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-use-the-master-detail-pattern-with-hierarchical-data?view=netframeworkdesktop-4.8&viewFallbackFrom=netdesktop-5.0
    class League
    {
        public IEnumerable<Division> Divisions { get; private set; }
        private string name;

        public League()
        {
            name = GenName();

            var da = new Division()
            {
                Name = name.Substring(0, 2) + "-" + "Division A"
            };
            da.Teams.Add(new Team("Team A1"));
            da.Teams.Add(new Team("Team A2"));
            da.Teams.Add(new Team("Team A3"));
            var db = new Division() { Name = name.Substring(0, 2) + "-" + "Division B" };
            db.Teams.Add(new Team("Team B1"));
            db.Teams.Add(new Team("Team B2"));
            var dc = new Division() { Name = name.Substring(0, 2) + "-" + "Division C" };
            dc.Teams.Add(new Team("Team C1"));
            dc.Teams.Add(new Team("Team C2"));
            dc.Teams.Add(new Team("Team C3"));
            dc.Teams.Add(new Team("Team C4"));
            Divisions = new List<Division> { da, db, dc };


        }


        private string GenName()
        {
            string[] names = { "Mahesh", "Jeff Prosise", "Dave", "Allen O'neill",
                "Monica Rathbun", "Henry He", "Raj", "Mark Prime",
                "Tracey", "Mike Crown" };
            return names[new Random().Next(names.Length)];
        }


        public override string ToString()
        {
            return "league: " + name;
        }
    }

    class Division
    {
        public string Name { get; set; }
        public IList<Team> Teams { get; private set; } = new List<Team>();


    }

    class Team
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Team(string name)
        {
            Name = name;
            Score = new Random().Next(100);
        }
    }
}
