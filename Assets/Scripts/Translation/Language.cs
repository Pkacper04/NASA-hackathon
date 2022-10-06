using System;
using System.Diagnostics;
using NaughtyAttributes;
public class Language : LanguageDatabase
{
    public static Language Instance { get; private set; }

    [ReadOnly]
    public Languages language;

    public event Action translationChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }


    public string GetTranslation(TranslateKeys key)
    {
        if (language == Languages.English)
            return EnglishTranslation(key);
        else if (language == Languages.Polish)
            return PolishTranslation(key);
        else
            return null;
    }

    public string GetTranslation(string key)
    {
        TranslateKeys enumKey = ConvertStringToKey(key);

        if (language == Languages.English)
            return EnglishTranslation(enumKey);
        else if (language == Languages.Polish)
            return PolishTranslation(enumKey);
        else
            return null;
    }

    public void ChangeLanguage(Languages newLanguage)
    {
        language = newLanguage;
        InformAllSubscribers();
    }

    [Button("ChangeLanguage")]
    public void ChangeLanguage()
    {
        if (language == Languages.Polish)
            language = Languages.English;
        else
            language = Languages.Polish;
    }

    private void InformAllSubscribers()
    {
        translationChanged?.Invoke();
    }


    private TranslateKeys ConvertStringToKey(string textKey)
    {
        TranslateKeys myEnum = (TranslateKeys)Enum.Parse(typeof(TranslateKeys), textKey);
        return myEnum;
    }

    public enum Languages
    {
        Polish,
        English
    }

}


