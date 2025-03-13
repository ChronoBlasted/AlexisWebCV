using Chrono.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopLayout : MonoBehaviour
{
    [SerializeField] Image _ico, _border, _priceIco;
    [SerializeField] TMP_Text _nameTxt, _priceAmount;

    [SerializeField] CustomButton _buyButton;

    StoreData _offer;

    public void Init(StoreData offer)
    {
        _offer = offer;

        _priceAmount.text = _offer.Price.ToString();

        _ico.sprite = _offer.Sprite;

        _nameTxt.text = _offer.Name.GetLocalizedString();

        _priceIco.sprite = ResourceObjectHolder.Instance.GetResourceByType((ResourceType)_offer.Currency).Sprite;
    }

    public void HandleOnBuyOffer()
    {
        if (_offer.Price > CurrencyManager.Instance.GetCurrency(_offer.Currency))
        {
            switch (_offer.Currency)
            {
                case Currency.Exp:
                    ErrorManager.Instance.ShowError(ErrorType.NOT_ENOUGH_EXP);
                    break;
                case Currency.Life:
                    ErrorManager.Instance.ShowError(ErrorType.NOT_ENOUGH_LIFE);
                    break;
                default:
                    break;
            }
            return;
        }

        CurrencyManager.Instance.UseCurrency(_offer.Currency, _offer.Price);

        ShowReward();
    }

    private void ShowReward()
    {
        UIManager.Instance.RewardPopup.OpenPopup();
        UIManager.Instance.RewardPopup.UpdateData(_offer);
    }
}


