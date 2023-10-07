using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomGeneration.Rewards
{
    public abstract class RoomRewardBase : MonoBehaviour
    {
        

        protected abstract void AddPlayerReward();

        protected void OnCollisionEnter2D(Collision2D other)
        {
            AddPlayerReward();

            Destroy(this.gameObject);
        }
    }

}