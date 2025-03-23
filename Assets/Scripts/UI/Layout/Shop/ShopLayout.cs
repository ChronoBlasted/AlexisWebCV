using Chrono.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopLayout : MonoBehaviour
{
    [SerializeField] Image _ico, _bg, _glow;
    [SerializeField] TMP_Text _nameTxt;

    [SerializeField] CustomButton _buyButton;

    [SerializeField] Sprite _hardBG, _softBG, _passionBG;

    StoreData _data;

    public void Init(StoreData offer)
    {
        _data = offer;

        _ico.sprite = _data.Sprite;

        switch (_data.Type)
        {
            case ResourceType.Hard:
                _bg.sprite = _hardBG;
                break;
            case ResourceType.Soft:
                _bg.sprite = _softBG;
                break;
            case ResourceType.Passion:
                _bg.sprite = _passionBG;
                break;

        }

        _glow.color = ColorManager.Instance.GetGlowColorBySkills((Skills)_data.Type);

        _nameTxt.text = _data.Name.GetLocalizedString();
    }

    public void HandleOnBuyOffer()
    {
        ShowReward();
    }

    private void ShowReward()
    {
        UIManager.Instance.RewardPopup.OpenPopup();
        UIManager.Instance.RewardPopup.UpdateData(_data);
    }
}


