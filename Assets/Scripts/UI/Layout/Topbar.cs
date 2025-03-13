using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Topbar : MonoBehaviour
{
    [SerializeField] CanvasGroup _cg;
    [SerializeField] TMP_Text _expTxt, _lifeTxt;

    Sequence _showHideTopbarTween;

    public void Init()
    {
        CurrencyManager.Instance.OnCurrencyChange += UpdateExp;
        CurrencyManager.Instance.OnCurrencyChange += UpdateLife;

        UpdateExp();
        UpdateLife();
    }

    public void UpdateExp()
    {
        _expTxt.text = UIManager.GetFormattedInt(CurrencyManager.Instance.GetCurrency(Currency.Exp));
    }


    public void UpdateLife()
    {
        _lifeTxt.text = UIManager.GetFormattedInt(CurrencyManager.Instance.GetCurrency(Currency.Life));
    }

    public void ShowTopBar()
    {
        if (_showHideTopbarTween.IsActive()) _showHideTopbarTween.Kill(true);

        _showHideTopbarTween = DOTween.Sequence();

        RectTransform rectTransform = (RectTransform)transform;

        _cg.interactable = true;
        _cg.blocksRaycasts = true;

        _showHideTopbarTween
            .Join(rectTransform.DOAnchorPosY(-40, .2f).SetEase(Ease.OutBack))
            .Join(_cg.DOFade(1, .1f));

    }

    public void HideTopBar()
    {
        if (_showHideTopbarTween.IsActive()) _showHideTopbarTween.Kill(true);

        _showHideTopbarTween = DOTween.Sequence();

        RectTransform rectTransform = (RectTransform)transform;

        _cg.interactable = false;
        _cg.blocksRaycasts = false;

        _showHideTopbarTween
            .Join(rectTransform.DOAnchorPosY(64, .2f).SetEase(Ease.OutBack))
            .Join(_cg.DOFade(0, .1f));
    }

}
