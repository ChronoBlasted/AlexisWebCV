using BaseTemplate.Behaviours;
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;


public class GameManager : MonoSingleton<GameManager>
{
    private void Start()
    {
        StartCoroutine(Preload());
    }

    void Init()
    {
        TimeManager.Instance.Init();

        PoolManager.Instance.Init();

        UIManager.Instance.Init();
    }

    IEnumerator Preload()
    {
        var operation = LocalizationSettings.InitializationOperation;

        do
        {
            yield return null;
        }
        while (!operation.IsDone);

        if (operation.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Failed)
        {
            ReloadScene();
        }
        else
        {
            Init();
        }
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