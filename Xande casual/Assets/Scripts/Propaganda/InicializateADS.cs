using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Advertisement;

public class InicializateADS : MonoBehaviour
{

    [SerializeField] private string andoidGameId;
    [SerializeField] private string iosGameId;
    [SerializeField] private bool isTesting;

    private string gameId;



    private void Awake()
    {
#if UNITY_IOS
               gameId = iosGameId;
#elif UNITY_ANDROID
               gameId = androidGameId;
#elif UNITY_EDITOR
               gameId= andoidGameId;
#endif

        //if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            //Advertisement.Initialize(gameId, isTesting, this);
        }

    }

    public void OnInitializationComplete()
    {
        //Debug.log("Ads Initialized...");
    }
}
