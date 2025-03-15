using System;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "NewEventData", menuName = "ScriptableObjects/NewEventDataObject", order = 1)]
public class EventData : ResourceData
{
    public LocalizedString Desc;
    public DateTime DateTime;
    public DayOfWeek TargetDay;
    public bool FirstOfTheMonths;
    public string EventDate; // Format: YYYY-MM-DD
}
