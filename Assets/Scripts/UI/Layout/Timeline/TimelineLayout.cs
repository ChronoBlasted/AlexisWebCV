using System;
using System.Globalization;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class TimelineLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _title, _date, _desc;
    [SerializeField] Transform _attributeContainer, _contributorContainer;
    [SerializeField] Animator _animator;
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

        if (DateTime.TryParse(_data.EndTime, out DateTime date))
        {
            _date.text = date.ToString("MMMM yyyy", CultureInfo.InvariantCulture);
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


        if (_data.Contributors.Count > 0)
        {
            foreach (var contributor in _data.Contributors)
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

    private void OnEnable()
    {
        _animator.Play(_data.Animation.name);
    }
}
