using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomGeneration.Rewards
{
    public class BubbleDamageReward : RoomRewardBase
    {
        protected override void AddPlayerReward()
        {
            rewardHandler.AddBubbleDamageReward();
        }
    }
}
