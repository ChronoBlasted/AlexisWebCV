using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestLayout : MonoBehaviour
{
    [SerializeField] TMP_Text _questName, _questAmount;
    [SerializeField] Slider _questSlider;
    [SerializeField] Image _rewardIco;

    QuestData data;

    public void Init(QuestData questData)
    {
        data = questData;

        _questName.text = data.QuestName.GetLocalizedString();


        if (data.Amount == -1)
        {

        }
        else
        {
            _questAmount.text = data.Amount + "/" + data.MaxAmount;

            _questSlider.maxValue = data.MaxAmount;
            _questSlider.value = data.Amount;
        }

        _rewardIco.sprite = data.RewardSprite;
    }
}
