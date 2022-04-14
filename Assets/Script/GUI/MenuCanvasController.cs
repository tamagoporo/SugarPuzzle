using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvasController : MonoBehaviour
{
    Animator menuCanvasAnimator;
    SEController sEController;

    // Start is called before the first frame update
    void Start()
    {
        menuCanvasAnimator = GetComponent<Animator>();
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
        CommonControll.guiState = GUIState.Menu;
        sEController.PushButton();
        menuCanvasAnimator.SetTrigger("Open");
    }

    public void CloseCanvas()
    {
        if (CommonControll.guiState != GUIState.Menu)
        {
            return;
        }
        CommonControll.guiState = GUIState.Close;
        sEController.Cancel();
        menuCanvasAnimator.SetTrigger("Close");
    }
}
