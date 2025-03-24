using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _questName, _questAmount;
    [SerializeField] Slider _questSlider;
    [SerializeField] Image _questIco, _bg, _rewardIco, _checkIco;

    [SerializeField] Color _activeColor, _finishedColor;
    QuestData data;

    public void Init(QuestData questData)
    {
        data = questData;

        _questName.text = data.QuestName.GetLocalizedString();

        _checkIco.enabled = data.Amount == data.MaxAmount;

        _bg.color = data.Amount == data.MaxAmount ? _finishedColor : _activeColor;


        if (data.Amount == -1)
        {

        }
        else
        {
            _questAmount.text = data.Amount + "/" + data.MaxAmount;

            _questSlider.maxValue = data.MaxAmount;
            _questSlider.value = data.Amount;
        }

        _questIco.sprite = data.QuestIco;
        _rewardIco.sprite = data.RewardSprite;
    }
}
