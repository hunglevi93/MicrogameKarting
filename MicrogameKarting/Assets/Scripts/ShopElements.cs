using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopElements : MonoBehaviour
{   
    private int id, cost;
    public GameObject coinImg;
    private GameObject playerItem;
    private GameObject playerItemPrefab;

    public Text costTxt;

    public Button PurchaseBtn;

    public void SetData(int id)
    {
        this.id = id;
        cost = id * 100;
        SetPlayerItem();
        UpDateView();
    }
    private void SetPlayerItem()
    {
        playerItemPrefab = Resources.Load<GameObject>($"Player_Items/Player_item_{id}");
        playerItem = Instantiate(playerItemPrefab, transform);
    }
    private void UpDateView()
    {
        var isOwned = DataPlayer.isOwnedCarWithId(id);
        if(isOwned)
        {
            coinImg.SetActive(false);
            costTxt.text = "Owned";
            PurchaseBtn.enabled = false;
        }
        else
        {
            coinImg.SetActive(true);
            costTxt.text = cost.ToString();
            PurchaseBtn.enabled = true;
        }
    }
    void Awake()
    {
        PurchaseBtn.onClick.AddListener(OnPurchase);
    }
    private void OnPurchase()
    {
        var canBuyCar = DataPlayer.isEnoughMoney(cost);
        if(canBuyCar)
        {
            DataPlayer.Subcoin(cost);
            DataPlayer.AddCar(id);
            UpDateView();
            AudioControl.Instance.OnPlayButtonSound();
        }           
    }
}
