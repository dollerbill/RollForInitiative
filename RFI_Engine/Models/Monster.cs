using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFI_Engine.Models;

namespace RFI_Engine.Models
{
    public class Monster : BaseNotificationClass
    {
        private int _hitPoints;

        public string Name { get; private set; }
        public string Image { get; set; }
        public int MaximumHitPoints { get; private set; }

        public int HitPoints
        {
            get { return _hitPoints; }
            private set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public int RewardExperience { get; private set; }
        public int RewardGold { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string image, int maximumHitPoints, int hitPoints,
            int rewardExperience, int rewardGold)
        {
            Name = name;
            Image = string.Format("/RFI_Engine;component/Images/Monsters/{0}", image);
            MaximumHitPoints = maximumHitPoints;
            HitPoints = hitPoints;
            RewardExperience = rewardExperience;
            RewardGold = rewardGold;
            
            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
