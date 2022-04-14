using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip startMusic;
    public AudioClip stageMusic;

    public float maxVolume;
    public float fadeOutTime = 1f;
    private bool startSetup = false;
    private bool stageSetup = false;
    private bool canSend = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartMusicProcess();
        StageMusicProcess();
    }

    void StartMusicProcess()
    {
        if (startSetup && canSend)
        {
            Invoke("StartMusic", fadeOutTime);
            canSend = false;
        }
        else if(startSetup && !canSend)
        {
            audioSource.volume -= maxVolume / fadeOutTime / 60;//フェードアウト
        }
    }
    void StartMusic()
    {
        startSetup = false;
        audioSource.clip = stageMusic;
        audioSource.volume = maxVolume;
        audioSource.Play();
    }

    void StageMusicProcess()
    {
        if (stageSetup && canSend)
        {
            Invoke("StageMusic", fadeOutTime);
            canSend = false;
        }
        else if (stageSetup && !canSend)
        {
            audioSource.volume -= maxVolume / fadeOutTime / 60;//フェードアウト
        }
    }
    void StageMusic()
    {
        stageSetup = false;
        audioSource.clip = stageMusic;
        audioSource.volume = maxVolume;
        audioSource.Play();
    }

    public void StartMusicChange()
    {
        Destroy(this.gameObject);
    }
    public void StageMusicChange()
    {
        stageSetup = true;
        canSend = true;
    }
}
