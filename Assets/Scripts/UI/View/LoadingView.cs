using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingView : View
{
    [SerializeField] GameObject _content;
    [SerializeField] Image _check, _loading;

    public override void Init()
    {
        base.Init();
    }

    public override void CloseView()
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;

        _loading.DOFade(0, .2f);
        _check.DOFade(1, .2f);

        DOTween.Sequence()
            .Join(_content.transform.DOShakePosition(2f, new Vector3(20, 0, 0), 15, 90, false, true).SetEase(Ease.InSine))
            .Join(transform.GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 2), 1f).SetDelay(.5f).SetEase(Ease.InSine))
            .Join(transform.GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 1), 1f).SetEase(Ease.InSine))
            .Join(_check.DOFade(0, .2f).SetDelay(.25f))
            .SetDelay(.5f)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            })
            .SetUpdate(UpdateType.Normal, true);

        UIManager.Instance.MenuView.DoEntrance(.9f);
    }

}
