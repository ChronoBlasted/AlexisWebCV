using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreprisePanel : Panel
{
    [SerializeField] GameObject _headerLayout, _findLayout, _chatLayout, _sendMessageLayout;

    bool isInClan;

    public override void Init()
    {
        base.Init();

        UpdateIsInClan();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();

        UIManager.Instance.MenuView.TopBar.HideTopBar();
    }

    public void OpenFindEntreprise()
    {

    }

    public void LeaveEntreprise()
    {

    }

    public void SendMessageInChat(string message)
    {

    }

    void UpdateIsInClan()
    {
        _headerLayout.SetActive(isInClan);
        _chatLayout.SetActive(isInClan);
        _sendMessageLayout.SetActive(isInClan);

        _findLayout.SetActive(!isInClan);
    }
}

