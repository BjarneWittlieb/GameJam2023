using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private static readonly float OFFSET = 48.5f;

    private List<HealthSymbol> healthSymbols = new();
    private HealthSymbol healthSymbolTemplate;

    // Start is called before the first frame update
    private void Awake()
    {
        healthSymbolTemplate = GetComponentInChildren<HealthSymbol>();

        Health.OnHealthChange += UpdateHealthUI;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnDisable()
    {
        Health.OnHealthChange -= UpdateHealthUI;
    }

    private void UpdateHealthUI(int health, int maxHealth)
    {
        Debug.Log(health + " " + maxHealth);

        ModifyMaxHealth(maxHealth);

        ModifyHealth(health);
    }

    private void ModifyMaxHealth(int maxHealth)
    {
        if (healthSymbols.Count == maxHealth / 2) return;

        foreach (var healthSymbol in healthSymbols.Skip(1)) Destroy(healthSymbol.gameObject);
        healthSymbols.Clear();
        healthSymbols = new List<HealthSymbol> { healthSymbolTemplate };

        for (var i = 1; i < maxHealth / 2; i++)
        {
            var newHealthSymbol = Instantiate(healthSymbolTemplate, transform);
            newHealthSymbol.GetComponent<RectTransform>().position += new Vector3(OFFSET * i, 0, 0);
            //newHealthSymbol.transform.position += new Vector3(OFFSET * i, 0, 0);
            newHealthSymbol.SetHealth(2);
            healthSymbols.Add(newHealthSymbol);
        }
    }

    private void ModifyHealth(int health)
    {
        var currentHealthIndex = health / 2;
        Debug.Log("current  " + currentHealthIndex);

        for (var i = 0; i < healthSymbols.Count; i++)
        {
            var healthSymbol = healthSymbols[i];
            if (i < currentHealthIndex)
                healthSymbol.SetHealth(2);
            else if (i == currentHealthIndex)
                healthSymbol.SetHealth(health % 2);
            else
                healthSymbol.SetHealth(0);
        }
    }
}