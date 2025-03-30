using System;
using System.Globalization;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class TimelineLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _title, _date, _desc;
    [SerializeField] Transform _attributeContainer, _contributorContainer;
    [SerializeField] ExpLayout _expLayout;
    [SerializeField] TMP_Text _contributorTitle;
    [SerializeField] AttributeLayout _attributeLayoutPrefab;
    [SerializeField] ContributorLayout _contributorLayoutPrefab;

    ExpData _data;

    public ExpData Data { get => _data; }

    public void Init(ExpData exp)
    {
        _data = exp;

        _title.text = _data.Name.GetLocalizedString();
        _desc.text = _data.Desc.GetLocalizedString();

        _expLayout.SetData(_data);

        _expLayout.SetColor();

        if (DateTime.TryParse(_data.EndTime, out DateTime date))
        {
            _date.text = date.ToString("MMMM yyyy", CultureInfo.CurrentCulture);
        }

        bool hasAnyFlag = false;

        foreach (Attribute attr in Enum.GetValues(typeof(Attribute)))
        {
            if (attr != Attribute.None && (_data.Attribute & attr) == attr)
            {
                var currentAttribute = Instantiate(_attributeLayoutPrefab, _attributeContainer);

                currentAttribute.Init(attr);

                hasAnyFlag = true;
            }
        }

        if (!hasAnyFlag)
        {
            _attributeContainer.gameObject.SetActive(false);
        }


        if (_data.Collaborators.Count > 0)
        {
            foreach (var contributor in _data.Collaborators)
            {
                var currentContributor = Instantiate(_contributorLayoutPrefab, _contributorContainer);
                currentContributor.Init(contributor);
            }
        }
        else
        {
            _contributorTitle.gameObject.SetActive(false);
            _contributorContainer.gameObject.SetActive(false);
        }

    }

    public void HandleOnClick()
    {
        Application.OpenURL(_data.ItchURL);
    }
}
