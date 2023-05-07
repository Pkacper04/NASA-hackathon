using Histhack.Core.SaveLoadSystem;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField, Scene]
    private string newGameScene;

    [SerializeField, Scene]
    private string continueGameScene;

    [SerializeField]
    private SettingsController settingsController;

    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private GameObject newGameConfirm;

    private void Start()
    {
        settingsController.LoadLoudness();

        if(SaveSystem.CheckIfSaveExists())
        {
            continueButton.gameObject.SetActive(true);
        }
    }

    //Method creating a new game
    public void NewGame()
    {
        if (SaveSystem.CheckIfSaveExists())
        {
            newGameConfirm.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else
        {
            ForceNewGame();
        }
    }

    public void ForceNewGame()
    {
        SaveSystem.DeleteAllSaves();
        StartCoroutine(WaitForFade(newGameScene));
    }

    private IEnumerator WaitForFade(string scene)
    {
        ScreenTransition.Instance.startFadingIn();

        yield return new WaitUntil(() => !ScreenTransition.Instance.InTransition);
        SceneManager.LoadScene(scene);
    }

    //Methon continuing a game from a save file
    public void ContinueGame()
    {
        StartCoroutine(WaitForFade(continueGameScene));
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
