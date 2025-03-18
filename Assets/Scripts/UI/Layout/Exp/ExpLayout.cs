using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class ExpLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _title, _timeToProduce;
    [SerializeField] Animator _animator;

    [SerializeField] ExpData _data;

    [SerializeField] LocalizedString _yearTrad, _monthTrad, _dayTrad;

    public void Init(ExpData data)
    {
        _data = data;

        _title.text = _data.Name.GetLocalizedString();

        var startDate = DateTime.Parse(_data.StartTime);
        var endDate = DateTime.Parse(_data.EndTime);

        string timeToProduce = CalculateDateDifference(startDate, endDate);

        _timeToProduce.text = timeToProduce;
    }

    public void Init()
    {
        Init(_data);
    }

    public string CalculateDateDifference(DateTime startDate, DateTime endDate)
    {
        int years = endDate.Year - startDate.Year;
        int months = endDate.Month - startDate.Month;
        int days = endDate.Day - startDate.Day;

        if (days < 0)
        {
            months--;
            days += DateTime.DaysInMonth(startDate.Year, startDate.Month);
        }

        if (months < 0)
        {
            years--;
            months += 12;
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
        Application.OpenURL(_data.ItchURL);
    }


    private void OnEnable()
    {
        _animator.Play(_data.Animation.name);
    }
}
