using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeAds : MonoBehaviour
{


    public BannerView bannerView;
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif


        if (SceneManager.GetActiveScene().name == "Menu")
        {
            this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
            this.bannerView.OnAdLoaded += this.HandleOnAdLoadedBanner;
            this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoadBanner;
            AdRequest request = new AdRequest.Builder().Build();
            this.bannerView.LoadAd(request);
        }
    }

    public void HandleOnAdLoadedBanner(object sender, EventArgs args)
    {
        bannerView.Show();
    }

    public void HandleOnAdFailedToLoadBanner(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }
}
