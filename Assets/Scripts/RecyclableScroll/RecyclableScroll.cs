using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RecyclableScroll<TData, TView> : MonoBehaviour where TView : MonoBehaviour, IRecyclable<TData>
{
    [SerializeField] protected ScrollRect _scrollRect;
    [SerializeField] RectTransform _content;
    [SerializeField] TView _prefab;
    [SerializeField] int _buffer = 2;

    [SerializeField] float _paddingTop = 0f;
    [SerializeField] float _paddingBottom = 0f;
    [SerializeField] float _spacing = 0f;

    List<TData> _data = new();
    float _fixedElementHeight;
    float _totalHeight;

    class PoolItem
    {
        public TView view;
        public int index = -1;
    }

    List<PoolItem> _pooled = new();
    Dictionary<int, PoolItem> _activeViews = new();

    public void SetData(List<TData> data)
    {
        _fixedElementHeight = _prefab.GetComponent<RectTransform>().sizeDelta.y;

        _data = data;
        _totalHeight = _paddingTop + _paddingBottom + (_data.Count * _fixedElementHeight) + ((_data.Count - 1) * _spacing);

        UpdateContentSize();
        UpdateVisibleItems();
    }

    void UpdateContentSize()
    {
        _content.sizeDelta = new Vector2(_content.sizeDelta.x, _totalHeight);
    }

    public void UpdateVisibleItems()
    {
        float scrollY = _content.anchoredPosition.y - _paddingTop;
        float viewHeight = _scrollRect.viewport.rect.height;

        int startIndex = Mathf.FloorToInt(scrollY / (_fixedElementHeight + _spacing));
        int endIndex = Mathf.FloorToInt((scrollY + viewHeight) / (_fixedElementHeight + _spacing));

        startIndex = Mathf.Max(0, startIndex);
        endIndex = Mathf.Min(_data.Count - 1, endIndex);

        HashSet<int> newIndices = new();
        for (int i = startIndex; i <= endIndex + _buffer && i < _data.Count; i++)
            newIndices.Add(i);

        foreach (var kvp in _activeViews.ToList())
        {
            if (!newIndices.Contains(kvp.Key))
            {
                kvp.Value.view.gameObject.SetActive(false);
                kvp.Value.index = -1;
                _pooled.Add(kvp.Value);
                _activeViews.Remove(kvp.Key);
            }
        }

        foreach (int i in newIndices)
        {
            if (_activeViews.ContainsKey(i))
                continue;

            PoolItem item;

            if (_pooled.Count > 0)
            {
                item = _pooled[_pooled.Count - 1];
                _pooled.RemoveAt(_pooled.Count - 1);
            }
            else
            {
                var view = Instantiate(_prefab, _content);
                item = new PoolItem { view = view };
            }

            item.view.SetData(_data[i]);
            item.view.gameObject.SetActive(true);
            item.index = i;

            float yPos = -_paddingTop - (i * (_fixedElementHeight + _spacing));
            var rt = item.view.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(0, yPos);

            _activeViews[i] = item;
        }
    }
}
