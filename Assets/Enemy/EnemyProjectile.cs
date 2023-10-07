using PlayerScripts;
using Unity.Mathematics;
using UnityEngine;

namespace Enemy
{
    public class EnemyProjectile : Projectile
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            switch (other.gameObject.name)
            {
                case "Ranged Enemy":
                    return;
                case "Player":
                    other.gameObject.GetComponent<PlayerHealth>().ProcessHit(damage);
                    break;
            }


            if (hitEffect)
                    Instantiate(hitEffect, other.contacts[0].point, quaternion.identity);
            
            if (hitSound) 
                AudioSource.PlayClipAtPoint(hitSound, transform.position);

            Destroy(gameObject);
        }
    }
}