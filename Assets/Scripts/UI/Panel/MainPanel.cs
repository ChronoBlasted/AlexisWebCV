using UnityEngine;

public class MainPanel : Panel
{
    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.Instance.MenuView.TopBar.ShowTopBar();
    }
}
