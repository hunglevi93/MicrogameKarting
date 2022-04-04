using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TigerForge;

public class Finish : MonoBehaviour
{
    [SerializeField] Button NextBtn, PlayAgainBtn, HomeBtn;
    private int indexScene;
    public GameObject FinishCanvas;
    public bool isTrigger = false;
    public static Finish instance;

    void Start()
    {
        indexScene = SceneManager.GetActiveScene().buildIndex;
        SetButton();
        OnClickBtn();
        instance = this;
    }
    private void OnNext()
    {
        SceneManager.LoadScene(indexScene ++);
        AudioControl.Instance.OnPlayButtonSound();
    }
    private void OnPlayAgain()
    {
        SceneManager.LoadScene(indexScene);
        AudioControl.Instance.OnPlayButtonSound();
    }
    private void OnBackHome()
    {
        SceneManager.LoadScene(0);
        AudioControl.Instance.OnPlayButtonSound();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FinishCanvas.gameObject.SetActive(true);
            EventManager.EmitEvent(EventName.PLAYER_TRIGGER);
            UnlockScene();
            isTrigger = true;
        }
    }
    private void SetButton()
    {
        if(indexScene == 3)
        {
            NextBtn.gameObject.SetActive(false);
        }
    }
    private void UnlockScene()
    {
        if(indexScene < 3)
        {
            indexScene ++;
            PlayerPrefs.SetInt("LevelAt", indexScene);
        }
    }
    private void OnClickBtn()
    {
        NextBtn.onClick.AddListener(OnNext);
        PlayAgainBtn.onClick.AddListener(OnPlayAgain);
        HomeBtn.onClick.AddListener(OnBackHome); 
    }
}
