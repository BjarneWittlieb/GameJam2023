using System;
using PlayerScripts;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        public  int   health = 1;
        public  int   damage = 1;
        public float stunTimer;
        public  float stunDuration = 0.2f;

        /// <summary>
        ///     <para>The lower the bigger the recoil of the player. 15 Seems nice</para>
        /// </summary>
        public int recoilDivisor = 15;

        private readonly string playerName = "Player";
        protected float AttackDistance;
        protected float MovementSpeed;

        protected void OnCollisionEnter2D(Collision2D other)
        {
            ProcessHit(other);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            ProcessHit(other);
        }

        private void ProcessHit(Collision2D other)
        {
            if (other.gameObject.name != playerName) return;
            var enemyVelocity = gameObject.GetComponent<NavMeshAgent>().velocity.normalized / recoilDivisor;
            other.rigidbody.AddForce(enemyVelocity, ForceMode2D.Force);
            Debug.Log($"Player was hit with {damage} Damage");
            other.gameObject.GetComponent<PlayerHealth>().ProcessHit(damage);
        }

        protected virtual void Update()
        {
            stunTimer -= Time.deltaTime;
        }

        protected virtual void Attack()
        {
            var player = new Rigidbody2D();
        }

        private void DoDamage(int damage)
        {
        }

        public bool TakeDamage(int amount)
        {
            Debug.Log("hit");
            health -= amount;

            if (health <= 0)
            {
                Destroy(gameObject);
                return true;
            }
            
            stunTimer = stunDuration;
            return false;
        }
    }
}