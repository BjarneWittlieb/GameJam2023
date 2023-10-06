using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace PlayerScripts
{

    public class PlayerHealth : MonoBehaviour
    {
        public int maxHealth = 4;
        private int health;

        public delegate void HitEvent(int damage);
        public static event HitEvent OnHit;

        public delegate void HealthChagne(int health, int totalHealth);
        public static event HealthChagne OnHealthChange;

        public delegate void DeathEvent();
        public static event DeathEvent OnDeath;

        // Start is called before the first frame update
        void Start()
        {
            health = maxHealth;
            OnHit += ProcessHit;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void ProcessHit(int damage)
        {
            health -= damage;
            
            if (OnHealthChange != null) OnHealthChange(health, maxHealth);

            if (health > 0)
            {
                return;
            }
            

            if (OnDeath != null) OnDeath();
        }
    }
}
