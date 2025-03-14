using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventPanel : Panel
{
    [SerializeField] List<EventLayout> _eventLayouts = new List<EventLayout>();

    public override void Init()
    {
        base.Init();

        foreach (var eventLayout in _eventLayouts)
        {
            eventLayout.Init();
        }

        SortEvent();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.Instance.MenuView.TopBar.HideTopBar();
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
