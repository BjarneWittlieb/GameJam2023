﻿using UnityEngine;

namespace Player.Attacks
{
    public class BubbleAttack : AttackBase
    {

        protected override void FireInternal(int baseDamage)
        {
            var angle            = GetTargetAngle();
            var firingProjectile = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.Euler(0f, 0f, angle)).GetComponent<Projectiles.Projectile>();
            firingProjectile.SetBaseDamage(baseDamage);
        }
    }
}