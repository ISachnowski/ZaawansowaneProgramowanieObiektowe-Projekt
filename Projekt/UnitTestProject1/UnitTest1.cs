using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Projekt;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void getHomeTeamScore_ValidTeamScore_Equal()
        {
            int oczekiwany = 5;
            Match mecz = new Match(".", ".", 5, 1);

            int aktualny = mecz.getHomeTeamScore();

            Assert.AreEqual(oczekiwany, aktualny);
        }

        [TestMethod]
        public void getName_ValidTeamName_Equal()
        {
            string oczekiwany = "Borussia Dortmund";
            Team BVB = new Team(0, "Borussia Dortmund", 0, ".", 0, ".", ".");
            string aktualny = BVB.getName();

            Assert.AreEqual(oczekiwany, aktualny);
        }


    }
}
