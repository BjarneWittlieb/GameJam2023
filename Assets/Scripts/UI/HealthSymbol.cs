using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSymbol : MonoBehaviour
{
    public UnityEngine.UI.Image[] imageElements;

    public void changeOpacity(float opacity)
    {
        foreach(var item in imageElements)
        {
            item.color = new Color(item.color.r, item.color.g, item.color.b, opacity);
        }
    }
}
