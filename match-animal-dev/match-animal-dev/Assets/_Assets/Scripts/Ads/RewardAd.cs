using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public enum RewardType
{
    Coin,
    Item
}

public class RewardAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;
    public RewardType rewardType;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms
    private bool _rewardGiven = false;// write by I am
    private static ItemSpin itemSpin => ItemSpin.Instance;
    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        // Disable the button until the ad is ready to show:
        _showAdButton.interactable = false;
    }
    void Update()
    {
        ReLoadAd();
    }

    private void ReLoadAd()
    {
        //if ads not load beffore 5 second reload ads
        if (_showAdButton.interactable == false) StartCoroutine(ReloadAds());
    }

    //couroutine reload ads
    IEnumerator ReloadAds()
    {
        yield return new WaitForSeconds(5f);
        LoadAd();
    }
    // Call this public method when you want to get an ad ready to show.
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
        _rewardGiven = false;
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {

            // Remove all listeners from the onClick event to prevent multiple calls
            _showAdButton.onClick.RemoveAllListeners();
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
            _showAdButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        // Disable the button:
        _showAdButton.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED) && !_rewardGiven)
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
            Rewards();
            _rewardGiven = true;
            //Load more ads
            LoadAd();
        }
    }

    private void Rewards()
    {
        TypeRewards(rewardType);
        itemSpin.SetDataValues();
    }

    private void TypeRewards(RewardType rewardType)
    {
        if (rewardType == RewardType.Coin) RewardCoin();
        else if (rewardType == RewardType.Item) RewardItems();
    }

    private static void RewardCoin()
    {
        itemSpin.gold += 300;
    }
    private static void RewardItems()
    {
        RewardHint();
        RewardUndo();
        RewardShuffle();
    }

    private static void RewardShuffle()
    {
        itemSpin.shuffle += 1;
    }

    private static void RewardUndo()
    {
        itemSpin.undo += 1;
    }

    private static void RewardHint()
    {
        itemSpin.hint += 1;
    }

    void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
    }
}