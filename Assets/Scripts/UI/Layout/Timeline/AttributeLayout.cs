using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class AttributeLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _name;
    [SerializeField] Image _bg;

    public void Init(Attribute newAttributeName)
    {
        _name.text = LocalizationManager.Instance.GetStringByAttribute(newAttributeName);
        _bg.color = ColorManager.Instance.GetColorByAttribute(newAttributeName);
    }
}
