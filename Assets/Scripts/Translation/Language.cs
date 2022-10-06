using System;
using NaughtyAttributes;
public class Language : LanguageDatabase
{
    public static Language Instance { get; private set; }

    [OnValueChanged(nameof(InformAllSubscribers))]
    public Languages language;

    public static event Action translationChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }


    public static string GetTranslation(TranslateKeys key)
    {
        if (Language.Instance.language == Languages.English)
            return EnglishTranslation(key);
        else if (Language.Instance.language == Languages.Polish)
            return PolishTranslation(key);
        else
            return null;
    }

    public static string GetTranslation(string key)
    {
        TranslateKeys enumKey = ConvertStringToKey(key);

        if (Language.Instance.language == Languages.English)
            return EnglishTranslation(enumKey);
        else if (Language.Instance.language == Languages.Polish)
            return PolishTranslation(enumKey);
        else
            return null;
    }

    private static void InformAllSubscribers()
    {
        translationChanged?.Invoke();
    }


    private static TranslateKeys ConvertStringToKey(string textKey)
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


