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
        creator = creator.ToLower();

        if (creator == "veemo")
        {
            UIManager.Instance.ErrorView.AddMessage("! TIABINA !");
        }
        else if (creator == "clarisse timotic" || creator == "mortifera")
        {
            UIManager.Instance.ErrorView.AddMessage("! JE T'AIME !");
        }
        else if (creator == "marius perrier")
        {
            UIManager.Instance.ErrorView.AddMessage("! WORLD SKILLS !");
        }
        else if (creator == "emie masnata")
        {
            UIManager.Instance.ErrorView.AddMessage("! BM-EMI-X !");
        }
        else if (creator == "lepoulet" || creator == "ralph nicolas")
        {
            UIManager.Instance.ErrorView.AddMessage("! COT COT !");

            Application.OpenURL("https://store.steampowered.com/app/3140120/Wordatro/");
        }
        else if (creator == "alexandre montel")
        {
            UIManager.Instance.ErrorView.AddMessage("! CACA PIPI PROUT !");
        }
        else if (creator == "gwenaelle devriendt" || creator == "arcaname")
        {
            UIManager.Instance.ErrorView.AddMessage("! GOUT HAINE !");

            Application.OpenURL("https://arcaname.itch.io/");
        }
        else if (creator == "damien rouzeau" || creator == "fritalo")
        {
            UIManager.Instance.ErrorView.AddMessage("! DAMSITO !");

            Application.OpenURL("https://damienrzu.itch.io/khorteus");
        }
        else if (creator == "jena poree" || creator == "naejdoree")
        {
            UIManager.Instance.ErrorView.AddMessage("! CONTENIR !");

            Application.OpenURL("https://www.contenir.studio.naejdoree.art/");
        }
        else if (creator == "ludovic bas" || creator == "loudo")
        {
            UIManager.Instance.ErrorView.AddMessage("! CRANKSTONE !");

            Application.OpenURL("https://shop.lugludum.com/en-eur/pages/playdate-games");
        }
        else if (creator == "cédric roux" || creator == "tyron")
        {
            UIManager.Instance.ErrorView.AddMessage("! THE REAL HERO !");

            Application.OpenURL("https://store.steampowered.com/app/3403090/Fire_Hero__Pixel_Rescue");
        }
        else if (creator == "sharuu"  || creator == "eric miclo")
        {
            UIManager.Instance.ErrorView.AddMessage("! THE ONLINE INDIE PROG !");

            Application.OpenURL("https://store.steampowered.com/app/2999130/Flex_Riders");
        }
        else
        {
            UIManager.Instance.ErrorView.AddError(_errorCreator.GetLocalizedString());
        }
    }
}
