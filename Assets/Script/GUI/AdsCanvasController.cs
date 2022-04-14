using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsCanvasController : MonoBehaviour
{
    string gameId = "3461105";
    string myPlacementId = "rewardedVideo";

    Animator adsCanvasAnimator;
    SEController sEController;

    private void Awake()
    {
        Advertisement.Initialize(gameId);
    }

    // Start is called before the first frame update
    void Start()
    {
        adsCanvasAnimator = GetComponent<Animator>();
        sEController = GameObject.Find("SEController").GetComponent<SEController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenCanvas()
    {
        if (CommonControll.guiState != GUIState.Close)
        {
            return;
        }
        CommonControll.guiState = GUIState.Ads;
        sEController.PushButton();
        adsCanvasAnimator.SetTrigger("Open");
    }

    public void CloseCanvas()
    {
        if (CommonControll.guiState != GUIState.Ads)
        {
            return;
        }
        CommonControll.guiState = GUIState.Close;
        sEController.Cancel();
        adsCanvasAnimator.SetTrigger("Close");
    }

    public void AdsWatch()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
