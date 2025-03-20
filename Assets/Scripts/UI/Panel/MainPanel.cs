using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : Panel
{
    [SerializeField] CanvasGroup _settingMenu;
    [SerializeField] List<ExpLayout> _expLayout;

    Tweener _settingFadeTweener;
    public override void Init()
    {
        base.Init();

        InitExp();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.Instance.MenuView.TopBar.ShowTopBar();
    }

    public void OpenLinkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/gelin-alexis/");
    }

    public void OpenContactInfo()
    {
        UIManager.Instance.AddPopup(UIManager.Instance.ProfilePopup);
    }

    public void OpenQuest()
    {

    }

    public void OpenSettingMenu()
    {
        UIManager.Instance.ShowBlackShade(CloseSettingMenu);

        _settingMenu.gameObject.SetActive(true);

        if (_settingFadeTweener.IsActive()) _settingFadeTweener.Kill();

        _settingFadeTweener = _settingMenu.DOFade(1, .2f).OnComplete(() =>
        {
            _settingMenu.blocksRaycasts = true;
            _settingMenu.interactable = true;
        }).SetUpdate(UpdateType.Normal, true);

        _settingMenu.gameObject.transform.localScale = Vector3.zero;
        _settingMenu.gameObject.transform.DOScale(new Vector3(1, 1, 1), .2f).SetEase(Ease.OutBack);
    }

    public void CloseSettingMenu()
    {
        UIManager.Instance.HideBlackShade();

        if (_settingFadeTweener.IsActive()) _settingFadeTweener.Kill();

        _settingMenu.blocksRaycasts = false;
        _settingMenu.interactable = false;

        _settingFadeTweener = _settingMenu.DOFade(0, 0f)
            .OnComplete(() =>
            {
                _settingMenu.gameObject.SetActive(false);
            })
            .SetUpdate(UpdateType.Normal, true);
    }

    public void OpenProfile()
    {
        UIManager.Instance.AddPopup(UIManager.Instance.ProfilePopup);
    }

    public void OpenSettings()
    {
        UIManager.Instance.ChangeView(UIManager.Instance.SettingView);
    }

    public void OpenFriends()
    {

    }

    void InitExp()
    {
        foreach (var exp in _expLayout)
        {
            exp.Init();
        }
    }
}
