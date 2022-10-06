using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;
using System;
using UnityEditor;

public class TranslateText : MonoBehaviour,ITranslation
{

    [InfoBox("Translation works with:\n" +
        "1. TMP_TEXT\n" +
        "2. TMP_DROPDOWN\n" +
        "3. TMP_INPUTFIELD\n" +
        "4. TEXT")]

    [HorizontalLine(color: EColor.Red)]

    [SerializeField]
    private bool dropdown = false;

    [HideIf(nameof(dropdown))]
    public TranslateKeys translationKey;

    [SerializeField, ShowIf(nameof(dropdown))]
    private TranslateKeys[] translateKeys;

    private TMP_Text tmpText;
    private TMP_Dropdown dropdownText;
    private TMP_InputField inputText;
    private Text text;






    private void ConfigurateDropdown()
    {
        dropdownText = GetComponent<TMP_Dropdown>();
        for(int i=0;i<translateKeys.Length;i++)
        {
            dropdownText.options[i].text = Language.Instance.GetTranslation(translateKeys[i]);
        }   
    }

    private void InsertTextInto(TMP_Text text)
    {
        text.text = Language.Instance.GetTranslation(translationKey);
    }

    private void InsertTextInto(TMP_InputField text)
    {
        text.text = Language.Instance.GetTranslation(translationKey);
    }


    private void InsertTextInto(Text text)
    {
        text.text = Language.Instance.GetTranslation(translationKey);
    }

    public void RefreshTranslation()
    {
        SetText();
    }
    public void SetText()
    {
        if (dropdown)
        {
            ConfigurateDropdown();
            return;
        }
        if (TryGetComponent<TMP_Text>(out tmpText))
            InsertTextInto(tmpText);
        else if (TryGetComponent<Text>(out text))
            InsertTextInto(text);
        else if (TryGetComponent<TMP_InputField>(out inputText))
            InsertTextInto(inputText);
    }
    public void OnEnable()
    {
        SetText();
        Language.Instance.translationChanged += RefreshTranslation;
    }

    public void OnDisable()
    {
        Language.Instance.translationChanged -= RefreshTranslation;
    }
}