using UnityEngine;
using System;
using System.Collections;

public class Player : MonoBehaviour
{
    public float speed;
    public Transform background;
    public Transform weapon;

    private float speedBonus;
    private float backgroundOffsetX;
    private float backgroundOffsetY;

    void Start()
    {
        GameStateManager.EnemiesDestroyed = 0;
        GameStateManager.PlayerShield = 100;
        GameStateManager.PlayerMaxSpeed = 0;
        GameStateManager.SurvivedTime = TimeSpan.Zero;
        InvokeRepeating("UpdateSurvivedTime", 1, 1);
    }
    
    void Update()
    {
        followMouse();
        moveBackground();

        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                changeWeaponNext();
            else
                changeWeaponPrevious();
        }
    }

    void followMouse()
    {
        float translationSpeed = Time.deltaTime * speed;

        Vector3 playerPosition = transform.position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = playerPosition - mousePosition;

        speedBonus = (Math.Abs(direction.z) + Math.Abs(direction.x) + Math.Abs(direction.y)) / 300;

        translationSpeed += speedBonus;

        transform.rotation = Quaternion.LookRotation(transform.forward, -direction);
        
        if (Math.Abs(direction.x) > 1 || Math.Abs(direction.y) > 1)
        {
            transform.Translate(0, translationSpeed, 0);
            GameStateManager.PlayerSpeed = translationSpeed;
        }
        else
        {
            GameStateManager.PlayerSpeed = 0;
        }
    }

    void moveBackground()
    {
        float backgroundSpeed = Time.deltaTime * (speed / 75);

        if (transform.rotation.eulerAngles.z < 180)
        {
            backgroundOffsetX += backgroundSpeed;
        }
        else
        {
            backgroundOffsetX -= backgroundSpeed;
        }

        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270)
        {
            backgroundOffsetY += backgroundSpeed;
        }
        else
        {
            backgroundOffsetY -= backgroundSpeed;
        }
        
        background.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(backgroundOffsetX, backgroundOffsetY);
    }

    void shoot()
    {
        Instantiate(weapon, transform.position, transform.rotation);
    }

    void changeWeaponNext()
    {
        Debug.Log("Proxima arma");
    }

    void changeWeaponPrevious()
    {
        Debug.Log("Arma anterior");
    }

    void UpdateSurvivedTime()
    {
        GameStateManager.SurvivedTime += TimeSpan.FromSeconds(1);
    }
}
