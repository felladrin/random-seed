using UnityEngine;
using System.Collections;

public class WeaponBasic : MonoBehaviour {
    public Transform explosion;
    public Transform powerup;
    public float speed;

    public AudioClip shotSound;
    public AudioClip explosionSound;

    void Start()
    {
        Destroy(gameObject, 10);
        GetComponent<AudioSource>().PlayOneShot(shotSound);
    }
	
	void Update () {
        float translationSpeed = Time.deltaTime * speed;
        transform.Translate(0, translationSpeed, 0);
	}

    void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Player") )
            return;
        
        if ( collision.gameObject.CompareTag("Enemy") )
        {
            GameStateManager.EnemiesDestroyed++;

            if (Random.Range(1, 4) == 1)
            {
                Instantiate(powerup, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            }

            Transform t = (Transform)Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            AudioSource explosionAudioSource = t.gameObject.AddComponent<AudioSource>();
            explosionAudioSource.clip = explosionSound;
            explosionAudioSource.Play();
            Destroy(t.gameObject, 0.5F);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
