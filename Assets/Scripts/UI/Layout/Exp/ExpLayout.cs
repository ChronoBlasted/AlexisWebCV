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

    public void Init(ExpData data)
    {
        SetData(data);

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

    public void Init()
    {
        Init(_data);
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
