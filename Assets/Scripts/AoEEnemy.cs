using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class AoEEnemy : Enemy.Enemy
{
    public float fireRate = 900f;
    public int rangedDamage = 1;
    public int randomAimFactor = 10;
    [SerializeField] private GameObject projectile;
    
    private DateTime _nextFire = DateTime.Now;
    private GameObject _player;
    private int _aoeSpawnCounter;
    private Random _rnd;

    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.Find("Player");
        _rnd = new Random();
        _aoeSpawnCounter = 0;
    }


    // Update is called once per frame
    protected override void Update()
    {
        if (DateTime.Now <= _nextFire) return;
        SpawnAoE();
        _nextFire = DateTime.Now.AddMilliseconds(fireRate);
    }


    private void SpawnAoE()
    {
        Vector3 aimPosition = GetAimPosition();
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(new Vector2(aimPosition.x, aimPosition.y), 0.1f);

        while (hitColliders.Length > 0 )
        {
            aimPosition = GetAimPosition();
            hitColliders = Physics2D.OverlapCircleAll(new Vector2(aimPosition.x, aimPosition.y), 0.1f);
        }

        var newBullet = Instantiate(projectile, aimPosition, Quaternion.Euler(0f, 0f, 0f));

        _aoeSpawnCounter++;


        // var enemyProjectile = newBullet.GetComponent<EnemyProjectile>();
        // enemyProjectile.damage = rangedDamage;
    }

    private Vector3 GetAimPosition()
    {
        return _player.transform.position + new Vector3((float)(_rnd.NextDouble() - 0.5), (float)(_rnd.NextDouble() - 0.5), 0) * randomAimFactor * (float)(_rnd.NextDouble() / (Math.Sqrt(1 + _aoeSpawnCounter % 3)));
    }
}