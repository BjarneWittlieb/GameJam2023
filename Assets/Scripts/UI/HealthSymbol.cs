using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSymbol : MonoBehaviour
{
    public Image[] healthImages;

    public void Start()
    {
        // healthSprites = GetComponentsInChildren<SpriteRenderer>();
    }

    public void SetHealth(int health)
    {
        if (health == 2) {
            changeOpacity(healthImages[0], 1);
            changeOpacity(healthImages[1], 0);
        } else if (health == 1)
        {
            changeOpacity(healthImages[0], 0);
            changeOpacity(healthImages[1], 1);
        } else
        {
            changeOpacity(healthImages[1], 0);
            changeOpacity(healthImages[0], 0);
        }
    }

    public void changeOpacity(Image sprite, float opacity)
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, opacity);
    }
}
