using JetBrains.Annotations;
using PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public HealthSymbol healthSymbolTemplate;

    private List<HealthSymbol> healthSymbols = new List<HealthSymbol>();
    private static readonly float OFFSET = 32;

    // Start is called before the first frame update
    void Awake()
    {
        if (healthSymbolTemplate == null)
        {
            throw new System.Exception("You fucked up the UI. Now fix it!");
        }

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
        if (healthSymbols.Count == maxHealth)
        {
            return;
        }

        foreach (HealthSymbol healthSymbol in healthSymbols.Skip(1))
        {
            Destroy(healthSymbol.gameObject);
        }
        healthSymbols.Clear();
        healthSymbols = new List<HealthSymbol>() { healthSymbolTemplate };

        for (int i = 1; i < maxHealth; i++)
        {
            var newHealthSymbol = Instantiate(healthSymbolTemplate, this.transform);
            newHealthSymbol.transform.position += new Vector3(OFFSET * i, 0, 0);
            healthSymbols.Add(newHealthSymbol);
        }
    }

    private void ModifyHealth(int health)
    {
        var currentHealthIndex = health - 1;

        for (int i = 0; i < healthSymbols.Count; i++)
        {
            var healthSymbol = healthSymbols[i];
            if (i <= currentHealthIndex)
            {
                healthSymbol.changeOpacity(1);
            } else
            {
                healthSymbol.changeOpacity(0.1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
