using Player;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        public int health = 1;
        public int damage = 1;
        public float stunTimer;
        public float stunDuration = 0.2f;

        private bool isDead = false;

        [SerializeField] protected GameObject deathEffect;

        protected Animator[] animators;

        /// <summary>
        ///     <para>The lower the bigger the recoil of the player. 15 Seems nice</para>
        /// </summary>
        public int recoilDivisor = 15;

        private readonly string playerName = "Player";
        protected float AttackDistance;
        protected float MovementSpeed;

        protected virtual void Update()
        {
            stunTimer -= Time.deltaTime;
        }

        protected void Start()
        {
            animators = GetComponentsInChildren<Animator>() ?? new Animator[] {};  
        }

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
            if (isDead) return;
            if (other.gameObject.name != playerName) return;
            var enemyVelocity = gameObject.GetComponent<NavMeshAgent>().velocity.normalized / recoilDivisor;
            other.rigidbody.AddForce(enemyVelocity, ForceMode2D.Force);
            Debug.Log($"Player was hit with {damage} Damage");
            other.gameObject.GetComponent<Health>().ProcessHit(damage);
        }

        protected virtual void Attack()
        {
            var player = new Rigidbody2D();
        }

        protected virtual void OnDeath()
        {
        }

        private void DoDamage(int damage)
        {
        }



        public bool TakeDamage(int amount)
        {
            health -= amount;

            if (health <= 0)
            {
                ProgressionTracking.Instance.KillEnemy();

                AnimateDie();
                OnDeath();
                isDead = true;
                // Destroy with delay
                Destroy(gameObject, 1.5f);
                
                if (deathEffect)
                    Instantiate(deathEffect, transform.position, quaternion.identity);

                return true;
            } else
            {
                AnimateHit();
            }

            stunTimer = stunDuration;
            return false;
        }

        private void setHittingAnimationFalse()
        {
            foreach (var animator in animators)
            {
                animator.SetBool("hitting", false);
            }
        }

        private void AnimateHit()
        {
            if (animators == null) return;
            foreach(var animator in animators)
            {
                animator.SetBool("hitting", true);
                Invoke(nameof(setHittingAnimationFalse), .2f);
            }
        }

        private void AnimateDie()
        {
            if (animators == null) return;
            foreach (var animator in animators)
            {
                animator.SetBool("dying", true);
            }
        }
    }
}