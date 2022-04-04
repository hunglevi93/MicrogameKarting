using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TigerForge;

public class TimeCountDown : MonoBehaviour
{
    public float timeValue;
    public Text timeTxt;
    public Image Background;
    private int SceneIndex;
    public Button PlayAgainBtn;
    public Button HomeBtn;
    public GameObject Camera;
    private void Start()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        timeValue = 60.0f;
        PlayAgainBtn.onClick.AddListener(OnPlayAgain);
        HomeBtn.onClick.AddListener(OnBackHome);
    }

    private void Update()
    {
        if(timeValue > 0)
        {
            timeValue -=  Time.deltaTime;
        }
        else if(timeValue <= 0 && Finish.instance.isTrigger == false)
        {
            timeValue = 0;
            SetButton();
        }
        else
        {
            return;
        }
        OnDisplayTime(timeValue);
        SetKey();
    }

    private void OnDisplayTime(float timeValue)
    {   
        int Minute = Mathf.FloorToInt(timeValue / 60);
        int Second = Mathf.FloorToInt(timeValue % 60);
        timeTxt.text = string.Format("{0:00}:{1:00}", Minute, Second); 
    }
    private void OnPlayAgain()
    {
        SceneManager.LoadScene(SceneIndex);
        AudioControl.Instance.OnPlayButtonSound();
    }
    private void OnBackHome()
    {
        SceneManager.LoadScene(0);
        AudioControl.Instance.OnPlayButtonSound();
    }
    private void SetButton()
    {
        timeTxt.gameObject.SetActive(false);
        Background.gameObject.SetActive(true);
        Camera.SetActive(true);
        EventManager.EmitEventData(EventName.PLAYER_TRIGGER, false);
    }
    private void SetKey()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            SetButton();
        }
    }
}
