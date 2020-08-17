using UnityEngine;
using System.Collections;

public class GameController : Singleton<GameController> 
{
	public static GameMode gameMode = GameMode.CLASSIC;
	public Canvas UICanvas;
	public GameObject adsUnit;
	public static float starttime;
	public static string imei;
	public static int AlertCount=0;
	public static string RwdScore;
	public static int RewardScore;

	// Checks if interner is available or not.
	public bool isInternetAvailable()
	{
		if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork) {
			return true;
		}
		return false;

	}

    private void Start()
    {
		DontDestroyOnLoad(adsUnit);
		starttime = 0.0f;
		imei = SystemInfo.deviceUniqueIdentifier;
		Debug.Log("imei: " +imei);

	}

    private void Update()
    {
		starttime += Time.deltaTime;
		//Debug.Log("starttime : " + starttime);
	}

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
	{
		Invoke ("QuitGameWithDelay", 0.5F);
	}

	/// <summary>
	/// Quits the game with delay.
	/// </summary>
	void QuitGameWithDelay ()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}
}
