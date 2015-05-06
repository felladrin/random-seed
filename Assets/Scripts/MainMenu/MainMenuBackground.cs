using UnityEngine;
using System.Collections;

public class MainMenuBackground : MonoBehaviour {
    public float speed;
    private float offset;
	
	void Update () {
        offset += Time.deltaTime * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, offset);
	}
}
