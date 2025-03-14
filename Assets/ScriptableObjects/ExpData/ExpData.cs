using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "NewExpData", menuName = "ScriptableObjects/NewExpDataObject", order = 0)]
public class ExpData : ScriptableObject
{
    public ExpType ExpType;
    public LocalizedString Name;
    public LocalizedString Desc;
    public string StartTime;// Format: YYYY-MM-DD
    public string EndTime;// Format: YYYY-MM-DD
    public Sprite Splash;
    public List<Sprite> Screens;
}
