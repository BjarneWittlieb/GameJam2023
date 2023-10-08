using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomGeneration.Rewards
{
    public class FireDamageReward : RoomRewardBase
    {
        protected override void AddPlayerReward()
        {
            rewardHandler.AddFireDamageReward();
        }
    }
}
