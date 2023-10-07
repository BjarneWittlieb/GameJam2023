using System;
using UnityEngine;

namespace PlayerScripts
{
    public class RangedAttack : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        
        [SerializeField] private Transform shotPoint;
        [SerializeField] private Transform gun;
        
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
                FireProjectile();
        }

        private void FireProjectile()
        {
            var differance = Input.mousePosition - gun.transform.position;
            var rotZ       = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;
            gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
            
            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition  = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            Vector2 directionToMouse = (Vector2)(mouseWorldPosition - transform.position);
            float   angle            = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;

            gun.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            
            Instantiate(projectile, shotPoint.position, shotPoint.transform.rotation);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Input.mousePosition, 1f);
        }
    }
}