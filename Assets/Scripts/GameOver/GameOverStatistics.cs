using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameOverStatistics : MonoBehaviour
{
    public GUIText enemiesDestroyed;
    public GUIText maxSpeed;
    public GUIText timeSurvived;
    public GUIText rip;
    
    void Start()
    {
        int maxSpeedString = (int)(GameStateManager.PlayerMaxSpeed * 10000);

        enemiesDestroyed.text = "Enemies Destroyed: " + GameStateManager.EnemiesDestroyed;
        maxSpeed.text = "Max Speed: " + maxSpeedString;
        timeSurvived.text = "Survival Time: " + new DateTime(GameStateManager.SurvivedTime.Ticks).ToString("mm:ss");
        rip.text = "- R.I.P. " + GameStateManager.Username + " -";

		/*
		string facebook_id = FB.UserId;
        string name = GameStateManager.Username;
        string score = (GameStateManager.EnemiesDestroyed).ToString();
        string seconds_survived = ((int)GameStateManager.SurvivedTime.TotalSeconds).ToString();
        string last_play = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        string hash = Util.GetSHA1Hash(String.Join("-[!RS!]-", new string[] {facebook_id, name, score, seconds_survived, last_play}));

        WWWForm form = new WWWForm();
        form.AddField("facebook_id", facebook_id);
        form.AddField("name", name);
        form.AddField("score", score);
        form.AddField("seconds_survived", seconds_survived);
        form.AddField("last_play", last_play);
        form.AddField("hash", hash);
        WWW www = new WWW("http://felladrin.com/games/randomseed/player/save", form);
        StartCoroutine(WaitForRequest(www));
        */
    }
    
	/*
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
    */
}
