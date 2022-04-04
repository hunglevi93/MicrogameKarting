using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class ShopUI : MonoBehaviour
{
    public Button HideShopUIBtn;
    public Animator ShopUIAnimation;
    public Animator MainUIAnimation;
    public ShopElements[] shopElements;

    private void OnValidate()
    {
        if(shopElements == null || shopElements.Length == 0)
        {
            shopElements = GetComponentsInChildren<ShopElements>();
        }
    }
    private void SetData()
    {
        for(int i = 0; i < shopElements.Length; i++)
        {
            shopElements[i].SetData(i+1);
        }
    }
    void Awake()
    {
        HideShopUIBtn.onClick.AddListener(OnHideShopUI);
        SetData();
    } 
    private void OnHideShopUI()
    {
        ShopUIAnimation.Play("out");
        MainUIAnimation.Play("in");
        AudioControl.Instance.OnUiSound();
    }
    private void DestroyShopUI()
    {
        gameObject.SetActive(false);
        EventManager.EmitEventData(EventName.PRESENTER_TRIGGER_2, true);
    }
}
