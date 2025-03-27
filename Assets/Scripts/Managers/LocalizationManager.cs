using BaseTemplate.Behaviours;
using UnityEngine;
using UnityEngine.Localization;

public class LocalizationManager : MonoSingleton<LocalizationManager>
{
    [Header("Attribute")]
    [SerializeField] LocalizedString _leadDevTrad;
    [SerializeField] LocalizedString _solodevTrad, _onlyDevTrad, _bigProject;

    [Header("Role")]
    [SerializeField] LocalizedString _dev;
    [SerializeField] LocalizedString _artist, _market;

    public LocalizedString OpenURL, GonnaBeRedirect;

    string errorString = "Error";

    public string GetStringByAttribute(Attribute attribute)
    {
        switch (attribute)
        {
            case Attribute.LeadDev:
                return _leadDevTrad.GetLocalizedString();
            case Attribute.Solodev:
                return _solodevTrad.GetLocalizedString();
            case Attribute.OnlyDev:
                return _onlyDevTrad.GetLocalizedString();
            case Attribute.BigProject:
                return _bigProject.GetLocalizedString();
        }

        return errorString;
    }

    public string GetStringByRole(Role role)
    {
        switch (role)
        {
            case Role.Dev:
                return _dev.GetLocalizedString();
            case Role.Artist:
                return _artist.GetLocalizedString();
            case Role.Market:
                return _market.GetLocalizedString();
        }

        return errorString;
    }
}