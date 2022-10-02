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

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Menu.enabled =! Menu.enabled;
            if (Menu.enabled)
            {
                BuildingController.Instance.HideBuildingInfo();
                BuildingPanelController.Instance.DeInit();
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                Settings.SetActive(false);
                MainMenu.SetActive(true);
            }

 
        }

    }

    public void disableMenu()
    {
        Menu.enabled = false;
        Time.timeScale = 1;
        Settings.SetActive(false);
        MainMenu.SetActive(true);
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
