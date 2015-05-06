using UnityEngine;
using System;
using System.Collections;

public class GamePlayGui : MonoBehaviour {
    public GUIText speed;
    public GUIText enemiesDestroyed;
    public GUIText timeSurvived;
    public GUIText shield;
    public GUIText pilotName;
	
	void FixedUpdate () {
        pilotName.text = "Pilot: " + GameStateManager.Username;
        speed.text = "Speed: " + (int)(GameStateManager.PlayerSpeed * 100) + "00";
        enemiesDestroyed.text = "Enemies Destroyed: " + GameStateManager.EnemiesDestroyed;
        timeSurvived.text = "Time Survived: " + new DateTime(GameStateManager.SurvivedTime.Ticks).ToString("mm:ss");
        shield.text = "Shield: " + GameStateManager.PlayerShield + "%";

        if (GameStateManager.PlayerShield <= 0)
        {
            Application.LoadLevel("GameOver");
        }
	}
}
