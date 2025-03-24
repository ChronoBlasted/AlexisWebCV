using DG.Tweening;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainPanel : Panel
{
    [SerializeField] CanvasGroup _settingMenu;
    [SerializeField] List<ExpLayout> _expLayout;

    [SerializeField] Transform _characterTransform;
    [SerializeField] List<LocalizedString> _alexisChatTuto;
    [SerializeField] List<LocalizedString> _alexisChat;
    [SerializeField] Transform _spawnChatTransformRight, _spawnChatTransformLeft;

    int indexTuto;
    bool isCharacterLeftSide;

    Tweener _settingFadeTweener;
    public override void Init()
    {
        base.Init();

        InitExp();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
    }

    public void OpenLinkedin()
    {
        UIManager.Instance.ConfirmPopup.UpdateData(
            LocalizationManager.Instance.OpenURL.GetLocalizedString(),
            LocalizationManager.Instance.GonnaBeRedirect.GetLocalizedString(),
            () => Application.OpenURL("https://www.linkedin.com/in/gelin-alexis/"));

        UIManager.Instance.AddPopup(UIManager.Instance.ConfirmPopup);
    }

    public void OpenContactInfo()
    {
        UIManager.Instance.AddPopup(UIManager.Instance.ProfilePopup);
    }

    public void OpenQuest()
    {
        UIManager.Instance.AddPopup(UIManager.Instance.QuestPopup);
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
        UIManager.Instance.ChangeView(UIManager.Instance.FriendView);
    }

    void InitExp()
    {
        foreach (var exp in _expLayout)
        {
            exp.Init();
        }
    }

    public void SendChat()
    {
        var currentChat = PoolManager.Instance[ResourceType.Chat].Get().GetComponent<ChatLayout>();

        var swapX = Random.Range(0, 2);
        if (swapX == 0)
        {
            _characterTransform.transform.localScale = new Vector3(-1, 1, 1);
            isCharacterLeftSide = true;
        }
        if (swapX == 1)
        {
            _characterTransform.transform.localScale = new Vector3(1, 1, 1);
            isCharacterLeftSide = false;
        }

        currentChat.transform.parent = isCharacterLeftSide ? _spawnChatTransformLeft : _spawnChatTransformRight;
        currentChat.transform.localPosition = Vector3.zero;

        currentChat.Init(GetRandomMessage(), !isCharacterLeftSide);

        DOTween.Sequence()
            .Join(currentChat.transform.DOLocalMoveY(256, 5f).SetEase(Ease.OutSine))
            .Join(currentChat.Cg.DOFade(0f, 2f).SetDelay(4f))
            .OnComplete(() =>
            {
                PoolManager.Instance[ResourceType.Chat].Release(currentChat.gameObject);
            });
    }

    string GetRandomMessage()
    {
        string response;

        if (indexTuto < _alexisChatTuto.Count)
        {
            response = _alexisChatTuto[indexTuto].GetLocalizedString();

            indexTuto++;
        }
        else
        {
            response = _alexisChat[Random.Range(0, _alexisChat.Count)].GetLocalizedString();
        }

        return response;
    }
}
