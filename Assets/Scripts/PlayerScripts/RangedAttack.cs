using UnityEngine;

namespace PlayerScripts
{
    public class RangedAttack : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform projectileSpawnPoint;
        
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
                FireProjectile();
        }

        private void FireProjectile()
        {   
            var mouseScreenPosition = Input.mousePosition;
            var mouseWorldPosition  = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            var directionToMouse = (Vector2)(mouseWorldPosition - transform.position);
            var   angle            = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

            Transform projectileSpawnTransform;
            (projectileSpawnTransform = projectileSpawnPoint.transform).rotation = Quaternion.Euler(0f, 0f, angle);
            
            Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnTransform.rotation);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Input.mousePosition, 1f);
        }
    }
}