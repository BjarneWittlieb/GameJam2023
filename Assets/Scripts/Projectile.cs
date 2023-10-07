using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private AudioClip  hitSound;
    [SerializeField] private AudioClip  shotSound;
    [SerializeField] private float      bulletSpeed;
    [SerializeField] private float      lifeTime;

    private void FixedUpdate()
    {
        var isometricRight = new Vector2(1, 0.5f).normalized;
        transform.Translate(isometricRight * (bulletSpeed * Time.deltaTime));
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
        if(shotSound)
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        
        Destroy(gameObject, lifeTime);
    }
}