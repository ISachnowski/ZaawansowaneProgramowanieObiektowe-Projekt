using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Match
    {
        //dane dot. danego meczu tj. nazwy drużyn, wynik, data etc.
        private int id;
        public string homeTeam { get; private set; }
        public int homeTeamScore { get; private set; }
        public string awayTeam { get; private set; }
        public int awayTeamScore { get; private set; }
        public DateTime date { get; private set; }

        public Match(string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore)
        {
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
            this.homeTeamScore = homeTeamScore;
            this.awayTeamScore = awayTeamScore;
            this.date = DateTime.Now;
        }

        public string getHomeTeam()
        {
            return this.homeTeam;
        }

        public string getAwayTeam()
        {
            return this.awayTeam;
        }

        public int getHomeTeamScore()
        {
            return this.homeTeamScore;
        }

        public int getAwayTeamScore()
        {
            return this.awayTeamScore;
        }

        
    }
}
