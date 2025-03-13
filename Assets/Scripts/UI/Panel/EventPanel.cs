using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPanel : Panel
{
    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.Instance.MenuView.TopBar.HideTopBar();
    }
}
