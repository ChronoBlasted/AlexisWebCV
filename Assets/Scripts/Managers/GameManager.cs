using BaseTemplate.Behaviours;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoSingleton<GameManager>
{
    private void Awake()
    {
        TimeManager.Instance.Init();

        CurrencyManager.Instance.Init();

        PoolManager.Instance.Init();

        UIManager.Instance.Init();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            ReloadScene();
        }
    }
    public void ReloadScene()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApp() => Application.Quit();
}