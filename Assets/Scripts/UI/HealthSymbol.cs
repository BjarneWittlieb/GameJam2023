using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSymbol : MonoBehaviour
{
    private Image[] imageElements;
    public void Start()
    {
        imageElements = this.transform.GetComponentsInChildren<Image>();
    }

    public void changeOpacity(float opacity)
    {
        foreach(var item in imageElements)
        {
            item.color = new Color(item.color.r, item.color.g, item.color.b, opacity);
        }
    }
}
