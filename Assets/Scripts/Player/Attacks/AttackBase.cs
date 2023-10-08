using Player.Projectiles;
using UnityEngine;

namespace Player.Attacks
{
    public abstract class AttackBase : MonoBehaviour
    {
        [SerializeField] protected GameObject projectile;
        [SerializeField] protected Transform  projectileSpawnPoint;
        [SerializeField] protected float      cooldown;
        private                    float      cooldownTimer;

        private void Update()
        {
            cooldownTimer -= Time.deltaTime;
        }

        protected abstract void FireInternal(int baseDamage);

        // ReSharper disable Unity.PerformanceAnalysis
        public void Fire(int baseDamage)
        {
            if (cooldownTimer > 0)
                return;

            cooldownTimer = cooldown;
            FireInternal(baseDamage);
        }

        protected float GetTargetAngle()
        {
            var mouseScreenPosition = Input.mousePosition;
            var mouseWorldPosition  = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            var directionToMouse = (Vector2)(mouseWorldPosition - transform.position);
            var angle            = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
            return angle;
        }
    }
}