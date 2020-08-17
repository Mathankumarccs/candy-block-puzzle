using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

//Banner ad
public class AdmobInterstiatial : MonoBehaviour
{
	

	private InterstitialAd adInterstitial;

	

	private string idApp,idInterstitial;

	[SerializeField] Button BtnInterstitial, BtnReward;

	//[SerializeField] Text TxtPoints;


	void Start()
	{

		idApp = "ca-app-pub-4073866383873410~3834555921";

		

		idInterstitial = "ca-app-pub-4073866383873410/9489921873";
        

		MobileAds.Initialize(idApp);

		RequestInterstitialAd();


	}



	#region Banner Methods --------------------------------------------------


	public void RequestInterstitialAd()
	{
		adInterstitial = new InterstitialAd(idInterstitial);
		AdRequest request = AdRequestBuild();
		adInterstitial.LoadAd(request);

		//attach events
		adInterstitial.OnAdLoaded += this.HandleOnAdLoaded;
		adInterstitial.OnAdOpening += this.HandleOnAdOpening;
		adInterstitial.OnAdClosed += this.HandleOnAdClosed;
	}

	

	public void ShowInterstitialAd()
	{
		if (adInterstitial.IsLoaded())
			adInterstitial.Show();
		//Destroy(BtnInterstitial);	
		Destroy(BtnInterstitial);

		Debug.Log("Show adInterstitial");
	}

	public void DestroyInterstitialAd()
	{
		adInterstitial.Destroy();
	}

	//interstitial ad events
	public void HandleOnAdLoaded(object sender, EventArgs args)
	{
		//this method executes when interstitial ad is Loaded and ready to show
		BtnInterstitial.interactable = true; //button is ready to click (enabled)
	}

	public void HandleOnAdOpening(object sender, EventArgs args)
	{
		//this method executes when interstitial ad is shown
		BtnInterstitial.interactable = false; //disable the button
	}

	public void HandleOnAdClosed(object sender, EventArgs args)
	{
		//this method executes when interstitial ad is closed
		adInterstitial.OnAdLoaded -= this.HandleOnAdLoaded;
		adInterstitial.OnAdOpening -= this.HandleOnAdOpening;
		adInterstitial.OnAdClosed -= this.HandleOnAdClosed;

		RequestInterstitialAd(); //request new interstitial ad after close
	}

	
	#endregion


	//------------------------------------------------------------------------
	AdRequest AdRequestBuild()
	{
		return new AdRequest.Builder().Build();
	}

	void OnDestroy()
	{

		DestroyInterstitialAd();

		//dettach events
		adInterstitial.OnAdLoaded -= this.HandleOnAdLoaded;
		adInterstitial.OnAdOpening -= this.HandleOnAdOpening;
		adInterstitial.OnAdClosed -= this.HandleOnAdClosed;

	}

}