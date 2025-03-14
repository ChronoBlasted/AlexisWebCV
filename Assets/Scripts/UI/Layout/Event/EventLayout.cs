using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventLayout : MonoBehaviour
{
    public int DaysBeforeEvent;

    [SerializeField] Image _ico, _border;
    [SerializeField] TMP_Text _nameTxt, _descTxt, _dateTxt;

    [SerializeField] EventData _data;

    public void Init()
    {
        _ico.sprite = _data.Sprite;

        _nameTxt.text = _data.Name.GetLocalizedString();
        _descTxt.text = _data.Desc.GetLocalizedString();

        DaysBeforeEvent = _data.FirstOfTheMonths ? DaysUntilFirstX(_data.TargetDay) : DaysUntilNextDay(_data.TargetDay);

        _dateTxt.text = "Dans " + DaysBeforeEvent + " jours";
    }

    int DaysUntilFirstX(DayOfWeek day)
    {
        DateTime today = DateTime.Today;
        DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

        int daysToAdd = (day - firstDayOfMonth.DayOfWeek + 7) % 7;
        DateTime firstX = firstDayOfMonth.AddDays(daysToAdd);

        int difference = (firstX - today).Days;

        if (difference < 0)
        {
            DateTime firstDayNextMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1);
            int daysToAddNext = (day - firstDayNextMonth.DayOfWeek + 7) % 7;
            DateTime firstXNextMonth = firstDayNextMonth.AddDays(daysToAddNext);
            difference = (firstXNextMonth - today).Days;
        }

        return difference;
    }

    int DaysUntilNextDay(DayOfWeek targetDay)
    {
        DateTime today = DateTime.Today;
        int daysUntilNext = ((int)targetDay - (int)today.DayOfWeek + 7) % 7;

        return daysUntilNext == 0 ? 7 : daysUntilNext;
    }
}
