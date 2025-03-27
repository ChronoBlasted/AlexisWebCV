using BaseTemplate.Behaviours;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public RectTransform RectTransformPool;
    [SerializeField] Canvas _mainCanvas;

    [Header("View")]
    [SerializeField] MenuView _menuView;
    [SerializeField] LoadingView _loadingView;
    [SerializeField] ErrorView _errorView;
    [SerializeField] SettingView _settingView;
    [SerializeField] FriendView _friendView;

    [Header("Popup")]
    [SerializeField] RewardPopup _rewardPopup;
    [SerializeField] ProfilePopup _profilePopup;
    [SerializeField] ConfirmPopup _confirmPopup;
    [SerializeField] LanguagePopup _languagePopup;
    [SerializeField] QuestPopup _questPopup;

    [Header("Black Shade Ref")]
    [SerializeField] Button _blackShadeButton;
    [SerializeField] Image _blackShadeImg;

    View _currentView;

    public Canvas MainCanvas { get => _mainCanvas; }

    public MenuView MenuView { get => _menuView; }
    public LoadingView LoadingView { get => _loadingView; }
    public ErrorView ErrorView { get => _errorView; }
    public SettingView SettingView { get => _settingView; }
    public FriendView FriendView { get => _friendView; }

    public RewardPopup RewardPopup { get => _rewardPopup; }
    public ConfirmPopup ConfirmPopup { get => _confirmPopup; }
    public LanguagePopup LanguagePopup { get => _languagePopup; }
    public ProfilePopup ProfilePopup { get => _profilePopup; }
    public QuestPopup QuestPopup { get => _questPopup; }

    Tweener _blackShadeTweener;

    public void Init()
    {
        InitView();

        _currentView = _loadingView;

        ChangeView(_menuView);
    }

    public void InitView()
    {
        _menuView.Init();
        _errorView.Init();
        _settingView.Init();
        _friendView.Init();

        _rewardPopup.Init();
        _languagePopup.Init();
        _confirmPopup.Init();
        _profilePopup.Init();
        _questPopup.Init();

        HideBlackShade();
    }

    #region View

    public void ChangeView(View newPanel, bool _instant = false)
    {
        if (newPanel == _currentView) return;

        if (_currentView != null)
        {
            CloseView(_currentView);
        }

        _currentView = newPanel;

        _currentView.gameObject.SetActive(true);

        if (_instant) _currentView.OpenView(_instant);
        else _currentView.OpenView();

    }

    public void ChangeView(View newPanel)
    {
        if (newPanel == _currentView) return;

        if (_currentView != null)
        {
            CloseView(_currentView);
        }

        _currentView = newPanel;

        _currentView.gameObject.SetActive(true);
        _currentView.OpenView();
    }

    void CloseView(View newPanel)
    {
        newPanel.CloseView();
    }
    #endregion

    #region Popup

    public void AddPopup(Popup newPopup)
    {
        newPopup.OpenPopup();
    }
    #endregion

    public void ShowBlackShade(UnityAction _onClickAction)
    {
        if (_blackShadeTweener.IsActive()) _blackShadeTweener.Kill();

        _blackShadeTweener = _blackShadeImg.DOFade(.9f, .1f);

        _blackShadeImg.raycastTarget = true;

        _blackShadeButton.onClick.AddListener(_onClickAction);
    }

    public void HideBlackShade(bool _instant = true)
    {
        if (_blackShadeTweener.IsActive()) _blackShadeTweener.Kill();

        if (_instant) _blackShadeTweener = _blackShadeImg.DOFade(0f, 0);
        else _blackShadeTweener = _blackShadeImg.DOFade(0f, .1f);

        _blackShadeImg.raycastTarget = false;

        _blackShadeButton.onClick.RemoveAllListeners();
    }

    public static void ScrollToItemY(ScrollRect scrollRect, Transform content, int indexToScroll)
    {
        float step = 1f / (content.childCount - 1);

        scrollRect.normalizedPosition = new Vector2(scrollRect.normalizedPosition.x, step * indexToScroll);
    }

    public static void ResetScroll(ScrollRect scrollRect)
    {
        scrollRect.normalizedPosition = new Vector2(scrollRect.normalizedPosition.x, 1);
    }

    public static string GetFormattedInt(float amount)
    {
        return amount.ToString("#,0");
    }
}
