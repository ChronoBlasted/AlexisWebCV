using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EventPanel : Panel
{
    [SerializeField] ScrollRect _scrollRect;
    [SerializeField] List<EventLayout> _eventLayouts = new List<EventLayout>();
    [SerializeField] List<EventLayout> _pastEvents = new List<EventLayout>();

    public override void Init()
    {
        base.Init();


        foreach (var eventLayout in _eventLayouts)
        {
            eventLayout.Init();
        }

        foreach (var eventLayout in _pastEvents)
        {
            eventLayout.Init();
        }

        SortEvent();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.ResetScroll(_scrollRect);
    }

    void SortEvent()
    {
        _eventLayouts = _eventLayouts.OrderBy(e => e.DaysBeforeEvent).ToList();

        foreach (var eventLayout in _eventLayouts)
        {
            eventLayout.transform.SetAsLastSibling();
        }
    }
}
