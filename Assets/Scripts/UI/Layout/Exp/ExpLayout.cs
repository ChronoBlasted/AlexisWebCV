using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ExpLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _title;
    [SerializeField] Animator _animator;
    [SerializeField] Image _glow, _fade, _bg;

    [SerializeField] ExpData _data;

    [SerializeField] Sprite _proBG, _jamBG, _schoolBG;
    [SerializeField] ChronoTweenObject _chronoObject;

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
        _animator.Play(_data.Animation.name);
    }
}
