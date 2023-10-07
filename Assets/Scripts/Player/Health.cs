using System;
using UnityEngine;

namespace Player
{
    public class Health : MonoBehaviour
    {
        public delegate void DeathEvent();

        public delegate void HealthChange(int health, int totalHealth);

        public int maxHealth = 4;
        private DateTime _lastHit;
        private int health;

        // Start is called before the first frame update
        private void Start()
        {
            health = maxHealth;
            if (OnHealthChange != null) OnHealthChange(health, maxHealth);
        }


        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K)) ProcessHit(1);
        }

        public static event HealthChange OnHealthChange;
        public static event DeathEvent OnDeath;

        public void ProcessHit(int damage)
        {
            var timeSinceLastHit = DateTime.Now - _lastHit;
            const int invulnerabilityCooldownInMS = 200;
            if (timeSinceLastHit.TotalMilliseconds < invulnerabilityCooldownInMS) return;
            health -= damage;
            _lastHit = DateTime.Now;

            if (OnHealthChange != null) OnHealthChange(health, maxHealth);

            if (health > 0) return;

            if (OnDeath != null) OnDeath();
        }

        public void UpgradeMaxHealth()
        {
            maxHealth += 1;
            health += 1;

            if (OnHealthChange != null) OnHealthChange(health, maxHealth);
        }
    }
}