using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class RangedBoss : Enemy
    {
        public float fireRate = 900f;
        public int rangedDamage = 1;
        public int numberOfProjectiles = 5;
        public PostProcessVolume fxVolume;
        [SerializeField] private Projectile projectile;
        [SerializeField] private GameObject aoeProjectile;
        [SerializeField] private Transform projectileSpawnPoint;
        private int _firedProjectiles;

        private DateTime _nextFire = DateTime.Now;
        private GameObject _player;
        private object _playerRigid;

        // Start is called before the first frame update
        private void Start()
        {
            _player = GameObject.Find("Player");
            projectile.fxVolume = fxVolume;
        }


        // Update is called once per frame
        protected override void Update()
        {
            if (DateTime.Now <= _nextFire) return;
            if (_firedProjectiles == 0)
                SpawnAoE();

            FireProjectile();
            _firedProjectiles++;
            _firedProjectiles %= numberOfProjectiles;
            _nextFire = DateTime.Now.AddMilliseconds(_firedProjectiles != 0 ? 50 : fireRate);
        }

        protected override void OnDeath()
        {
            // win game
            SceneManager.LoadScene("Win-Scene", LoadSceneMode.Single);
        }


        private void FireProjectile()
        {
            var playerPosition = _player.transform.position;
            var scattering = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);


            var directionToMouse = (Vector2)(playerPosition + scattering - transform.position);
            var angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;


            var newBullet = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.Euler(0f, 0f, angle));
            var enemyProjectile = newBullet.GetComponent<Projectile>();
            enemyProjectile.damage = rangedDamage;
        }

        private void SpawnAoE()
        {
            var aimPosition = GetAimPosition();

            Instantiate(aoeProjectile, aimPosition, Quaternion.Euler(0f, 0f, 0f));


            // var enemyProjectile = newBullet.GetComponent<EnemyProjectile>();
            // enemyProjectile.damage = rangedDamage;
        }

        private Vector3 GetAimPosition()
        {
            return AoEAttack.GetAimPosition(_player.transform.position, 10, 2);
        }
    }
}