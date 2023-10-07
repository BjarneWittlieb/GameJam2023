using System;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private AudioClip  hitSound;
    [SerializeField] private AudioClip  shotSound;
    [SerializeField] private float      bulletSpeed;
    [SerializeField] private float      lifeTime;
    private                  float      isoFactor;

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
        Debug.Log($"hit {other.gameObject.name}");

        if (hitEffect)
            Instantiate(hitEffect, other.contacts[0].point, quaternion.identity);

        if (hitSound)
            AudioSource.PlayClipAtPoint(hitSound, transform.position);

        Destroy(gameObject);
    }
}