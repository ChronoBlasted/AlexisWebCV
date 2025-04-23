
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RecyclableScroll<TData, TView> : MonoBehaviour where TView : MonoBehaviour, IRecyclable<TData>
{
    [SerializeField] ScrollRect _scrollRect;
    [SerializeField] RectTransform _content;
    [SerializeField] TView _prefab;
    [SerializeField] int _buffer = 2;

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
        _totalHeight = _data.Count * _fixedElementHeight;

        UpdateContentSize();
        UpdateVisibleItems();
    }

    void UpdateContentSize()
    {
        _content.sizeDelta = new Vector2(_content.sizeDelta.x, _totalHeight);
    }

    public void UpdateVisibleItems()
    {
        float scrollY = _content.anchoredPosition.y;
        float viewHeight = _scrollRect.viewport.rect.height;

        // Calculer l'index du premier et du dernier élément visible en tenant compte de la hauteur fixe
        int startIndex = Mathf.FloorToInt(scrollY / _fixedElementHeight);
        int endIndex = Mathf.FloorToInt((scrollY + viewHeight) / _fixedElementHeight);

        // Limiter les indices à la taille de la liste
        startIndex = Mathf.Max(0, startIndex);
        endIndex = Mathf.Min(_data.Count - 1, endIndex);

        // Ajouter un tampon autour des éléments visibles pour les pré-instancier (buffer)
        HashSet<int> newIndices = new();
        for (int i = startIndex; i <= endIndex + _buffer && i < _data.Count; i++)
            newIndices.Add(i);

        // Désactiver et remettre dans le pool les éléments qui ne sont plus visibles
        foreach (var kvp in _activeViews.ToList())
        {
            if (!newIndices.Contains(kvp.Key))  // Si l'élément n'est plus visible
            {
                kvp.Value.view.gameObject.SetActive(false);  // Désactive l'élément
                kvp.Value.index = -1;  // Réinitialise son index
                _pooled.Add(kvp.Value);  // Ajoute l'élément au pool
                _activeViews.Remove(kvp.Key);  // Retire l'élément des éléments actifs
            }
        }

        // Instancier et activer les éléments nécessaires
        foreach (int i in newIndices)
        {
            if (_activeViews.ContainsKey(i))  // Si l'élément est déjà actif, on ne le réinstancie pas
                continue;

            PoolItem item;

            // Récupérer un élément du pool si disponible
            if (_pooled.Count > 0)
            {
                item = _pooled[_pooled.Count - 1];  // Prend le dernier élément du pool
                _pooled.RemoveAt(_pooled.Count - 1);  // Le retire du pool
            }
            else
            {
                // Si le pool est vide, instancier un nouvel élément
                var view = Instantiate(_prefab, _content);
                item = new PoolItem { view = view };
            }

            // Configurer l'élément et l'ajouter aux éléments actifs
            item.view.SetData(_data[i]);
            item.view.gameObject.SetActive(true);
            item.index = i;

            // Positionner l'élément à la bonne place selon son index
            var rt = item.view.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(0, -i * _fixedElementHeight);

            _activeViews[i] = item;  // Ajoute l'élément aux éléments actifs
        }
    }
}