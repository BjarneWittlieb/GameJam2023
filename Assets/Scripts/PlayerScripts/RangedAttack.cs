using UnityEngine;

namespace PlayerScripts
{
    public class RangedAttack : MonoBehaviour
    {
        [SerializeField] private GameObject projectile;
        
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
                FireProjectile();
        }

        private void FireProjectile()
        {
            var transform1 = transform;
            Instantiate(projectile, transform1.position, transform1.rotation);
        }
    }
}