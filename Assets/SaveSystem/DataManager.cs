using Events;
using Histhack.Core;
using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Histhack.Core.SaveLoadSystem
{
    public class DataManager : Singleton<DataManager>
    {

        [SerializeField, Scene]
        private string mainGameScene;

        public Encrypter Encrypter { get; private set; }

        #region Initialization

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
            {
                DontDestroyOnLoad(this);
            }

            Encrypter = new Encrypter();
            Encrypter.Initialize();
        }

        private void OnEnable()
        {
            SceneManager.activeSceneChanged += SceneChanged;
        }

        private void OnDisable()
        {
            SceneManager.activeSceneChanged -= SceneChanged;
        }

        #endregion Initialization


        #region Saving & Loading

        public void SaveGame()
        {
            PlayerEvents.Instance.CallOnSaveGame();
        }
        
        public void LoadGame()
        {
            PlayerEvents.Instance.CallOnLoadGame();
        }

        #endregion Saving & Loading

        private void SceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.name == mainGameScene)
            {
                LoadGame();
            }
        }

    }

}
