using System;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class Projectile : MonoBehaviour
    {
        [Header("Effects")] [SerializeField] protected GameObject hitEffect;

        [SerializeField] protected AudioClip hitSound;
        [SerializeField] protected AudioClip shotSound;

        [Header("Info")] [SerializeField] private float bulletSpeed;

        [SerializeField] public float damageMultiply;
        [SerializeField] private float lifeTime;
        private float isoFactor;

        private int baseDamage;

        private void Awake()
        {
            var norm = transform.TransformDirection(Vector3.right);
            isoFactor = .5f + Math.Abs(norm.x) / 2f;
        }

        private void Start()
        {
            if (shotSound)
                AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(gameObject, lifeTime);
        }

        private void FixedUpdate()
        {
            transform.Translate(Vector3.right * (bulletSpeed * isoFactor * Time.deltaTime), Space.Self);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy.Enemy>().TakeDamage((int) (baseDamage * damageMultiply));

                if (hitEffect)
                    Instantiate(hitEffect, other.contacts[0].point, quaternion.identity);

                if (hitSound)
                    AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }

            Destroy(gameObject);
        }

        public void SetBaseDamage(int baseDamage)
        {
            this.baseDamage = baseDamage;
        }
    }
}