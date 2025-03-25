using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatLayout : MonoBehaviour
{
    [SerializeField] CanvasGroup _cg;
    [SerializeField] TMP_Text _text;
    [SerializeField] Image _bg;

    public CanvasGroup Cg { get => _cg; set => _cg = value; }

    public void Init(string text, bool isLeftSide)
    {
        transform.localScale = Vector3.one;

        _cg.alpha = 1;

        _text.text = text;

        _bg.transform.localScale = isLeftSide ? new Vector3(-1,1,1) : new Vector3(1,1,1);
        _text.transform.localScale = isLeftSide ? new Vector3(-1,1,1) : new Vector3(1,1,1);
    }
}
