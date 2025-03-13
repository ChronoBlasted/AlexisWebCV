using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoSingleton<ColorManager>
{
    [SerializeField] Color _expColor, _lifeColor;
    [SerializeField] Color _activeColor, _inactiveColor;

    public Color ActiveColor { get => _activeColor; }
    public Color InactiveColor { get => _inactiveColor; }
    public Color ExpColor { get => _expColor; }
    public Color LifeColor { get => _lifeColor;  }
}
