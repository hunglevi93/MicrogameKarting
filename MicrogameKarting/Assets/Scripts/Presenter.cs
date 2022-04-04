using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using UnityEngine.UI;

public class Presenter : MonoBehaviour
{
    private GameObject playerDisplayPrefab;
    private GameObject playerDisplay;
    private int playerIndex;
    public Button prevCarBtn;
    public Button nextCarBtn;
    private void Awake()
    {
        playerIndex = DataPlayer.GetCurrentCar();
        prevCarBtn.onClick.AddListener(OnPrev);
        nextCarBtn.onClick.AddListener(OnNext);
    }

    private void OnPrev()
    {
        Destroy(playerDisplay);
        playerIndex = DataPlayer.GetPrevCarId();
        StartCoroutine(InitPlayer());
        AudioControl.Instance.OnPlayButtonSound();
    }

    private void OnNext()
    {
        Destroy(playerDisplay);
        playerIndex = DataPlayer.GetNextCarId();
        StartCoroutine(InitPlayer());
        AudioControl.Instance.OnPlayButtonSound();
    }
    private IEnumerator Start()
    {
        yield return InitPlayer();
    }
    private IEnumerator InitPlayer()
    {
        var request = Resources.LoadAsync<GameObject>($"Player_Display/Player_Display {playerIndex}");
        while (!request.isDone)
        {
            yield return null;
        }
        playerDisplayPrefab = (GameObject)request.asset;
        SetPlayerDisplay();
        SetPlayerDisplayState(true);
    }
    private void SetPlayerDisplay()
    {
        playerDisplayPrefab = Resources.Load<GameObject>($"Player_Display/Player_Display {playerIndex}");
        playerDisplay = GameObject.Instantiate(playerDisplayPrefab, transform);
        playerDisplay.transform.localPosition = Vector3.zero;
    }
    private void OnEnable()
    {
        EventManager.StartListening(EventName.PRESENTER_TRIGGER_1, OnTrigger1);
        EventManager.StartListening(EventName.PRESENTER_TRIGGER_2, OnTrigger2);
    }
    private void OnDisable()
    {
        EventManager.StopListening(EventName.PRESENTER_TRIGGER_1, OnTrigger1);
        EventManager.StopListening(EventName.PRESENTER_TRIGGER_2, OnTrigger2);
    }
    private void OnTrigger1()
    {
        bool isActive = EventManager.GetBool(EventName.PRESENTER_TRIGGER_1);
        SetPlayerDisplayState(isActive);
    }
    private void OnTrigger2()
    {
        bool isActive = EventManager.GetBool(EventName.PRESENTER_TRIGGER_2);
        SetPlayerDisplayState(isActive);
    }
    private void SetPlayerDisplayState(bool isActive)
    {
        playerDisplay.gameObject.SetActive(isActive);
    }
}
