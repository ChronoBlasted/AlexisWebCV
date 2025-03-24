using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoSingleton<ColorManager>
{
    [SerializeField] Color _orangeColor, _blueColor, _greenColor;
    [SerializeField] Color _orangeGlowColor, _blueGlowColor, _purpleGlowColor, _greenGlowColor;
    [SerializeField] Sprite _leadDevSprite, _solodevSprite, _bigProjectSprite, _onlyDevSprite;

    public Color GetColorByRole(Role role)
    {
        switch (role)
        {
            case Role.Dev:
                return _blueColor;
            case Role.Artist:
                return _greenColor;
            case Role.Market:
                return _orangeColor;
        }

        return Color.white;
    }

    public Color GetSecondColorByRole(Role role)
    {
        switch (role)
        {
            case Role.Dev:
                return _blueGlowColor;
            case Role.Artist:
                return _greenGlowColor;
            case Role.Market:
                return _orangeGlowColor;
        }

        return Color.white;
    }

    public Color GetGlowColorBySkills(Skills skills)
    {
        switch (skills)
        {
            case Skills.Hard:
                return _orangeGlowColor;
            case Skills.Soft:
                return _purpleGlowColor;
            case Skills.Passion:
                return _greenGlowColor;
        }

        return Color.white;
    }

    public Color GetColorByExp(ExpType expType)
    {
        switch (expType)
        {
            case ExpType.PRO:
                return _blueColor;
            case ExpType.JAMS:
                return _greenColor;
            case ExpType.SCHOOL:
                return _orangeColor;
        }

        return Color.white;
    }
    public Color GetGlowColorByExp(ExpType expType)
    {
        switch (expType)
        {
            case ExpType.PRO:
                return _blueGlowColor;
            case ExpType.SCHOOL:
                return _orangeGlowColor;
            case ExpType.JAMS:
                return _greenGlowColor;
        }

        return Color.white;
    }

    public Sprite GetSpriteByAttribute(Attribute attribute)
    {
        switch (attribute)
        {
            case Attribute.LeadDev:
                return _leadDevSprite;
            case Attribute.Solodev:
                return _solodevSprite;
            case Attribute.OnlyDev:
                return _onlyDevSprite;
            case Attribute.BigProject:
                return _bigProjectSprite;
        }

        return null;
    }
}