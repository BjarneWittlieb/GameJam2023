using Player.Projectiles;
using UnityEngine;

namespace Player
{
    public class BubbleAttack : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform projectileSpawnPoint;
        [SerializeField] private float cooldown;
        private float cooldownTimer;

        public int fireBaseDamage = 10;
        public int bubbleBaseDamage = 10;

        private void Update()
        {
            cooldownTimer -= Time.deltaTime;

            if (Input.GetKey(KeyCode.Mouse0))
                FireProjectile();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Input.mousePosition, 1f);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void FireProjectile()
        {
            if (cooldownTimer > 0)
                return;

            cooldownTimer = cooldown;

            var mouseScreenPosition = Input.mousePosition;
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            var directionToMouse = (Vector2)(mouseWorldPosition - transform.position);
            var angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

            Projectile firingProjectile = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.Euler(0f, 0f, angle)).GetComponent<Projectile>();
            

            firingProjectile.SetBaseDamage(getCurrentBaseDamage());

        }

        private int getCurrentBaseDamage()
        {
            return ProgressionTracking.Instance.CurrentRoom.IsGood ? fireBaseDamage : bubbleBaseDamage;
        }
    }
}