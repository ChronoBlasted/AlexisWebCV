using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RecyclableScrollView : MonoBehaviour
{
    public RectTransform content;
    public ScrollRect scrollRect;
    public GameObject itemPrefab;

    public int totalItemCount;
    public float itemHeight;
    public int bufferCount = 2;

    private List<RectTransform> items = new List<RectTransform>();
    private int topIndex = 0;
    private int visibleCount;

    void Start()
    {
        visibleCount = Mathf.CeilToInt(scrollRect.viewport.rect.height / itemHeight) + bufferCount;
        content.sizeDelta = new Vector2(content.sizeDelta.x, totalItemCount * itemHeight);

        for (int i = 0; i < visibleCount; i++)
        {
            GameObject item = Instantiate(itemPrefab, content);
            RectTransform rt = item.GetComponent<RectTransform>();
            items.Add(rt);
        }

        UpdateItems();
        scrollRect.onValueChanged.AddListener(OnScroll);
    }

    void OnScroll(Vector2 pos)
    {
        UpdateItems();
    }

    void UpdateItems()
    {
        float scrollY = content.anchoredPosition.y;
        int newTopIndex = Mathf.FloorToInt(scrollY / itemHeight);

        if (newTopIndex == topIndex) return;

        int delta = newTopIndex - topIndex;
        topIndex = newTopIndex;

        for (int i = 0; i < items.Count; i++)
        {
            int index = topIndex + i;
            if (index >= totalItemCount)
            {
                items[i].gameObject.SetActive(false);
                continue;
            }

            items[i].gameObject.SetActive(true);
            items[i].anchoredPosition = new Vector2(0, -index * itemHeight);
            items[i].GetComponentInChildren<Text>().text = $"Item {index}";
        }
    }
}
