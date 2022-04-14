using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuStageController : MonoBehaviour
{
    public GameObject TargetReleaseStage;
    public string sceneName;
    public bool isReady = false;
    bool isFade = false;
    GameObject ClearImage;
    GameObject CookieImage;
    Image BackGroundImage;
    BGMController bGMController;
    SEController sEController;

    public static bool stage1 = false;
    public static bool stage2 = false;
    public static bool stage3 = false;
    public static bool stage4 = false;
    public static bool stage5 = false;
    public static bool stage6 = false;
    public static bool cookie1 = false;
    public static bool cookie2 = false;
    public static bool cookie3 = false;
    public static bool cookie4 = false;
    public static bool cookie5 = false;
    public static bool cookie6 = false;

    // Start is called before the first frame update
    void Start()
    {
        ClearImage = transform.GetChild(1).GetChild(0).gameObject;
        CookieImage = transform.GetChild(2).GetChild(0).gameObject;
        BackGroundImage = GameObject.Find("BackGroundImage").GetComponent<Image>();
        bGMController = GameObject.Find("BGMController").GetComponent<BGMController>();
        sEController = GameObject.Find("SEController").GetComponent<SEController>();

        if(this.gameObject.name == "Stage1")
        {
            ClearImage.SetActive(stage1);
            CookieImage.SetActive(cookie1);
        }
        if (this.gameObject.name == "Stage2")
        {
            ClearImage.SetActive(stage2);
            CookieImage.SetActive(cookie2);
        }
        if (this.gameObject.name == "Stage3")
        {
            ClearImage.SetActive(stage3);
            CookieImage.SetActive(cookie3);
        }
        if (this.gameObject.name == "Stage4")
        {
            ClearImage.SetActive(stage4);
            CookieImage.SetActive(cookie4);
        }
        if (this.gameObject.name == "Stage5")
        {
            ClearImage.SetActive(stage5);
            CookieImage.SetActive(cookie5);
        }
        if (this.gameObject.name == "Stage6")
        {
            ClearImage.SetActive(stage6);
            CookieImage.SetActive(cookie6);
        }

        BackGroundImage.enabled = false;

        if (!isReady)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 100/255f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ReleaseStage();
        ImageFade();
    }

    void ReleaseStage()
    {
        if (isReady && GetComponent<Image>().color.a < 1)//準備できているなら透明化を無効にする
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1f);
        }
        if(ClearImage.activeSelf && !TargetReleaseStage.GetComponent<MenuStageController>().isReady)//クリアしたなら次のステージを解放する
        {
            TargetReleaseStage.GetComponent<MenuStageController>().isReady = true;
        }
    }

    public void ChangeStateSceneProcess()//ボタンが押された時の処理
    {
        if (isReady)//ボタンが押せる白色の状態
        {
            sEController.Enter();
            BackGroundImage.enabled = true;
            isFade = true;
            bGMController.StageMusicChange();
            Invoke("ChangeStateScene", 1f);
        }
        else//ボタンを押せない灰色の状態
        {
            sEController.Cancel();
        }
    }
    void ChangeStateScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    void ImageFade()
    {
        if (isFade)
        { 
            BackGroundImage.color = new Color(BackGroundImage.color.r, BackGroundImage.color.b, BackGroundImage.color.g, BackGroundImage.color.a + (float)1 / 120);
        }
    }

    void Visible_ClearCookieImage()
    {

    }
}
