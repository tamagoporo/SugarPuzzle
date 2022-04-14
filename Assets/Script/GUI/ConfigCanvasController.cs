using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigCanvasController : MonoBehaviour
{
    Animator configCanvasAnimator;
    SEController sEController;

    // Start is called before the first frame update
    void Start()
    {
        configCanvasAnimator = GetComponent<Animator>();
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
        CommonControll.guiState = GUIState.Config;
        sEController.PushButton();
        configCanvasAnimator.SetTrigger("Open");
    }

    public void CloseCanvas()
    {
        if (CommonControll.guiState != GUIState.Config)
        {
            return;
        }
        CommonControll.guiState = GUIState.Close;
        sEController.Cancel();
        configCanvasAnimator.SetTrigger("Close");
    }
}
