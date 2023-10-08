using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerRewardHandler: MonoBehaviour
    {
        PlayerMovement playerMovement;
        BubbleAttack playerAttack;
        Health playerHealth;

        public void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerAttack = GetComponentInChildren<BubbleAttack>();
            playerHealth = GetComponent<Health>();
        }

        public void AddDamageReward()
        {
            playerAttack.baseDamage += 1;
        }

        public void AddHealthReward() {
            playerHealth.UpgradeMaxHealth();
            
        }

        public void AddSpeedReward(int strength) { 
            
        }

        public void AddLifeRegReward(int strength) { 
            
        }

        public void AddBloodThirstyReward(int strength) { 
            // Idea, Killing enemies in succession yields higher damage
        }

        public void AddInnocenceRewanrd(int strength) { 
            // Idea, Not Hurting enemies will give them higher and higher procs
        }


    }
}
