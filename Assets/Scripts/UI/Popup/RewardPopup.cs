using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardPopup : Popup
{
    Queue<RewardPopupData> _rewardQueue = new Queue<RewardPopupData>(10);

    Coroutine _openRewardCor;

    [Header("Ref")]
    [SerializeField] Button _continueBtn;
    [SerializeField] TMP_Text _titleTxt, _tapToContinueTxt;
    [SerializeField] Image _ico;


    public override void Init()
    {
        base.Init();
    }
    public override void OpenPopup()
    {
        gameObject.SetActive(true);

        _canvasGroup.DOFade(1, .2f).OnComplete(() =>
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }).SetUpdate(UpdateType.Normal, true);
    }

    public override void ClosePopup()
    {
        base.ClosePopup();
    }

    public void UpdateData(StoreData reward)
    {
        _rewardQueue = new Queue<RewardPopupData>(10);

        _rewardQueue.Enqueue(new RewardPopupData(reward.Name.GetLocalizedString(), reward.Sprite));


        if (_openRewardCor != null)
        {
            StopCoroutine(_openRewardCor);
            _openRewardCor = null;
        }

        _openRewardCor = StartCoroutine(UpdateWithNextReward());
    }

    IEnumerator UpdateWithNextReward()
    {
        RewardPopupData tempReward;

        if (_rewardQueue.TryDequeue(out tempReward))
        {
            _continueBtn.interactable = false;

            _titleTxt.text = tempReward.Name;

            _ico.sprite = tempReward.Sprite;
        }
        else
        {
            _rewardQueue.Clear();

            ClosePopup();
        }

        yield return new WaitForSeconds(.2f);

        _continueBtn.interactable = true;
    }

    public void CollectReward()
    {
        if (_openRewardCor != null)
        {
            StopCoroutine(_openRewardCor);
            _openRewardCor = null;
        }

        _openRewardCor = StartCoroutine(UpdateWithNextReward());
    }
}

public struct RewardPopupData
{
    public string Name;
    public Sprite Sprite;

    public RewardPopupData(string name, Sprite sprite)
    {
        Name = name;
        Sprite = sprite;
    }
}
