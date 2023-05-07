using System;
using System.Reflection;
using UnityEngine;

namespace Events
{
    public class PlayerEvents : Singleton<PlayerEvents>
    {

        private void Awake()
        {
            if (IsInstance() == null)
                DontDestroyOnLoad(this);
            else if (IsInstance() != this)
                Destroy(this.gameObject);

            //this line is only if user needs to make object that is singleton not to destroyed in load
        }

        public Action OnPlayerMouseDown;

        public void CallOnPlayerMouseDown()
        {
            if (OnPlayerMouseDown != null)
                OnPlayerMouseDown.Invoke();
        }

        public Action OnSaveGame;

        public void CallOnSaveGame()
        {
            if (OnSaveGame != null)
                OnSaveGame.Invoke();
        }

        public Action OnLoadGame;

        public void CallOnLoadGame()
        {
            if (OnLoadGame != null)
                OnLoadGame.Invoke();
        }

        public Action<TutorialStepsData> OnTutorialStepFinish;
        public void CallOnTutorialStepFinish(TutorialStepsData tutorialStep)
        {
            if (OnTutorialStepFinish != null)
                OnTutorialStepFinish.Invoke(tutorialStep);
        }

        public Action<TutorialStepsData> OnTutorialStepStarted;
        public void CallOnTutorialStepStarted(TutorialStepsData tutorialStep)
        {
            if (OnTutorialStepStarted != null)
                OnTutorialStepStarted.Invoke(tutorialStep);
        }

    }
}
