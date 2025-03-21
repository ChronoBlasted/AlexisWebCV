using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "NewExpData", menuName = "ScriptableObjects/NewExpDataObject", order = 0)]
public class ExpData : ScriptableObject
{
    public ExpType ExpType;
    public LocalizedString Name;
    public LocalizedString Desc;
    public string StartTime;    // Format: YYYY-MM-DD
    public string EndTime;      // Format: YYYY-MM-DD
    public AnimationClip Animation;
    public string ItchURL = "https://alexisgelin.itch.io/";
    public Attribute Attribute;
    public List<CollaboratorData> Collaborators;
}

[Flags]
public enum Attribute
{
    None = 0,
    LeadDev = 1,
    Solodev = 2,
    OnlyDev = 4,
    BigProject = 8,
}


