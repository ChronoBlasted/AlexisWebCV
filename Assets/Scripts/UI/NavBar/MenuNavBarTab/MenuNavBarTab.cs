using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavBarTab : NavBarTab
{
    [SerializeField] LayoutElement _layoutElement;
    [SerializeField] Image _bg, _ico;
    [SerializeField] TMP_Text _title;

    [SerializeField] Panel _tab;

    Sequence _growSequence;

    public override void HandleOnPress()
    {
        base.HandleOnPress();

        if (_growSequence.IsActive()) _growSequence.Kill();

        _growSequence = DOTween.Sequence();

        _growSequence
            .Join(DOVirtual.Float(_layoutElement.flexibleWidth, 1.5f, .2f, x => _layoutElement.flexibleWidth = x))
            .Join(_bg.rectTransform.DOSizeDelta(new Vector2(0, 120), .2f))
            .Join(_ico.rectTransform.DOSizeDelta(new Vector2(256, 256), .2f))
            .Join(_ico.rectTransform.DOAnchorPosY(10, .2f))
            .Join(_title.rectTransform.DOAnchorPosY(-80, .2f));

        _tab.OpenPanel();
    }

    public override void HandleOnReset()
    {
        base.HandleOnReset();

        if (_growSequence.IsActive()) _growSequence.Kill();

        _growSequence = DOTween.Sequence();

        _growSequence
            .Join(DOVirtual.Float(_layoutElement.flexibleWidth, 1, .2f, x => _layoutElement.flexibleWidth = x))
            .Join(_bg.rectTransform.DOSizeDelta(new Vector2(0, 80), .2f))
            .Join(_ico.rectTransform.DOSizeDelta(new Vector2(128, 128), .2f))
            .Join(_ico.rectTransform.DOAnchorPosY(-100, .2f))
            .Join(_title.rectTransform.DOAnchorPosY(-144, .2f));

        _tab.ClosePanel();
    }

}
