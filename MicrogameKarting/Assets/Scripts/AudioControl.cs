using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public static AudioControl Instance;

    public AudioSource audioFx;

    public AudioClip buttonClip;
    public AudioClip addCoinClip;
    public AudioClip UiClip;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //vi phai chuyen qua cac scene nen dam bao khong xoa di khi chuyen scene
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnValidate()
    {
        if(audioFx == null)
        {
            audioFx = gameObject.AddComponent<AudioSource>();
            // tat tieng khi play, dieu chinh bang edit
            audioFx.playOnAwake = false;
        }
    }

    // tao am thanh cho button shop
    public void OnPlayButtonSound()
    {
        audioFx.PlayOneShot(buttonClip);
    }
    public void OnAddCoinSound()
    {
        audioFx.PlayOneShot(addCoinClip);
    }
    public void OnUiSound()
    {
        audioFx.PlayOneShot(UiClip);
    }
}
