using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [SerializeField, Scene]
    private string newGameScene;


    //Method creating a new game
    public void NewGame()
    {
        StartCoroutine(WaitForFade());
    }

    private IEnumerator WaitForFade()
    {
        ScreenTransition.Instance.startFadingIn();

        yield return new WaitUntil(() => !ScreenTransition.Instance.InTransition);
        SceneManager.LoadScene(newGameScene);
    }

    //Methon continuing a game from a save file
    public void ContinueGame()
    {

    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
