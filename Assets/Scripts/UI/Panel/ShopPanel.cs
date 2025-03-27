using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ShopPanel : Panel
{
    [SerializeField] ScrollRect _scrollRect;
    [SerializeField] List<ShopLayout> _hardShopLayouts, _softShopLayouts, _passionShopLayouts;
    [SerializeField] List<StoreData> _hardShopData, _softShopData, _passionShopData;

    [SerializeField] LocalizedString _supportCreator, _enterCreator, _creatorName, _errorCreator;
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

        UIManager.ResetScroll(_scrollRect);
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
        UIManager.Instance.ConfirmPopup.UpdateDataWithInputField(_supportCreator.GetLocalizedString(), _enterCreator.GetLocalizedString(), _creatorName.GetLocalizedString(), IsCreatorValid);
        UIManager.Instance.AddPopup(UIManager.Instance.ConfirmPopup);
    }

    public void IsCreatorValid(string creator)
    {
        if (creator == "Veemo")
        {
            UIManager.Instance.ErrorView.AddMessage("! TIABINA !");
        }
        else if (creator == "Clarisse" || creator == "Mortifera")
        {
            UIManager.Instance.ErrorView.AddMessage("! JE T'AIME !");
        }
        else if (creator == "Marius")
        {
            UIManager.Instance.ErrorView.AddMessage("! WORLD SKILLS !");
        }
        else if (creator == "Emie")
        {
            UIManager.Instance.ErrorView.AddMessage("! BM-EMI-X !");
        }
        else if (creator == "LePoulet")
        {
            UIManager.Instance.ErrorView.AddMessage("! COT COT !");
        }
        else
        {
            UIManager.Instance.ErrorView.AddError(_errorCreator.GetLocalizedString());
        }
    }
}
