using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
    public float speed;
    public AudioClip sound;

	void Start()
    {
        Destroy(gameObject, 10);
	}
	
    void Update()
    {
        float translationSpeed = Time.deltaTime * speed;
        transform.Translate(0, translationSpeed, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameStateManager.PlayerShield += Random.Range(1, 10);
            GameObject tempObj = new GameObject();
            AudioSource tempAudioSource = tempObj.AddComponent<AudioSource>();
            tempAudioSource.clip = sound;
            tempAudioSource.Play();
            Destroy(tempObj, 2);
            Destroy(gameObject);
        }
    }
}
