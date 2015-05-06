using UnityEngine;
using System.Collections;

public class LoadLevelOnClick : MonoBehaviour 
{
    public string LevelName;

    void OnMouseUp()
    {
        Application.LoadLevel(LevelName);
    }
}
