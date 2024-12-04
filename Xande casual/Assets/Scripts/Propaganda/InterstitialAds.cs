using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterstitialAds : MonoBehaviour //, IUnityAdsLoadListener
{

    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string IosAdUnitId;

    private string adUnitId;

    private void Awake()
    {
         #if UNITY_IOS
             ad UnitId = iosAdUnitI;
         #elif UNITY_ANDROID
               adUnitId = androidAdUnitId;
         #endif
    }

    //public void LoadInterstitalAd()
    //{
        //Advertisement.Load(adUnitId, this);
    //}
}
