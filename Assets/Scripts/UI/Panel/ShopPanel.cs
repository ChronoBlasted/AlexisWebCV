using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : Panel
{
    [SerializeField] List<ShopLayout> _hardShopLayouts, _softShopLayouts, _passionShopLayouts;
    [SerializeField] List<StoreData> _hardShopData, _softShopData, _passionShopData;

    public override void Init()
    {
        base.Init();

        UpdateOffers(_hardShopLayouts, _hardShopData);
        UpdateOffers(_softShopLayouts, _softShopData);
        UpdateOffers(_passionShopLayouts, _passionShopData);
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
    }

    public void UpdateOffers(List<ShopLayout> allShopLayout, List<StoreData> allStoreOffer)
    {
        for (int i = 0; i < allShopLayout.Count; i++)
        {
            allShopLayout[i].Init(allStoreOffer[i]);
        }
    }

    public void HandleOnSupportCreator()
    {
        UIManager.Instance.ConfirmPopup.UpdateDataWithInputField("Support a creator", "Enter a creator name", "Creator name", IsCreatorValid);
        UIManager.Instance.AddPopup(UIManager.Instance.ConfirmPopup);
    }

    public void IsCreatorValid(string creator)
    {
        if (creator == "Veemo")
        {
            UIManager.Instance.ErrorView.AddError("! TIABINA !");
        }
        else
        {
            UIManager.Instance.ErrorView.AddError("This creator doesn't exist");
        }
    }
}
