using UnityEngine;
using System.Collections;

public class SmoothTextBlinking : MonoBehaviour 
{
    public float speed = 2;

    public bool StopOnHover = true;

    private Color originalColor;

    private bool mouseOver = false;

    void Start()
    {
        originalColor = GetComponent<GUIText>().color;
    }

    void Update()
    {
        if (!StopOnHover || !mouseOver)
        {
            Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.PingPong(Time.time * speed, 1));
            GetComponent<GUIText>().color = newColor;
        }
    }

    void OnMouseEnter()
    {
        mouseOver = true;
    }

    void OnMouseExit()
    {
        mouseOver = false;
    }
}
