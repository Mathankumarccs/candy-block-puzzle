using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

//Banner ad
public class RewardedVideo : MonoBehaviour 
{
	

	

	private RewardBasedVideoAd adReward;

	private string idApp,idReward;

	[SerializeField] Button  BtnReward;
	
	//[SerializeField] Text TxtPoints;


	void Start()
	{
        
		idApp = "ca-app-pub-4073866383873410~3834555921";

		idReward = "ca-app-pub-4073866383873410/6319945007";

		adReward = RewardBasedVideoAd.Instance;

		MobileAds.Initialize(idApp);

	}



	#region Banner Methods --------------------------------------------------


	public void RequestRewardAd()
	{
		AdRequest request = AdRequestBuild();
		adReward.LoadAd(request, idReward);

		adReward.OnAdLoaded += this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded += this.HandleOnAdRewarded;
		adReward.OnAdClosed += this.HandleOnRewardedAdClosed;
	}

	public void ShowRewardAd()
	{
		if (adReward.IsLoaded())
			adReward.Show();
		Debug.Log("showed Rwd");
        //if (InputManager.Instance.canInput())
        //{
        //    AudioManager.Instance.PlayButtonClickSound();
        //    StackManager.Instance.OnCloseButtonPressed();
        //    GamePlayUI.Instance.AdsUnit.SetActive(true);
        //    Debug.Log("showed Rwd-2");
        //}
    }
    public void OnCloseRewardButton()
	{
		if (InputManager.Instance.canInput())
		{
			StackManager.Instance.OnCloseButtonPressed();
			GamePlay.Instance.OnGameOver();
		}
	}
	//events
	

	//interstitial ad events
	

	public void HandleOnRewardedAdLoaded(object sender, EventArgs args)
	{//ad loaded
		ShowRewardAd();

	}

	public void HandleOnAdRewarded(object sender, EventArgs args)
	{//user finished watching ad
	 //int points = int.Parse(TxtPoints.text);
	 //points += 50; //add 50 points
	 //TxtPoints.text = points.ToString();
		if (InputManager.Instance.canInput())
		{
			AudioManager.Instance.PlayButtonClickSound();
			StackManager.Instance.RestartRwdGamePlay();
		}
	}

	public void HandleOnRewardedAdClosed(object sender, EventArgs args)
	{//ad closed (even if not finished watching)
		BtnReward.interactable = true;
		if (InputManager.Instance.canInput())
		{
			StackManager.Instance.OnCloseButtonPressed();
			GamePlay.Instance.OnGameOver();
		}

		adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded -= this.HandleOnAdRewarded;
		adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
	}

	
	#endregion


	//------------------------------------------------------------------------
	AdRequest AdRequestBuild()
	{
		return new AdRequest.Builder().Build();
	}

	void OnDestroy()
	{
		
		adReward.OnAdLoaded -= this.HandleOnRewardedAdLoaded;
		adReward.OnAdRewarded -= this.HandleOnAdRewarded;
		adReward.OnAdClosed -= this.HandleOnRewardedAdClosed;
	}

}