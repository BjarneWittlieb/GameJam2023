using JetBrains.Annotations;
using PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public HealthSymbol healthNode;

    private List<HealthSymbol> healthSymbols;
    private static readonly float OFFSET = 2;

    // Start is called before the first frame update
    void Start()
    {
        healthSymbols = new List<HealthSymbol>() { healthNode };
        PlayerHealth.OnHealthChange += UpdateHealthUI;
    }

    private void UpdateHealthUI(int health, int maxHealth)
    {
        ModifyMaxHealth(maxHealth);

        ModifyHealth(health);
    }

    private void ModifyMaxHealth(int maxHealth)
    {
        if (healthSymbols.Count != maxHealth / 2)
        {
            foreach (HealthSymbol healthSymbol in healthSymbols.Skip(1))
            {
                Destroy(healthSymbol);
            }
            healthSymbols.Clear();
            healthSymbols = new List<HealthSymbol>() { healthNode };
        }

        for (int i = 1; i < maxHealth / 2; i += 1)
        {
            var newHealthSymbol = Instantiate(healthNode, this.transform);
            newHealthSymbol.transform.position += new Vector3(OFFSET * i, 0, 0);
        }
    }

    private void ModifyHealth(int health)
    {
        var currentHealthIndex = health / 2;

        healthSymbols[currentHealthIndex].changeOpacity(.5f * (health % 2));

        for (int i = 0; i < healthSymbols.Count; i++)
        {
            var healthSymbol = healthSymbols[i];
            if (i < currentHealthIndex)
            {
                healthSymbol.changeOpacity(1);
            } else if (i == currentHealthIndex)
            {
                healthSymbols[currentHealthIndex].changeOpacity(.5f * (health % 2));
            } else
            {
                healthSymbol.changeOpacity(0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
