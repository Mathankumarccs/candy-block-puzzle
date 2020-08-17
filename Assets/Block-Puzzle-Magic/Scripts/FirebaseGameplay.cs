using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseGameplay : MonoBehaviour
{

	public int Endtime;
	public float playTime;
	// Use this for initialization
	void Start () {
		Endtime = System.DateTime.Now.Minute;
		playTime = GameController.starttime;

		Debug.Log("Gameplay: " + playTime);
		//Debug.Log("EntTime : " + Endtime);

        //Firebase.Analytics.FirebaseAnalytics.LogEvent(
        //Firebase.Analytics.FirebaseAnalytics.EventPostScore,
        //Firebase.Analytics.FirebaseAnalytics.ParameterScore, playTime);

        Firebase.Analytics.FirebaseAnalytics.LogEvent("Level_Played", "PlayTime", playTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
