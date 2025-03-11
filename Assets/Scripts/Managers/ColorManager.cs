using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoSingleton<ColorManager>
{
    [SerializeField] Color _healColor, _manaColor, _catchColor, _statusColor;
    [SerializeField] Color _activeColor, _inactiveColor;

    public Color ActiveColor { get => _activeColor; }
    public Color InactiveColor { get => _inactiveColor; }
}
