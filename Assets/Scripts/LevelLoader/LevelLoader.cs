using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using NaughtyAttributes;

public class LevelLoader : MonoBehaviour, ITranslation
{

    [SerializeField, Scene]
    private string sceneToLoad;

    [SerializeField]
    private TextWriter finalText;

    [SerializeField]
    private TranslateKeys translateKey;

    [SerializeField]
    private Image loadingBar;

    [SerializeField]
    private TMP_Text curosityText;

    [SerializeField]
    private Image curiosityImage;

    private CuriositiesScriptableObject curiosity;

    private void Awake()
    {
        ScreenTransition.Instance.startFadingOut();
        curiosity = CuriositiesController.Instance.GetCuriosities();
        curiosityImage.sprite = curiosity.CuriosityImage;
        curosityText.text = Language.Instance.GetTranslation(curiosity.CuriosityDescription);
    }

    private void Start()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

        operation.allowSceneActivation = false;

        while (operation.progress < .9f)
        {
            float progress = Mathf.Clamp01(operation.progress/.9f);
            loadingBar.fillAmount = progress;
            yield return null;
        }
        loadingBar.fillAmount = 1;
        finalText.BuildText(Language.Instance.GetTranslation(translateKey), .05f);

        yield return new WaitUntil(() => Input.anyKeyDown);

        ScreenTransition.Instance.startFadingIn();

        yield return new WaitUntil(() => !ScreenTransition.Instance.InTransition);
        operation.allowSceneActivation = true;
    }

    public void RefreshTranslation()
    {
        finalText.ReplaceText(Language.Instance.GetTranslation(translateKey));
        curosityText.text = Language.Instance.GetTranslation(curiosity.CuriosityDescription);
    }

    public void OnEnable()
    {
        Language.Instance.translationChanged += RefreshTranslation;
    }

    public void OnDisable()
    {
        Language.Instance.translationChanged -= RefreshTranslation;
    }
}
