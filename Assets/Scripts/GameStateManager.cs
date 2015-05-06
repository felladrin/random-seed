using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager {
    private static string username = "Unknown";
    private static Dictionary<string, string> userProfile;
    private static List<object> userFriends;
    private static TimeSpan survivedTime;
    private static int playerShield;
    private static int enemiesDestroyed;
    private static float playerSpeed;
    private static float playerMaxSpeed;

    public static string Username
    {
        get
        {
            return username;
        }
        set
        {
            username = value;
        }
    }

    public static Dictionary<string, string> UserProfile
    {
        get
        {
            return userProfile;
        }
        set
        {
            userProfile = value;
            username = userProfile["name"];
        }
    }

    public static List<object> UserFriends
    {
        get
        {
            return userFriends;
        }
        set
        {
            userFriends = value;
        }
    }

    public static TimeSpan SurvivedTime
    {
        get
        {
            return survivedTime;
        }
        set
        {
            survivedTime = value;
        }
    }

    public static int PlayerShield
    {
        get
        {
            return playerShield;
        }
        set
        {
            playerShield = value;
            
            if (playerShield < 0)
                playerShield = 0;

            if (playerShield > 100)
                playerShield = 100;
        }
    }

    public static int EnemiesDestroyed
    {
        get
        {
            return enemiesDestroyed;
        }
        set
        {
            enemiesDestroyed = value;
        }
    }

    public static float PlayerSpeed
    {
        get
        {
            return playerSpeed;
        }
        set
        {
            playerSpeed = value;

            if (playerSpeed > playerMaxSpeed)
                playerMaxSpeed = playerSpeed;
        }
    }

    public static float PlayerMaxSpeed
    {
        get
        {
            return playerMaxSpeed;
        }
        set
        {
            playerMaxSpeed = value;
        }
    }
}
