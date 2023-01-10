using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsListener : MonoBehaviour, IUnityAdsInitializationListener
{

    string androidGameID = "4847609";
    string iOSGameID;
    bool testMode = false;
    private string gameID;

    void Awake()
    {
        InitializeAds();
    }
    public void InitializeAds()
    {
        gameID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSGameID : androidGameID;
        Advertisement.Initialize(gameID, testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}