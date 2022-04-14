using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEController : MonoBehaviour
{
    public AudioClip PushButtonAudio;
    public AudioClip EnterAudio;
    public AudioClip CancelAudio;
    public AudioClip HintAudio;
    public AudioClip TipsAudio;
    public AudioClip GameClearAudio;
    public AudioClip GetAudio;
    public AudioClip JumpAudio;
    public AudioClip OpenGateAudio;
    public AudioClip FallAudio;

    AudioSource audioSource;

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
        
    }

    public void PushButton()
    {
        audioSource.clip = PushButtonAudio;
        audioSource.Play();
    }
    public void Enter()
    {
        audioSource.clip = EnterAudio;
        audioSource.Play();
    }
    public void Cancel()
    {
        audioSource.clip = CancelAudio;
        audioSource.Play();
    }
    public void Hint()
    {
        audioSource.clip = HintAudio;
        audioSource.Play();
    }
    public void Tips()
    {
        audioSource.clip = TipsAudio;
        audioSource.Play();
    }
    public void GameClear()
    {
        audioSource.clip = GameClearAudio;
        audioSource.Play();
    }
    public void Get()
    {
        audioSource.clip = GetAudio;
        audioSource.Play();
    }
    public void Jump()
    {
        audioSource.clip = JumpAudio;
        audioSource.Play();
    }
    public void OpenGate()
    {
        audioSource.clip = OpenGateAudio;
        audioSource.Play();
    }
    public void Fall()
    {
        audioSource.clip = FallAudio;
        audioSource.Play();
    }

    public void StartMusicChange()
    {
        Destroy(this.gameObject);
    }
}
