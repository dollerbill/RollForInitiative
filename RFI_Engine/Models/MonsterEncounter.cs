﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFI_Engine.Models
{
    public class MonsterEncounter
    {
        public int MonsterID { get; set; }
        public int ChanceOfEncounter { get; set; }

        public MonsterEncounter(int monsterID, int chanceOfEncounter)
        {
            MonsterID = monsterID;
            ChanceOfEncounter = chanceOfEncounter;
        }
    }
}
