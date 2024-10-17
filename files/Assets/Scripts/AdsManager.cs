using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_ANDROID
    string gameId = "4268295";
#else
    string gameId = "4268294";
#endif

    public GameObject Menu;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
        else
        {
            Debug.Log("Interstitial Ads is not ready!");
        }
    }

    public void PlayRewardedAd()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Rewarded Ads is not ready!");
        }
    }

    public void ShowBanner()
    {
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
        }
        else
        {
            StartCoroutine(RepeatShowBanner());
        }
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads are ready!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Video Started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Debug.Log("Player rewarded");
            Player.GetComponent<Health>().addHeart();
            //Player.GetComponent<Health>().addHeart();
            Menu.GetComponent<PauseMenu>().Restart();
        }
    }
}
