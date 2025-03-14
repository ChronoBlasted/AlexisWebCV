using Chrono.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopLayout : MonoBehaviour
{
    [SerializeField] Image _ico, _border;
    [SerializeField] TMP_Text _nameTxt;

    [SerializeField] CustomButton _buyButton;

    StoreData _offer;

    public void Init(StoreData offer)
    {
        _offer = offer;

        _ico.sprite = _offer.Sprite;

        _nameTxt.text = _offer.Name.GetLocalizedString();
    }

    public void HandleOnBuyOffer()
    {
        ShowReward();
    }

    private void ShowReward()
    {
        UIManager.Instance.RewardPopup.OpenPopup();
        UIManager.Instance.RewardPopup.UpdateData(_offer);
    }
}


