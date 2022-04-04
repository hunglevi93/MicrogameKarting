using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class GameManager : MonoBehaviour
{
    public Button ShopBtn;
    public Button LevelsBtn;
    public Button SettingBtn;
    public GameObject ShopUI;
    public GameObject LevelUI;
    public GameObject SettingUI;
    public Animator MainUIAnimation;
    void Awake()
    {
        MusicControl.Instance.OnPlayMusic();
        ShopBtn.onClick.AddListener(OnOpenShop);
        LevelsBtn.onClick.AddListener(OnOpenLevels);
        SettingBtn.onClick.AddListener(OnOpenSetting);
    }
        
    private void OnOpenShop()
    {
        ShopUI.gameObject.SetActive(true);
        MainUIAnimation.Play("out");
        EventManager.EmitEventData(EventName.PRESENTER_TRIGGER_1, false);
        AudioControl.Instance.OnPlayButtonSound();
    }
    private void OnOpenLevels()
    {
        LevelUI.gameObject.SetActive(true);
        MainUIAnimation.Play("out");
        EventManager.EmitEventData(EventName.PRESENTER_TRIGGER_1, false);
        AudioControl.Instance.OnPlayButtonSound();
    }
    private void OnOpenSetting()
    {
        SettingUI.gameObject.SetActive(true);
        MainUIAnimation.Play("out");
        EventManager.EmitEventData(EventName.PRESENTER_TRIGGER_1, false);
        AudioControl.Instance.OnPlayButtonSound();
    }
}
