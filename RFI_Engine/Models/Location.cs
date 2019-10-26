using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFI_Engine.Factories;

namespace RFI_Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();

        public List<MonsterEncounter> MonstersHere { get; set; } = new List<MonsterEncounter>();

        public void AddMonster(int monsterID, int chanceOfEncounter)
        {
            if (MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                MonstersHere.First(m => m.MonsterID == monsterID).ChanceOfEncounter = chanceOfEncounter;
            }
            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncounter));
            }
        }

        public Monster GetMonster()
        {
            if (!MonstersHere.Any())
            {
                return null;
            }

            int chances = MonstersHere.Sum(m => m.ChanceOfEncounter);
            int randomNumber = RandomNumberGenerator.NumberBetween(1, chances);
            int total = 0;

            foreach (MonsterEncounter monsterEncounter in MonstersHere)
            {
                total += monsterEncounter.ChanceOfEncounter;

                if (randomNumber <= total)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }

            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }
    }
}
