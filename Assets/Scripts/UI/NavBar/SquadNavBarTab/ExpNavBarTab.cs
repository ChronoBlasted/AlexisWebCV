using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExpType { NONE, PRO, JAMS, SCHOOL }

public class ExpNavBarTab : NavBarTab
{
    [SerializeField] GameObject _tab;
    [SerializeField] ExpType _type;

    public override void HandleOnPress()
    {
        base.HandleOnPress();

        _tab.gameObject.SetActive(true);
    }

    public override void HandleOnReset()
    {
        base.HandleOnReset();

        _tab.gameObject.SetActive(false);
    }
}
