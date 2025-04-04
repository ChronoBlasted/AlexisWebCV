using DG.Tweening;
using NUnit.Framework;
using System;
using System.Collections;
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
    [SerializeField] Transform _alexisLayout, _spawnChatTransformRight, _spawnChatTransformLeft;

    public int IndexTuto;
    bool isCharacterLeftSide;

    Tweener _settingFadeTweener;
    Coroutine _talkCor;

    public List<LocalizedString> AlexisChatTuto { get => _alexisChatTuto; }

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
        Application.OpenURL("https://www.linkedin.com/in/gelin-alexis/");
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
            exp.Init(false);
        }
    }

    public void SendChat()
    {
        var currentChat = PoolManager.Instance[ResourceType.Chat].Get().GetComponent<ChatLayout>();

        isCharacterLeftSide = !isCharacterLeftSide;

        _characterTransform.transform.localScale = isCharacterLeftSide ? new Vector3(-1, 1, 1) : Vector3.one;

        currentChat.transform.SetParent(_alexisLayout);
        currentChat.transform.localPosition = isCharacterLeftSide ? _spawnChatTransformLeft.localPosition : _spawnChatTransformRight.localPosition;

        currentChat.Init(GetRandomMessage(), !isCharacterLeftSide);

        DOTween.Sequence()
            .Join(currentChat.transform.DOLocalMoveY(256, 5f).SetEase(Ease.OutSine))
            .Join(currentChat.Cg.DOFade(0f, 2f).SetDelay(4f))
            .OnComplete(() =>
            {
                PoolManager.Instance[ResourceType.Chat].Release(currentChat.gameObject);
            });

        if (IndexTuto < AlexisChatTuto.Count)
        {
            if (_talkCor != null) StopCoroutine(_talkCor);
            _talkCor = StartCoroutine(DOTalk());
        }
    }

    string GetRandomMessage()
    {
        string response;

        if (IndexTuto < _alexisChatTuto.Count)
        {
            response = _alexisChatTuto[IndexTuto].GetLocalizedString();

            IndexTuto++;
        }
        else
        {
            response = _alexisChat[Random.Range(0, _alexisChat.Count)].GetLocalizedString();
        }

        return response;
    }

    private void OnEnable()
    {
        if (IndexTuto < AlexisChatTuto.Count) _talkCor = StartCoroutine(DOTalk());
    }

    private void OnDisable()
    {
        if (_talkCor != null) StopCoroutine(_talkCor);
    }

    public IEnumerator DOTalk()
    {
        while (IndexTuto < AlexisChatTuto.Count)
        {
            yield return new WaitForSeconds(2f);

            if (IndexTuto < AlexisChatTuto.Count) SendChat();
        }
    }
}
