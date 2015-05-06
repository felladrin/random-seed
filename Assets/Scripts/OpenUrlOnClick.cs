using UnityEngine;
using System.Collections;

public class OpenUrlOnClick : MonoBehaviour
{
    public string URL;

    void OnMouseUp()
    {
        Application.ExternalEval("window.open('" + URL + "','_blank')");
        // Application.OpenURL(URL); // Se estiver usando o Facebook Canvas, ele abre por cima do jogo.
    }
}
