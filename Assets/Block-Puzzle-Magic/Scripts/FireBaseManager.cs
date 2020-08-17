using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using Firebase;
using Firebase.Analytics;

public class FireBaseManager : MonoBehaviour
{

	DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

	public static FireBaseManager instance;

	void Awake ()
	{
		instance = this;
	}
	// Use this for initialization
	void Start ()
	{


		dependencyStatus = FirebaseApp.CheckDependencies ();
		if (dependencyStatus != DependencyStatus.Available) {
			FirebaseApp.FixDependenciesAsync ().ContinueWith (task => {
				dependencyStatus = FirebaseApp.CheckDependencies ();
				if (dependencyStatus == DependencyStatus.Available) {
					InitializeFirebase ();
				} else {
					Debug.LogError (
						"Could not resolve all Firebase dependencies: " + dependencyStatus);
				}
			});
		} else {
			InitializeFirebase ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Handle initialization of the necessary firebase modules:
	void InitializeFirebase ()
	{
		Debug.Log("Inside the InitializeFirebase ");
		//DebugLog("Enabling data collection.");
		FirebaseAnalytics.SetAnalyticsCollectionEnabled (true);

		//DebugLog("Set user properties.");
		// Set the user's sign up method.
		FirebaseAnalytics.SetUserProperty (
			FirebaseAnalytics.UserPropertySignUpMethod,
			"Google");
		// Set the user ID.
		FirebaseAnalytics.SetUserId ("uber_user_510");
	}

	public void LogScreen (string _log)
	{
		FirebaseAnalytics.LogEvent (_log);
	}
}
