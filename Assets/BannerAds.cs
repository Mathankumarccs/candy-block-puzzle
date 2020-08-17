using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class BannerAds : Singleton<BannerAds>
{
    private BannerView adBanner;
    private string idApp, idBanner;
    // Start is called before the first frame update
    void Start()
    {
        idApp = "ca-app-pub-4073866383873410~3834555921";

        idBanner = "ca-app-pub-4073866383873410/9002836717";
        RequestBannerAd();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RequestBannerAd()
    {
        //AdSize adSize = new AdSize(320, 100);
        adBanner = new BannerView(idBanner, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest request = AdRequestBuild();
        adBanner.LoadAd(request);

    }

    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }


    public void DestroyBannerAd()
    {
        if (adBanner != null)
            adBanner.Destroy();
    }

    void OnDestroy()
    {
        DestroyBannerAd();
    }
}
