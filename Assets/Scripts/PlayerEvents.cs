using System;
using System.Reflection;

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

    }
}
