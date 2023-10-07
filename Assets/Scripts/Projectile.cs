using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip shotSound;
    [Header("Info")]
    [SerializeField] private float     bulletSpeed;
    [SerializeField] private int   damage;
    [SerializeField] private float knockback;
    [SerializeField] private float lifeTime;
    private                  float isoFactor;

    private void Awake()
    {
        var norm = transform.TransformDirection(Vector3.right);
        isoFactor = .5f + Math.Abs(norm.x) / 2f;
    }

    private void Start()
    {
        if (shotSound)
            AudioSource.PlayClipAtPoint(shotSound, transform.position);

        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * (bulletSpeed * isoFactor * Time.deltaTime), Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(other.gameObject.GetComponent<Enemy.Enemy>().TakeDamage(damage))
                return; // if enemy is dead
            //
            // var targetRigidbody    = other.gameObject.GetComponent<Rigidbody2D>();
            // Vector3   direction = -other.relativeVelocity.normalized; // Opposite to projectile velocity
            // other.gameObject.transform.Translate(direction);
            // targetRigidbody.AddForce(direction * other.relativeVelocity.magnitude * knockback, ForceMode2D.Impulse);
        }

        if (hitEffect)
            Instantiate(hitEffect, other.contacts[0].point, quaternion.identity);

        if (hitSound)
            AudioSource.PlayClipAtPoint(hitSound, transform.position);

        Destroy(gameObject);
    }
}