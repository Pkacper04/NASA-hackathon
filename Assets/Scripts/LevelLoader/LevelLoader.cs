using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using NaughtyAttributes;

public class LevelLoader : MonoBehaviour
{

    [SerializeField, Scene]
    private string sceneToLoad;

    [SerializeField]
    private TextWriter finalText;

    [SerializeField]
    private string startingText;

    [SerializeField]
    private Image loadingBar;

    [SerializeField]
    private TMP_Text curosityText;

    [SerializeField]
    private Image curiosityImage;


    private void Awake()
    {
        CuriositiesScriptableObject curiosity = CuriositiesController.Instance.GetCuriosities();
        curiosityImage.sprite = curiosity.CuriosityImage;
        curosityText.text = curiosity.CuriosityDescription;
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
        finalText.BuildText(startingText, .05f);

        yield return new WaitUntil(() => Input.anyKeyDown);
        operation.allowSceneActivation = true;
    }
}
