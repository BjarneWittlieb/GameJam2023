using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        public int health = 1;
        public int damage = 1;
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
            Debug.Log($"Player was hit with {damage} Damage");
            other.gameObject.GetComponent<PlayerHealth>().ProcessHit(damage);
        }

        protected virtual void Attack()
        {
            var player = new Rigidbody2D();
        }

        private void DoDamage(int damage)
        {
        }
    }
}