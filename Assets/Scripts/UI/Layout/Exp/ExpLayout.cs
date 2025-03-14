using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _title, _timeToProduce;
    [SerializeField] Image _ico;

    [SerializeField] ExpData _data;

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

        if (months < 0)
        {
            years--;
            months += 12;
        }

        return $"{years}Y {months}M"; // TODO Translate
    }
}
