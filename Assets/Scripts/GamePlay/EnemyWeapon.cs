using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {
    public Transform explosion;
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
        if ( collision.gameObject.CompareTag("Enemy") )
            return;
        
        if ( collision.gameObject.CompareTag("Player") )
        {
            GameStateManager.PlayerShield -= Random.Range(1, 5);
            Destroy(gameObject);
            Transform t = (Transform)Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            AudioSource explosionAudioSource = t.gameObject.AddComponent<AudioSource>();
            explosionAudioSource.clip = explosionSound;
            explosionAudioSource.Play();
            Destroy(t.gameObject, 0.5F);
        }
    }
}
