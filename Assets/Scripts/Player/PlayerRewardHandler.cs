using Player;
using Player.Attacks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerRewardHandler: MonoBehaviour
    {
        PlayerMovement   playerMovement;
        AttackController playerAttack;
        Health           playerHealth;

        public void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerAttack = GetComponentInChildren<AttackController>();
            playerHealth = GetComponent<Health>();
        }

        public void AddBubbleDamageReward()
        {
            playerAttack.BubbleBaseDamage += 2;
        }

        public void AddFireDamageReward()
        {
            playerAttack.FireBaseDamage += 2;
        }

        public void AddHealthReward() {
            playerHealth.UpgradeMaxHealth();
            
        }

        public void AddSpeedReward() {
            playerMovement.speedMod += .25f;
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
