using UnityEngine;

namespace Player.Attacks
{
    public class FireballAttack : AttackBase
    {
        private float cooldownTimer;

        [SerializeField] protected float      shotDelay = .33f;
        [SerializeField] protected GameObject fireball2;
        [SerializeField] protected GameObject fireball3;
        private                    int        baseDamage;

        protected override void FireInternal(int damage)
        {
            baseDamage = damage;
            Invoke(nameof(Fireball1), shotDelay * 0);
            Invoke(nameof(Fireball2), shotDelay * 1);
            Invoke(nameof(Fireball3), shotDelay * 2);
        }

        private void Fireball(GameObject fireball)
        {
            var angle            = GetTargetAngle();
            var firingProjectile = Instantiate(fireball, projectileSpawnPoint.position, Quaternion.Euler(0f, 0f, angle)).GetComponent<Projectiles.Projectile>();
            firingProjectile.SetBaseDamage(baseDamage);
        }

        private void Fireball1()
        {
            Fireball(projectile);
        }
        
        private void Fireball2()
        {
            Fireball(fireball2);
        }
        
        private void Fireball3()
        {
            Fireball(fireball3);
        }
    }
}
