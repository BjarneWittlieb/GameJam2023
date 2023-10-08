using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Enemy
{
    public class RangedEnemy : Enemy
    {
        public float fireRate = 900f;
        public int rangedDamage = 1;
        public PostProcessVolume fxVolume;
        [SerializeField] private Projectile projectile;
        [SerializeField] private Transform projectileSpawnPoint;

        private DateTime _nextFire = DateTime.Now;
        private GameObject _player;
        private object _playerRigid;

        // Start is called before the first frame update
        private void Start()
        {
            base.Start();
            _player = GameObject.Find("Player");
            projectile.fxVolume = fxVolume;
        }


        // Update is called once per frame
        protected override void Update()
        {
            if (DateTime.Now <= _nextFire) return;
            FireProjectile();
            _nextFire = DateTime.Now.AddMilliseconds(fireRate);
        }


        private void FireProjectile()
        {
            var mouseWorldPosition = _player.transform.position;

            var directionToMouse = (Vector2)(mouseWorldPosition - transform.position);
            var angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;


            var newBullet = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.Euler(0f, 0f, angle));
            var enemyProjectile = newBullet.GetComponent<Projectile>();
            enemyProjectile.damage = rangedDamage;
        }
    }
}