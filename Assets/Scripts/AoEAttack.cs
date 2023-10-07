using Player;
using UnityEngine;

public class AoEAttack : MonoBehaviour
{
    public float indicatorTime = 1.25f;
    public int damage = 1;
    public float damageCooldown = 0.5f;
    public float lifeTime = 4f;
    private bool _active;
    private float _counter;
    private GameObject _player;
    private SpriteRenderer _sprite;

    private void Awake()
    {
        Destroy(gameObject, lifeTime + indicatorTime);
    }


    private void Start()
    {
        _player = GameObject.Find("Player");
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _counter += Time.deltaTime;
        if (!_active && _counter > indicatorTime)
        {
            _active = true;
            var newColor = _sprite.color;
            newColor.a = 1;

            _sprite.color = newColor;
            _counter = 10; // first hit should trigger instantly
        }
        else if (_active && _counter > damageCooldown)
        {
            if ((gameObject.transform.position - _player.transform.position).magnitude < 0.5)
            {
                _player.GetComponent<Health>().ProcessHit(damage);
                _counter = 0; // reactivate damage cooldown
            }
        }
    }
}