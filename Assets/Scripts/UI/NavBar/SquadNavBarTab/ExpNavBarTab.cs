using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ExpType { NONE, PRO, JAMS, SCHOOL }

public class ExpNavBarTab : NavBarTab
{
    [SerializeField] GameObject _tab, _header;
    [SerializeField] TMP_Text _title;
    [SerializeField] Color _inactiveColor;
    [SerializeField] Image _activeBar;
    [SerializeField] ExpType _type;
    [SerializeField] ChronoTweenSequence _sequence;

    public override void HandleOnPress()
    {
        base.HandleOnPress();

        _activeBar.enabled = true;

        _title.color = Color.white;

        _tab.gameObject.SetActive(true);
        _header.gameObject.SetActive(true);

        _sequence.Init();
    }

    public override void HandleOnReset()
    {
        base.HandleOnReset();

        _activeBar.enabled = false;

        _title.color = _inactiveColor;

        _tab.gameObject.SetActive(false);
        _header.gameObject.SetActive(false);
    }
}
