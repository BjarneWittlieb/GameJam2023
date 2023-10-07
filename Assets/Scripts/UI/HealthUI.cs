using JetBrains.Annotations;
using PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private HealthSymbol healthSymbolTemplate;

    private List<HealthSymbol> healthSymbols = new List<HealthSymbol>();
    private static readonly float OFFSET = .16f;

    // Start is called before the first frame update
    void Awake()
    {
        healthSymbolTemplate = GetComponentInChildren<HealthSymbol>();

        PlayerHealth.OnHealthChange += UpdateHealthUI;
    }

    private void UpdateHealthUI(int health, int maxHealth)
    {
        Debug.Log(health+ " " + maxHealth);

        ModifyMaxHealth(maxHealth);

        ModifyHealth(health);
    }

    private void ModifyMaxHealth(int maxHealth)
    {
        if (healthSymbols.Count == maxHealth / 2)
        {
            return;
        }

        foreach (HealthSymbol healthSymbol in healthSymbols.Skip(1))
        {
            Destroy(healthSymbol.gameObject);
        }
        healthSymbols.Clear();
        healthSymbols = new List<HealthSymbol>() { healthSymbolTemplate };

        for (int i = 1; i < maxHealth / 2; i++)
        {
            var newHealthSymbol = Instantiate(healthSymbolTemplate, this.transform);
            newHealthSymbol.transform.position += new Vector3(OFFSET * i, 0, 0);
            newHealthSymbol.SetHealth(2);
            healthSymbols.Add(newHealthSymbol);
        }
    }

    private void ModifyHealth(int health)
    {
        var currentHealthIndex = (health) / 2;
        Debug.Log("current  " + currentHealthIndex);

        for (int i = 0; i < healthSymbols.Count; i++)
        {
            var healthSymbol = healthSymbols[i];
            if (i < currentHealthIndex)
            {
                healthSymbol.SetHealth(2);
            } else if (i == currentHealthIndex)
            {
                healthSymbol.SetHealth(health % 2);
            } else
            {
                healthSymbol.SetHealth(0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
