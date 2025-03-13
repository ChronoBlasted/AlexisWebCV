using UnityEngine;

public class MenuView : View
{
    [SerializeField] NavBar navBar;

    [field: SerializeField] public Topbar TopBar { get; protected set; }
    [field: SerializeField] public ShopPanel ShopPanel { get; protected set; }
    [field: SerializeField] public ExpPanel ExpPanel { get; protected set; }
    [field: SerializeField] public MainPanel MainPanel { get; protected set; }
    [field: SerializeField] public ClanPanel ClanPanel { get; protected set; }
    [field: SerializeField] public EventPanel EventPanel { get; protected set; }
    public NavBar NavBar { get => navBar; }

    public override void Init()
    {
        base.Init();

        ShopPanel.Init();
        ExpPanel.Init();
        MainPanel.Init();
        ClanPanel.Init();
        EventPanel.Init();

        TopBar.Init();
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
}
