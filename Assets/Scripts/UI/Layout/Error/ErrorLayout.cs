using DG.Tweening;
using TMPro;
using UnityEngine;


public class ErrorLayout : MonoBehaviour
{
    [SerializeField] TMP_Text errorText;

    [SerializeField] Color _errorColor;

    Sequence _tween;

    public void Init(string errorMsg, Transform endTransform, bool isError = true)
    {
        RectTransform rectTransform = (RectTransform)gameObject.transform;
        rectTransform.sizeDelta = new Vector2(0, 256);

        errorText.alpha = 1;
        errorText.color = isError ? _errorColor : Color.white;
        transform.localScale = Vector3.one;
        errorText.text = errorMsg;

        if (_tween.IsActive()) _tween.Kill(true);

        _tween = DOTween.Sequence()
            .Join(transform.DOPunchScale(new Vector3(.3f, .3f, .3f), .5f, 1))
            .Join(transform.DOMoveY(endTransform.position.y, 3f).SetEase(Ease.InBack).SetDelay(.5f))
            .Join(errorText.DOFade(0, .5f).SetDelay(2.5f).OnComplete(() =>
            {
                PoolManager.Instance[ResourceType.ErrorMsg].Release(gameObject);
            }));
    }
}
