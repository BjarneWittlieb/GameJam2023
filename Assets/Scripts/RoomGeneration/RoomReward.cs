using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RoomGeneration
{
    public class RoomReward
    {
        public static RoomReward[] Rewards = new RoomReward[]
        {
            new RoomReward { PrefabPath = "DamageReward" },
            new RoomReward { PrefabPath = "HealthReward" }
        };

        public string PrefabPath { get; set; }

        public GameObject GetRewardItem()
        {
            return Resources.Load("LevelPrefabians/Rewards/" + PrefabPath) as GameObject;
        }
    }
}
