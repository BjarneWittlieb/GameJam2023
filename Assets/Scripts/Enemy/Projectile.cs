using Player;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Enemy
{
    public class Projectile : MonoBehaviour
    {
        public PostProcessVolume fxVolume;
        public int damage;
        protected AudioClip hitSound;
        protected AudioClip shotSound;
        private Vignette vignette;
        private float lifeTime;

        private void Start()
        {
            if (shotSound)
                AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(gameObject, lifeTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            switch (other.gameObject.name)
            {
                case "Ranged Enemy":
                    return;
                case "Player":
                    other.gameObject.GetComponent<Health>().ProcessHit(damage);
                    break;
            }

            vignette.active = true;

            if (hitSound)
                AudioSource.PlayClipAtPoint(hitSound, transform.position);

            Destroy(gameObject);
        }
    }
}