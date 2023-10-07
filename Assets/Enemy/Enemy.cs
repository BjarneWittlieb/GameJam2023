using PlayerScripts;
using System;
using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        protected int Health;
        protected float MovementSpeed;
        protected float AttackDistance;
        protected int Damage;

        protected virtual void Attack()
        {
            var player = new Rigidbody2D();
            
            
        }

        private void DoDamage(int damage)
        {
            
        }
        

        protected void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name == "player")
            {
               other.gameObject.GetComponent<PlayerHealth>().ProcessHit(this.Damage);
            } 
        }
    }
}