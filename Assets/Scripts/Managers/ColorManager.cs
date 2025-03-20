using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoSingleton<ColorManager>
{
    [SerializeField] Color _activeColor, _inactiveColor;
    [SerializeField] Color _devColor, _artistColor, _marketColor;
    [SerializeField] Color _leadDevColor, _solodevColor, _bigProjectColor, _onlyDevColor;

    public Color ActiveColor { get => _activeColor; }
    public Color InactiveColor { get => _inactiveColor; }

    public Color GetColorByRole(Role role)
    {
        switch (role)
        {
            case Role.Dev:
                return _devColor;
            case Role.Artist:
                return _artistColor;
            case Role.Market:
                return _marketColor;
        }

        return Color.white;
    }

    public Color GetColorByAttribute(Attribute attribute)
    {
        switch (attribute)
        {
            case Attribute.LeadDev:
                return _leadDevColor;
            case Attribute.Solodev:
                return _solodevColor;
            case Attribute.OnlyDev:
                return _onlyDevColor;
            case Attribute.BigProject:
                return _bigProjectColor;
        }

        return Color.white;
    }
}