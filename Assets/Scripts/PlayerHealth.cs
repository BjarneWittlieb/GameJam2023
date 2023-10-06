using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;

    public delegate void DeathEvent();
    public static event DeathEvent OnDeath;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessHit(int damage)
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
