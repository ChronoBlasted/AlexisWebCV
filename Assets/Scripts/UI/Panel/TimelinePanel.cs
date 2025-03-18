using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelinePanel : Panel
{
    [SerializeField] List<ExpData> _allExp;

    public override void Init()
    {
        base.Init();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.Instance.MenuView.TopBar.HideTopBar();
    }
}

