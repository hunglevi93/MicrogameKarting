using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;
using UnityEngine.SceneManagement;
public class LevelUI : MonoBehaviour
{
    public Button HideShopUIBtn;
    public Animator LevelUIAnimation;
    public Animator MainUIAnimation;
    public Button[] LevelBtn;
    void Start()
    {
        int LevelAt = PlayerPrefs.GetInt("LevelAt", 1);
        for (int i = 0; i < LevelBtn.Length; i++)
        {
            if(i + 1 > LevelAt)
            {
                LevelBtn[i].interactable = false;
            }
        }
    }
    void Awake()
    {
        HideShopUIBtn.onClick.AddListener(OnHideLevelUI);
        LevelBtn[0].onClick.AddListener(() => LoadLevel(1));
        LevelBtn[1].onClick.AddListener(() => LoadLevel(2));
        LevelBtn[2].onClick.AddListener(() => LoadLevel(3));
    } 
    private void OnHideLevelUI()
    {
        LevelUIAnimation.Play("out");
        MainUIAnimation.Play("in");
        AudioControl.Instance.OnUiSound();
    }
    private void DestroyLevelUI()
    {
        gameObject.SetActive(false);
        EventManager.EmitEventData(EventName.PRESENTER_TRIGGER_2, true);
    }
    private void LoadLevel(int i)
    {     
        SceneManager.LoadScene(i); 
        AudioControl.Instance.OnPlayButtonSound(); 
    }
}
