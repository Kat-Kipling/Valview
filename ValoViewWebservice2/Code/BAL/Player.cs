﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ValoViewWebservice.App_Code.DAL;

namespace ValoViewWebservice.App_Code.BAL
{
    public class Player
    {
        public int id {  get; set; }
        public string userName { get; set; }
        public string team {  get; set; }
        public string country {  get; set; }
        public string rank { get; set; }
        public string division { get; set; }
        public string mainRole { get; set; }
        public string secondaryRole { get; set; }
        public string mainAgent { get; set; }

        public DataSet getAllPlayers()
        {
            return DataAccess.getAllPlayers();
        }
    }
}