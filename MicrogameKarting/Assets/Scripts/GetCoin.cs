using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            AudioControl.Instance.OnAddCoinSound();
            Destroy(gameObject);
            DataPlayer.AddCoin(20);
        }
    }
}
