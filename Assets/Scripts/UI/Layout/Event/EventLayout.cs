using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class EventLayout : MonoBehaviour
{
    public int DaysBeforeEvent;

    [SerializeField] Image _ico, _border;
    [SerializeField] TMP_Text _nameTxt, _descTxt, _dateTxt;

    [SerializeField] EventData _data;

    [SerializeField] LocalizedString _inDaysTrad, _wasTrad;
    [SerializeField] LocalizedString _yearTrad, _monthTrad, _dayTrad;

    public void Init()
    {
        _ico.sprite = _data.Sprite;

        _nameTxt.text = _data.Name.GetLocalizedString();
        _descTxt.text = _data.Desc.GetLocalizedString();

        DaysBeforeEvent = _data.FirstOfTheMonths ? DaysUntilFirstX(_data.TargetDay) : DaysUntilNextDay(_data.TargetDay);

        if (_data.EventDate != "")
        {
            var date = DateTime.Parse(_data.EventDate);
            _dateTxt.text = _wasTrad.GetLocalizedString() + " " + YearsMonthsDaysFromDate(date);
        }
        else
        {
            _dateTxt.text = _inDaysTrad.GetLocalizedString() + " " + DaysBeforeEvent + " " + _dayTrad.GetLocalizedString(DaysBeforeEvent);
        }
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

    public string YearsMonthsDaysFromDate(DateTime startDate)
    {
        DateTime today = DateTime.Today;

        int years = today.Year - startDate.Year;

        int months = today.Month - startDate.Month;

        if (months < 0)
        {
            months += 12;
            years--;
        }

        int days = today.Day - startDate.Day;

        if (days < 0)
        {
            months--;
            DateTime previousMonth = today.AddMonths(-1);
            days += DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
        }

        if (months < 0)
        {
            months += 12;
            years--;
        }

        string result = "";

        if (years > 0)
            result += years + " " + _yearTrad.GetLocalizedString(years) + " ";

        if (months > 0)
            result += months + " " + _monthTrad.GetLocalizedString(months) + " ";

        if (days > 0)
            result += days + " " + _dayTrad.GetLocalizedString(days);

        return result.Trim();
    }

    public void HandleOnClick()
    {
        UIManager.Instance.ConfirmPopup.UpdateData(LocalizationManager.Instance.OpenURL.GetLocalizedString(), LocalizationManager.Instance.GonnaBeRedirect.GetLocalizedString(), () => Application.OpenURL(_data.EventLink));
        UIManager.Instance.AddPopup(UIManager.Instance.ConfirmPopup);
    }
}
