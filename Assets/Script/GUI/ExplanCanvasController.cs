using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanCanvasController : MonoBehaviour
{
    Animator explanCanvasAnimator;
    SEController sEController;

    // Start is called before the first frame update
    void Start()
    {
        explanCanvasAnimator = GetComponent<Animator>();
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
        CommonControll.guiState = GUIState.Explan;
        sEController.PushButton();
        explanCanvasAnimator.SetTrigger("Open");
    }

    public void CloseCanvas()
    {
        if (CommonControll.guiState != GUIState.Explan)
        {
            return;
        }
        CommonControll.guiState = GUIState.Close;
        sEController.Cancel();
        explanCanvasAnimator.SetTrigger("Close");
    }
}
