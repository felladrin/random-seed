using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Transform weapon;
    public Transform explosion;
    public Transform powerup;
    public AudioClip explosionSound;
    public int distanceToKeepFromTarget;
    
    private Transform target;
    private float speedY;
    private float speedX;
    private Sprite[] ships;
    private int[] spritesAllowed = new int[] {0, 8, 10, 13, 15, 17, 20, 23, 27, 29, 33};

	void Start () {
		speedY = Random.Range(2, 4);
		speedX = Random.Range(-2F, 2F);
		ships = Resources.LoadAll<Sprite> ("ShipsSprites");
        target = GameObject.FindWithTag("Player").transform;
        int randomSprite = spritesAllowed[Random.Range(0, spritesAllowed.Length)];
        gameObject.GetComponent<SpriteRenderer>().sprite = ships[randomSprite];
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
        InvokeRepeating("shoot", 1, Random.Range(1, 3) + Random.value);
	}
	
	void Update () {
        Vector3 direction = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(transform.forward, direction);
        if ((Vector3.Distance (transform.position, target.position) > distanceToKeepFromTarget)) {
            float translationSpeedX = Time.deltaTime * speedX;
            float translationSpeedY = Time.deltaTime * speedY;
            transform.Translate(translationSpeedX, translationSpeedY, 0);
        }
	}

    void OnCollisionEnter(Collision collision)
    {        
        if ( collision.gameObject.CompareTag("Player") )
        {
            GameStateManager.PlayerShield -= Random.Range(1, 5);
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
            Destroy(gameObject);
        }
    }

    void shoot()
    {
        Instantiate(weapon, transform.position, transform.rotation);
    }
}
