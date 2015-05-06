using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public Transform enemy;
    public Transform powerupWeapon;

    void Start ()
    {
        InvokeRepeating("spawnEnemies", 1, Random.Range(0.5F, 2F));
        InvokeRepeating("spawnEnemies", 1, Random.Range(0.5F, 2F));
        InvokeRepeating("spawnPowerUpWeapon", 5, Random.Range(2,10));
    }
	
    void spawnEnemies ()
    {
        float startPositionXSum = 25;
        float startPositionYSum = 15;

        if (Random.value > 0.5F)
        {
            startPositionYSum *= -1; 
        }

        if (Random.value > 0.5F)
        {
            startPositionXSum *= -1; 
        }

        Vector3 startPosition = new Vector3(transform.position.x + startPositionXSum, transform.position.y + startPositionYSum, transform.position.z);
        Instantiate(enemy, startPosition, transform.rotation);
	}

    void spawnPowerUpWeapon ()
    {
        float startPositionXSum = Random.Range(1,15);
        float startPositionYSum = Random.Range(1,5);

        if (Random.value > 0.5F)
        {
            startPositionYSum *= -1; 
        }

        if (Random.value > 0.5F)
        {
            startPositionXSum *= -1; 
        }

        Vector3 startPosition = new Vector3(transform.position.x + startPositionXSum, transform.position.y + startPositionYSum, transform.position.z);
        Instantiate(powerupWeapon, startPosition, transform.rotation);
    }
}
