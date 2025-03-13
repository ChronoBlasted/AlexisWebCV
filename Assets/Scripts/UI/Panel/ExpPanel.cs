using UnityEngine;

public class ExpPanel : Panel
{
    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.Instance.MenuView.TopBar.ShowTopBar();

    }
}
