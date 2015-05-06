using UnityEngine;
using System.Collections;

public class ChangeColorOnHover : MonoBehaviour
{
    public Color color;

    private Color originalColor;

    void Start()
    {
        if (color.a == 0)
            color.a = 1;

        originalColor = GetComponent<GUIText>().color;
    }

    void OnMouseEnter()
    {
        GetComponent<GUIText>().color = color;
    }

    void OnMouseExit()
    {
        GetComponent<GUIText>().color = originalColor;
    }
}
