using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAdsButton instance;
    [SerializeField] private Button _showAdButton;

    private string _androidAdUnitId = "Rewarded_Android";
    private string _iOSAdUnitId = "Rewarded_iOS";

    private string _adUnitId;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidAdUnitId;

        //Disable button until ad is ready to show
        if(_showAdButton != null)
            _showAdButton.interactable = false;
        Debug.Log($"{_adUnitId}  ADS ID ANDROID");
    }

    private void Start()
    {
        if (Advertisement.isInitialized)
            LoadAd();
        else
            AdsInitializer.OnAdInitialized += LoadAd; // subscribe to the event
    }


    public void LoadAd()
    {
        AdsInitializer.OnAdInitialized -= LoadAd;
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }


    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Button was Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {

            _showAdButton.onClick.AddListener(ShowAd);

            _showAdButton.interactable = true;
        }
    }


    public void ShowAd()
    {
        Debug.Log("ShowAd() called");
        _showAdButton.interactable = false;
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
            //GameLogic.S.IncrementPoint2AfterAds(1);

            // Load another ad:
            Advertisement.Load(_adUnitId, this);
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
        StartCoroutine(RetryLoadAd());
    }

    private IEnumerator RetryLoadAd()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Retrying to load ad");
        LoadAd();
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    private void OnDestroy()
    {
        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
    }
}