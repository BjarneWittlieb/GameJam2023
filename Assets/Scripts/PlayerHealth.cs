using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;

    public delegate void HitEvent(int damage);
    public static event HitEvent OnHit;

    public delegate void DeathEvent();
    public static event DeathEvent OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        OnHit += ProcessHit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ProcessHit(int damage)
    {
        maxHealth -= damage;

        if (maxHealth == 0)
        {
            return;
        }

        if (OnDeath != null)
        {
            OnDeath();
        }
    }
}
