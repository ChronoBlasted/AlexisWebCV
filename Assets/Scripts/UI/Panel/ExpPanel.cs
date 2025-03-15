using System.Collections.Generic;
using UnityEngine;

public class ExpPanel : Panel
{
    [SerializeField] NavBar _navBar;
    [SerializeField] Transform _scrollProGames, _scrollJamGames, _scrollSchoolGames;
    [SerializeField] ExpLayout _expLayoutPrefab;

    [SerializeField] List<ExpLayout> _expLayoutInDecks;

    [SerializeField] List<ExpData> _proGamesData = new List<ExpData>();
    [SerializeField] List<ExpData> _jamGamesData = new List<ExpData>();
    [SerializeField] List<ExpData> _schoolGamesData = new List<ExpData>();


    public override void Init()
    {
        base.Init();

        InitLayouts();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.Instance.MenuView.TopBar.ShowTopBar();

        _navBar.Init();

    }

    void InitLayouts()
    {
        foreach (var layout in _expLayoutInDecks)
        {
            layout.Init();
        }

        InstantiateLayouts(_proGamesData, _scrollProGames);
        InstantiateLayouts(_jamGamesData, _scrollJamGames);
        InstantiateLayouts(_schoolGamesData, _scrollSchoolGames);
    }

    void InstantiateLayouts(List<ExpData> datas, Transform spawnTransform)
    {
        foreach (var data in datas)
        {
            var currentExpLayout = Instantiate(_expLayoutPrefab, spawnTransform);

            currentExpLayout.Init(data);
        }
    }
}
