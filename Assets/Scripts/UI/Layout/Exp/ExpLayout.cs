using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ExpLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _title, _timeToProduce;
    [SerializeField] RawImage _rawImage;
    [SerializeField] VideoPlayer _videoPlayer;

    [SerializeField] ExpData _data;

    public void Init(ExpData data)
    {
        _data = data;

        _title.text = _data.Name.GetLocalizedString();

        var startDate = DateTime.Parse(_data.StartTime);
        var endDate = DateTime.Parse(_data.EndTime);

        string timeToProduce = CalculateDateDifference(startDate, endDate);

        _timeToProduce.text = timeToProduce;

        _rawImage.texture = _data.RenderTex;
        _videoPlayer.targetTexture = _data.RenderTex;

        _videoPlayer.clip = _data.Clip;
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

    private void OnEnable()
    {
        _videoPlayer.frame = 0;
        _videoPlayer.Play();
    }

    private void OnDisable()
    {
        _videoPlayer.Stop();
    }
}
