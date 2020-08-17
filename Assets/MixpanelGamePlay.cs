using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mixpanel;

public class MixpanelGamePlay : MonoBehaviour
{
    public int Endtime;
    public float playTime;
    // Use this for initialization
    void Start()
    {
        Endtime = System.DateTime.Now.Minute;
        playTime = GameController.starttime;

        Debug.Log("Gameplay: " + playTime);
        //Debug.Log("EntTime : " + Endtime);

        //Firebase.Analytics.FirebaseAnalytics.LogEvent(
        //Firebase.Analytics.FirebaseAnalytics.EventPostScore,
        //Firebase.Analytics.FirebaseAnalytics.ParameterScore, playTime);

        Mixpanel.Track("User_PlayTime", playTime);

        Mixpanel.Identify(GameController.imei);
        Mixpanel.People.Set("User_PlayTime", playTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
