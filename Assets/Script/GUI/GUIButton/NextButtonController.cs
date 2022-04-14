using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NextButtonController : MonoBehaviour
{
    bool isFade = false;

    Image BackGroundImage;
    BGMController bGMController;
    SEController sEController;

    // Start is called before the first frame update
    void Start()
    {
        BackGroundImage = GameObject.Find("BackGroundImage").GetComponent<Image>();
        bGMController = GameObject.Find("BGMController").GetComponent<BGMController>();
        sEController = GameObject.Find("SEController").GetComponent<SEController>();
    }

    // Update is called once per frame
    void Update()
    {
        ImageFade();
    }

    public void NextStageChangeProcess()
    {
        sEController.Enter();
        BackGroundImage.enabled = true;
        isFade = true;
        bGMController.StageMusicChange();
        Invoke("NextStageChange", 1f);
    }
    void NextStageChange()
    {
        if(SceneManager.GetActiveScene().name == "Stage1")
        {
            SceneManager.LoadScene("Stage2");
        }
        else if(SceneManager.GetActiveScene().name == "Stage2")
        {
            SceneManager.LoadScene("Stage3");
        }
        else if(SceneManager.GetActiveScene().name == "Stage3")
        {
            SceneManager.LoadScene("Stage4");
        }
        else if(SceneManager.GetActiveScene().name == "Stage4")
        {
            SceneManager.LoadScene("Stage5");
        }
        else if(SceneManager.GetActiveScene().name == "Stage5")
        {
            SceneManager.LoadScene("Stage5");
        }
        else if(SceneManager.GetActiveScene().name == "Stage6")
        {
            SceneManager.LoadScene("Stage6");
        }
    }

    void ImageFade()
    {
        if (isFade)
        {
            BackGroundImage.color = new Color(BackGroundImage.color.r, BackGroundImage.color.b, BackGroundImage.color.g, BackGroundImage.color.a + (float)1 / 120);
        }
    }
}
