using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public delegate void DeathEvent();

    public int maxHealth = 4;
    private DateTime _lastHit;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public static event DeathEvent OnDeath;

    public void ProcessHit(int damage)
    {
        var timeSinceLastHit = DateTime.Now - _lastHit;
        const int invulnerabilityCooldown = 200;
        if (timeSinceLastHit.TotalMilliseconds < invulnerabilityCooldown) return;
        maxHealth -= damage;
        _lastHit = DateTime.Now;
        Debug.Log($"Player took {damage} damage");

        if (maxHealth == 0) return;

        if (OnDeath != null) OnDeath();
    }
}