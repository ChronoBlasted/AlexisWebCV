using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FriendLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _name, _amountCollaboration;
    [SerializeField] Image _ico, _bg;

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
        _name.text = _data.Name;

        _amountCollaboration.text = "0";
    }

    public void HandleOnClick()
    {
        Application.OpenURL(_data.LinkedinURL);
    }
}
