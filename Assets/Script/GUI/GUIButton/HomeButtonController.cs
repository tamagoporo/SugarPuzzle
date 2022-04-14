using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButtonController : MonoBehaviour
{
    public string sceneName;
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

        BackGroundImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ImageFade();
    }

    public void StartSceneChangeProcess()
    {
        sEController.Enter();
        BackGroundImage.enabled = true;
        isFade = true;
        bGMController.StartMusicChange();
        Invoke("StartSceneChange", 1f);
    }
    void StartSceneChange()
    {
        sEController.StartMusicChange();
        SceneManager.LoadScene(sceneName);
    }

    void ImageFade()
    {
        if (isFade)
        {
            BackGroundImage.color = new Color(BackGroundImage.color.r, BackGroundImage.color.b, BackGroundImage.color.g, BackGroundImage.color.a + (float)1 / 120);
        }
    }
}
