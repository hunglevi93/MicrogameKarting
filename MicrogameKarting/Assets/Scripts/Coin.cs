using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text coinTxt;

    private void Start()
    {
        UpdateView();
    }

    private void UpdateView()
    {
       coinTxt.text = DataPlayer.GetCoin().ToString();
    }

    private void OnEnable()
    {
        DataPlayer.AddListener(UpdateView);
    }

    private void OnDisable()
    {
        DataPlayer.RemoveListener(UpdateView);
    }
}
