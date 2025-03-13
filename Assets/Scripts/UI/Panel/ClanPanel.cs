using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClanPanel : Panel
{
    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.Instance.MenuView.TopBar.HideTopBar();
    }
}
