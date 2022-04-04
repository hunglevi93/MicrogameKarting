using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;


public class SettingUI : MonoBehaviour
{
    public Button HideSettingUIBtn;
    public Animator SettingUIAnimation;
    public Animator MainUIAnimation;
    public Slider SoundSetting;
    public Slider MusicSetting;
    void Awake()
    {
        HideSettingUIBtn.onClick.AddListener(OnHideSettingUI);
        SoundSetting.value = AudioControl.Instance.audioFx.volume;
        MusicSetting.value = MusicControl.Instance.audioFx.volume;
    }
    void Update()
    {
        AudioControl.Instance.audioFx.volume = SoundSetting.value;
        MusicControl.Instance.audioFx.volume = MusicSetting.value;
    }
    private void OnHideSettingUI()
    {
        SettingUIAnimation.Play("out");
        MainUIAnimation.Play("in");
        AudioControl.Instance.OnUiSound();
    }
    private void DestroySettingUI()
    {
        gameObject.SetActive(false);
        EventManager.EmitEventData(EventName.PRESENTER_TRIGGER_2, true);
    }
}
