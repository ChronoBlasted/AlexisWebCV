using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using UnityEngine.Video;
using static System.Net.WebRequestMethods;

public class ExpLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _title;
    [SerializeField] Image _glow, _fade, _bg;

    [SerializeField] ExpData _data;

    [SerializeField] Sprite _proBG, _jamBG, _schoolBG;
    [SerializeField] ChronoTweenObject _chronoObject;
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] RawImage _rawImage;


    public void Init(ExpData data, bool isInExpPanel)
    {
        SetData(data);

        if (isInExpPanel)
        {
            switch (_data.ExpType)
            {
                case ExpType.PRO:
                    UIManager.Instance.MenuView.ExpPanel.ProSeq.ObjectsToTween.Add(_chronoObject);
                    break;
                case ExpType.JAMS:
                    UIManager.Instance.MenuView.ExpPanel.JamSeq.ObjectsToTween.Add(_chronoObject);
                    break;
                case ExpType.SCHOOL:
                    UIManager.Instance.MenuView.ExpPanel.SchoolSeq.ObjectsToTween.Add(_chronoObject);
                    break;
            }
        }

        _title.text = _data.Name.GetLocalizedString();

        SetColor();
    }

    public void SetData(ExpData data)
    {
        _data = data;

        _rawImage.texture = _data.RenderTexture;
        _videoPlayer.targetTexture = _data.RenderTexture;

        _videoPlayer.url = "https://cdn.jsdelivr.net/gh/chronoblasted/videos-unity/" + _data.name + ".mp4";

        _videoPlayer.Play();
    }

    public void SetColor()
    {
        _glow.color = ColorManager.Instance.GetGlowColorByExp(_data.ExpType);
        _fade.color = ColorManager.Instance.GetGlowColorByExp(_data.ExpType);

        switch (_data.ExpType)
        {
            case ExpType.PRO:
                _bg.sprite = _proBG;
                break;
            case ExpType.JAMS:
                _bg.sprite = _jamBG;
                break;
            case ExpType.SCHOOL:
                _bg.sprite = _schoolBG;
                break;
        }
    }

    public void Init(bool isInExpPanel)
    {
        Init(_data, isInExpPanel);
    }


    public void HandleOnClick()
    {
        UIManager.Instance.ConfirmPopup.UpdateData(LocalizationManager.Instance.OpenURL.GetLocalizedString(), LocalizationManager.Instance.GonnaBeRedirect.GetLocalizedString(), () => Application.OpenURL(_data.ItchURL));
        UIManager.Instance.AddPopup(UIManager.Instance.ConfirmPopup);
    }


    private void OnEnable()
    {
    }
}
