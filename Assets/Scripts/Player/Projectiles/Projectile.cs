using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [Header("Effects")]
        [SerializeField] protected GameObject hitEffect;
        [SerializeField] protected AudioClip hitSound;
        [SerializeField] protected AudioClip shotSound;

        [Header("Info")]
        [FormerlySerializedAs("bulletSpeed")] 
        [SerializeField] private float speed = 10;
        [SerializeField] public float damageMultiply;
        [SerializeField] private float lifeTime;
        private float isoFactor;

        private int baseDamage;

        private void Awake()
        {
            var norm = transform.TransformDirection(Vector3.right);
            isoFactor = .5f + Math.Abs(norm.x) / 2f;
        }

        protected virtual void Start()
        {
            if (shotSound)
                AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Invoke(nameof(DestroyInternal), lifeTime);
        }

        protected virtual void FixedUpdate()
        {
            transform.Translate(Vector3.right * (speed * isoFactor * Time.deltaTime), Space.Self);
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            DestroyInternal();
            
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy.Enemy>().TakeDamage((int) (baseDamage * damageMultiply));
            }

            if (hitEffect)
                Instantiate(hitEffect, other.contacts[0].point, quaternion.identity);

            if (hitSound)
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }

        protected virtual void DestroyInternal()
        {
            Destroy(gameObject);
        }

        public void SetBaseDamage(int baseDamage)
        {
            this.baseDamage = baseDamage;
        }
    }
}