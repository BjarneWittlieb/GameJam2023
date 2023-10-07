using Player;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Enemy
{
    public class Projectile : Player.Projectile
    {
        public PostProcessVolume fxVolume;
        private Vignette vignette;

        private void Start()
        {
            fxVolume.profile.TryGetSettings(out vignette);
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