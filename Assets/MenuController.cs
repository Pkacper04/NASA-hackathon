using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Method creating a new game
    public void NewGame()
    {
        SceneManager.LoadScene(4);
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
