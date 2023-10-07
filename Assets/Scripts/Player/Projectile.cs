using System;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class Projectile : MonoBehaviour
    {
        [Header("Effects")]
        [SerializeField] protected GameObject hitEffect;
        [SerializeField] protected AudioClip hitSound;
        [SerializeField] protected AudioClip shotSound;

        [Header("Info")] [SerializeField] private float bulletSpeed;

        [SerializeField] public int damage;
        [SerializeField] private float lifeTime;
        private float isoFactor;

        private                 Animator animator;
        private                 bool     pop;
        private static readonly int      Pop = Animator.StringToHash("pop");

        private void Awake()
        {
            var norm = transform.TransformDirection(Vector3.right);
            isoFactor = .5f + Math.Abs(norm.x) / 2f;
        }

        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
            
            if (shotSound)
                AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Invoke(nameof(DestroyInternal), lifeTime);
        }

        private void FixedUpdate()
        {
            if (pop)
                return;
            
            transform.Translate(Vector3.right * (bulletSpeed * isoFactor * Time.deltaTime), Space.Self);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("hit");
            if (pop)
                return;
            
            DestroyInternal();
            
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy.Enemy>().TakeDamage(damage);
            }

            if (hitEffect)
                Instantiate(hitEffect, other.contacts[0].point, quaternion.identity);

            if (hitSound)
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }

        private void DestroyInternal()
        {
            pop = true;
            animator.SetBool(Pop, pop);
            var stateInfo     = animator.GetCurrentAnimatorStateInfo(0);
            var remainingTime = stateInfo.length - stateInfo.normalizedTime * stateInfo.length;
            Destroy(gameObject, remainingTime);
        }
    }
}