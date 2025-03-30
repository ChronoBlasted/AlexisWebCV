using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContributorLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _name, _role;
    [SerializeField] Image _ico, _bg, _leftMask;

    CollaboratorData _data;
    public void Init(CollaboratorData newContributor)
    {
        _data = newContributor;

        switch (_data.Role)
        {
            case Role.Dev:
                _ico.sprite = ResourceObjectHolder.Instance.GetResourceByType(ResourceType.Dev).Sprite;
                break;
            case Role.Artist:
                _ico.sprite = ResourceObjectHolder.Instance.GetResourceByType(ResourceType.Artist).Sprite;
                break;
            case Role.Market:
                _ico.sprite = ResourceObjectHolder.Instance.GetResourceByType(ResourceType.Market).Sprite;
                break;
            default:
                break;
        }

        _bg.color = ColorManager.Instance.GetColorByRole(_data.Role);
        _leftMask.color = ColorManager.Instance.GetSecondColorByRole(_data.Role);
        _name.text = _data.FirstName + " " + _data.LastName;
        _role.text = LocalizationManager.Instance.GetStringByRole(_data.Role);
    }

    public void HandleOnClick()
    {
        Application.OpenURL("https://www.linkedin.com/search/results/all/?keywords=" + _data.FirstName + "%20" + _data.LastName);
    }
}
