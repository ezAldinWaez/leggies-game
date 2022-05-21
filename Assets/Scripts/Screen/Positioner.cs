using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Positioner : MonoBehaviour
{
    public float xMin, xMax, yMin, yMax;
    void Start()
    {
        this.GetComponent<RectTransform>().anchorMin = new Vector2(xMin, yMin);
        this.GetComponent<RectTransform>().anchorMax = new Vector2(xMax, yMax);
        this.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        this.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }
}