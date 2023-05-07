using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class SettingsController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    [SerializeField]
    private TMP_Dropdown languageDropdown;

    [SerializeField]
    private Slider volumeSlider;
    Resolution[] resolutions;


    private string savingKey = "GameVolume";

    float lastVolume;
    private void Start()
    {
        audioMixer.GetFloat("volume", out lastVolume);
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) currentResolutionIndex = i;

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        lastVolume = volume;
    }
    public void SetFulscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, false);
    }

    public void OnLanguageChange()
    {
       
        if (languageDropdown.value == 1)
            Language.Instance.ChangeLanguage(Language.Languages.English);
        else
            Language.Instance.ChangeLanguage(Language.Languages.Polish);
    }


    public void SaveLoudness()
    {
        PlayerPrefs.SetFloat(savingKey, lastVolume);
    }

    public void LoadLoudness()
    {
        if (!PlayerPrefs.HasKey(savingKey))
            return;

        lastVolume = PlayerPrefs.GetFloat(savingKey);
        audioMixer.SetFloat("volume", lastVolume);
        volumeSlider.value = lastVolume;
    }
}
