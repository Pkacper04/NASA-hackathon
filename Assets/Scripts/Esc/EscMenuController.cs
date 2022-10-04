using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class EscMenuController : MonoBehaviour
{
    [SerializeField] Canvas Menu = new Canvas();
    [SerializeField, Scene]
    private string mainMenuScene;
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject MainMenu;

    private static bool gamePaused = false;

    public static bool GamePaused { get => gamePaused; set => gamePaused = value; }

    private bool cursorState = true;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Menu.enabled)
                DisableMenu();
            else
                EnableMenu();
        }
    }

    public void DisableMenu()
    {
        Menu.enabled = false;
        Cursor.visible = cursorState;
        Time.timeScale = 1;
        Settings.SetActive(false);
        MainMenu.SetActive(true);
        gamePaused = false;
    }

    private void EnableMenu()
    {
        Menu.enabled = true;
        cursorState = Cursor.visible;
        Cursor.visible = true;
        Time.timeScale = 0;
        ClosePopups.Instance.CloseAllPanels();
        gamePaused = true;
    }
    public void SaveGame()
    {

    }
    public void ExitToMainMenu()
    {
        //Tutaj wstawiæ autozapis

        SceneManager.LoadScene(mainMenuScene);
    }

}
