using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class MenuView : View
{
    [SerializeField] NavBar navBar;

    [field: SerializeField] public ShopPanel ShopPanel { get; protected set; }
    [field: SerializeField] public ExpPanel ExpPanel { get; protected set; }
    [field: SerializeField] public MainPanel MainPanel { get; protected set; }
    [field: SerializeField] public TimelinePanel TimelinePanel { get; protected set; }
    [field: SerializeField] public EventPanel EventPanel { get; protected set; }
    public NavBar NavBar { get => navBar; }

    public override void Init()
    {
        base.Init();

        ShopPanel.Init();
        ExpPanel.Init();
        MainPanel.Init();
        TimelinePanel.Init();
        EventPanel.Init();
    }

    public override void OpenView(bool _instant = false, float timeToOpen = 0.2F)
    {
        base.OpenView();

        navBar.Init();
    }

    public override void CloseView()
    {
        base.CloseView();
    }

    public void DoEntrance(float delay)
    {
        MainPanel.transform.localScale = new Vector3(.2f, .2f, .2f);

        MainPanel.transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutSine).SetDelay(delay);
    }


}
