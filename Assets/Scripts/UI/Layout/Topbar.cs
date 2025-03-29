using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class Topbar : MonoBehaviour
{
    [SerializeField] CanvasGroup _cg;
    public string pdfFileName = "AlexisCV.pdf";


    Sequence _showHideTopbarTween;
    public void ShowTopBar()
    {
        if (_showHideTopbarTween.IsActive()) _showHideTopbarTween.Kill(true);

        _showHideTopbarTween = DOTween.Sequence();

        RectTransform rectTransform = (RectTransform)transform;

        _cg.interactable = true;
        _cg.blocksRaycasts = true;

        _showHideTopbarTween
            .Join(rectTransform.DOAnchorPosY(-16, .2f).SetEase(Ease.OutBack))
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

    public void HandleOnLanguageClick()
    {
        Locale currentLocale = LocalizationSettings.SelectedLocale;

        int index = LocalizationSettings.AvailableLocales.Locales.IndexOf(currentLocale);

        int nextIndex = (index + 1) % LocalizationSettings.AvailableLocales.Locales.Count;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[nextIndex];

        GameManager.Instance.ReloadScene();
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void DownloadCV()
    {

        Application.OpenURL("https://cdn.jsdelivr.net/gh/chronoblasted/videos-unity/AlexisCV.pdf");
    }
}
