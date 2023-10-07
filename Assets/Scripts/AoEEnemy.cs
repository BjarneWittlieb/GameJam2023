using System;
using UnityEngine;

public class AoEEnemy : Enemy.Enemy
{
    public float fireRate = 900f;
    public int rangedDamage = 1;
    [SerializeField] private GameObject projectile;

    private DateTime _nextFire = DateTime.Now;
    private GameObject _player;
    private object _playerRigid;

    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.Find("Player");
    }


    // Update is called once per frame
    private void Update()
    {
        if (DateTime.Now <= _nextFire) return;
        SpawnAoE();
        _nextFire = DateTime.Now.AddMilliseconds(fireRate);
    }


    private void SpawnAoE()
    {
        var newBullet = Instantiate(projectile, _player.transform.position, Quaternion.Euler(0f, 0f, 0f));
        // var enemyProjectile = newBullet.GetComponent<EnemyProjectile>();
        // enemyProjectile.damage = rangedDamage;
    }
}