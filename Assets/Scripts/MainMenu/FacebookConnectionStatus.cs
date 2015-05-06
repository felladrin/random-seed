using UnityEngine;
using System.Collections;

public class FacebookConnectionStatus : MonoBehaviour {
	void Update () {
	    if(GameStateManager.Username != "Unknown")
        {
            GetComponent<GUIText>().text = "Connected as " + GameStateManager.Username;
            //guiText.material.color = Color.green;
        }
	}
}
