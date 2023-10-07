using System;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private AudioClip  hitSound;
    [SerializeField] private float      bulletSpeed;
    [SerializeField] private float      lifeTime;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * (bulletSpeed * Time.deltaTime));
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

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}