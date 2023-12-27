using GoogleMobileAds.Api;
using UnityEngine;

public class GoogleMobileAdsDemoScript : MonoBehaviour
{
    private InterstitialAd _interstitialAd;
    private string _adUnitId;
    public bool showAdOnButtonPress = false;
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>{ });
        #if UNITY_ANDROID
        _adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        _adUnitId = "unused";
#endif
    }
    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");
        var adRequest = new AdRequest();
    InterstitialAd.Load(_adUnitId, adRequest,
          (InterstitialAd ad, LoadAdError error) =>
          {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
              {
                  Debug.LogError("interstitial ad failed to load an ad " +
                                 "with error : " + error);
                  return;
              }

              Debug.Log("Interstitial ad loaded with response : "
                        + ad.GetResponseInfo());

              _interstitialAd = ad;
          });
    }
public void ShowInterstitialAd()
{
    if ( _interstitialAd != null && _interstitialAd.CanShowAd())
    {
        Debug.Log("Showing interstitial ad.");
        _interstitialAd.Show();
            
    }
    else
    {
        Debug.LogError("Interstitial ad is not ready yet.");
         
    }
}
}
