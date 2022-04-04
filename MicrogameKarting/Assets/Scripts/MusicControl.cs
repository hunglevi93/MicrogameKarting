using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public static MusicControl Instance;

    public AudioSource audioFx;
    public AudioClip MusicClip;

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
            audioFx.loop = true;
        }
    }
    public void OnPlayMusic()
    {
        audioFx.PlayOneShot(MusicClip);
    }
}
