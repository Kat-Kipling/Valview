using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValoViewWebservice.App_Code.BAL
{
    public class Match
    {
        public int id { get; set; }
        public int teamOneId { get; set; }
        public int teamTwoId { get; set; }
        public int mapId { get; set; }
        public int teamOneRoundsWon { get; set; }
        public int teamTwoRoundsWon { get; set; }
        public int winnerId { get; set; }
    }
}