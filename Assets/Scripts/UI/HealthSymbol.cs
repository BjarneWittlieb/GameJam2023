using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSymbol : MonoBehaviour
{
    public SpriteRenderer[] healthSprites;

    public void Start()
    {
        // healthSprites = GetComponentsInChildren<SpriteRenderer>();
    }

    public void SetHealth(int health)
    {
        if (health == 2) {
            changeOpacity(healthSprites[0], 1);
            changeOpacity(healthSprites[1], 0);
        } else if (health == 1)
        {
            changeOpacity(healthSprites[0], 0);
            changeOpacity(healthSprites[1], 1);
        } else
        {
            changeOpacity(healthSprites[1], 0);
            changeOpacity(healthSprites[0], 0);
        }
    }

    public void changeOpacity(SpriteRenderer sprite, float opacity)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, opacity);
    }
}
