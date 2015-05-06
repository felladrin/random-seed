using UnityEngine;
using System.Collections;

public class PowerUpWeapon : MonoBehaviour {
    public float speed;
    public Transform weapon;

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
            int power = Random.Range(10, 31);
            for(float i = -180f; i < 180f; i += power)
            {
                Quaternion rotation = Quaternion.AngleAxis(i, transform.forward);
                Instantiate(weapon, transform.position, rotation);
            }
            Destroy(gameObject);
        }
    }
}
