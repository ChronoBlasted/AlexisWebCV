using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ChronoTweenHelper : MonoBehaviour
{
    [SerializeField] UnityEvent _tweenAction;
    [SerializeField] float _amount, _duration, _startDelay;
    [SerializeField] Ease _ease;
    [SerializeField] LoopType _loopType;
    [SerializeField] int _loopAmount;

    Vector3 _startPos;
    Vector3 _startLocalPos;
    public void Start()
    {
        _startPos = transform.position;
        _startLocalPos = transform.localPosition;

        _tweenAction?.Invoke();
    }

    public void DoLocalUpAndDown()
    {
        transform.DOLocalMoveY(_startLocalPos.y + _amount, _duration).SetDelay(_startDelay).SetEase(_ease).SetLoops(_loopAmount, _loopType);
    }
}
