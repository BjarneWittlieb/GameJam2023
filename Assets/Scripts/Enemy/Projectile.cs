using System;
using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Enemy
{
    public class Projectile : MonoBehaviour
    {
        public PostProcessVolume fxVolume;
        [SerializeField] public int damage;

        [Header("Effects")] [SerializeField] protected GameObject hitEffect;
        [SerializeField] protected AudioClip hitSound;
        [SerializeField] protected AudioClip shotSound;

        [Header("Info")] [SerializeField] private float bulletSpeed;
        [SerializeField] private float lifeTime;
        private float isoFactor;
        private Vignette vignette;

        private void Awake()
        {
            var norm = transform.TransformDirection(Vector3.right);
            isoFactor = .5f + Math.Abs(norm.x) / 2f;
        }

        private void Start()
        {
            if (fxVolume && fxVolume.profile)
                fxVolume.profile.TryGetSettings(out vignette);

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
            switch (other.gameObject.name)
            {
                case "Ranged Enemy":
                    return;
                case "Enemy Projectile(Clone)":
                    return;
                case "Ranged Boss Variant":
                    return;
                case "Player":
                    other.gameObject.GetComponent<Health>().ProcessHit(damage);
                    break;
            }

            Destroy(gameObject);

            if (vignette) vignette.active = true;
            StartCoroutine(DisableVFXAfterDelay(0.1f));

            if (hitSound)
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }

        private IEnumerator DisableVFXAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            vignette.active = false;
        }
    }
}