using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;

public class Player_Select : MonoBehaviour
{
    private int index;
    private GameObject playerPrefab;
    private GameObject player;
    void Start()
    {
        index = DataPlayer.GetCurrentCar();
        SetPlayerState();
        SetPlayer(true); 
    }
    private void SetPlayerState()
    {
        playerPrefab = Resources.Load<GameObject>($"Player_Select/Player_{index}");
        player = Instantiate(playerPrefab, transform);
        player.transform.localPosition = Vector3.zero;
    }
    private void SetPlayer(bool isActive)
    {
        player.SetActive(isActive);
    }
    private void OnEnable()
    {
        EventManager.StartListening(EventName.PLAYER_TRIGGER, OnTrigger);
    }
    private void OnDisable()
    {
        EventManager.StopListening(EventName.PLAYER_TRIGGER, OnTrigger);
    }
    private void OnTrigger()
    {
        var isActive = EventManager.GetBool(EventName.PLAYER_TRIGGER);
        SetPlayer(isActive);
    }
}
