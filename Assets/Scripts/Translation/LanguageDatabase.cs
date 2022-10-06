using UnityEngine;

public class LanguageDatabase : MonoBehaviour
{

    #region PolishTranslation
    protected static string PolishTranslation(TranslateKeys key)
    {
        switch (key)
        {
            case TranslateKeys.StartGame:
                return "Rozpocznij Gre";
            case TranslateKeys.Settings:
                return "Ustawienia";
            case TranslateKeys.Credits:
                return "Tworcy";
            default:
                return "klucz nie istnieje";
        }
    }

    #endregion PolishTranslation;


    #region EnglishTranslation
    protected static string EnglishTranslation(TranslateKeys key)
    {
        switch (key)
        {
            case TranslateKeys.StartGame:
                return "Start Game";
            case TranslateKeys.Settings:
                return "Settings";
            case TranslateKeys.Credits:
                return "Credits";
            default:
                return "Key does not exist";
        }
    }
    #endregion EnglishTransletion

}


#region TranslateKeys
public enum TranslateKeys
{
    StartGame,
    Settings,
    Credits
}
#endregion TranslateKeys

