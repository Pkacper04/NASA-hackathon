using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField]
    private Image cutscenePlace;

    [SerializeField]
    private Image dialoguePlace;

    [SerializeField]
    private CanvasGroup buttonCanvas;

    [SerializeField]
    private float imageChangeSpeed;

    [SerializeField]
    private float cutsceneChangeSpeed;

    [SerializeField]
    private float cutsceneBlackScreenDuration;

    [SerializeField]
    private float dialogOffset;

    [SerializeField]
    private float dialogSpeed;

    [SerializeField]
    private TextWriter writer;

    [SerializeField]
    private AudioSource musicAudio;

    [SerializeField]
    private float soundFadeDuration;

    [SerializeField]
    private TMP_Text endButtonText;


    [Scene]
    public string afterCutsceneScene;

    public cutscnesList listOfCutscenes = new cutscnesList();
    private int currentCutscene = -1;
    private int currentImage = 0;
    private bool canChange = true;
    private bool startCutscene = false;
    private bool canSkip = false;


    public void OnDisable()
    {
        Language.translationChanged -= RefreshTranslation;
    }

    public void OnEnable()
    {
        foreach(cutscenes cutscene in listOfCutscenes.numberOfCutscenes)
        {
            cutscene.cutsceneDialogue = Language.GetTranslation(cutscene.TranslateKeys);
        }
        Language.translationChanged += RefreshTranslation;
    }

    public void RefreshTranslation()
    {
        foreach (cutscenes cutscene in listOfCutscenes.numberOfCutscenes)
        {
            cutscene.cutsceneDialogue = Language.GetTranslation(cutscene.TranslateKeys);
        }
    }



    private void Start()
    {
        buttonCanvas.alpha = 0;
        buttonCanvas.interactable = false;
        dialoguePlace.color = new Color(1, 1, 1, 0);
        StartCoroutine(BlackScreen(cutsceneBlackScreenDuration));

    }

    void Update()
    {
        if (canSkip && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            ChangeCutscene();
        if (startCutscene && canChange)
        {
            ChangeImage();
            StartCoroutine(waitForImageChange());
            if (currentImage + 1 == listOfCutscenes.numberOfCutscenes[currentCutscene].cutsceneImages.Count)
                currentImage = 0;
            else
                currentImage++;
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeCutscene()
    {
        if (currentCutscene + 1 == listOfCutscenes.numberOfCutscenes.Count)
        {
            StartCoroutine(EndScreen());
            return;
        }
        currentCutscene++;
        StopAllCoroutines();
        canChange = false;
        StartCoroutine(waitForCutsceneChange());
    }


    public IEnumerator waitForImageChange()
    {
        canChange = false;
        yield return new WaitForSeconds(imageChangeSpeed);
        canChange = true;
    }

    public IEnumerator waitForCutsceneChange()
    {
        canSkip = false;

        while (cutscenePlace.color != new Color(0, 0, 0))
        {
            cutscenePlace.color -= new Color(cutsceneChangeSpeed, cutsceneChangeSpeed, cutsceneChangeSpeed, 0);
            dialoguePlace.color -= new Color(0, 0, 0, cutsceneChangeSpeed);
            if (cutscenePlace.color.r < 0)
            {
                cutscenePlace.color = new Color(0, 0, 0, 1);
                dialoguePlace.color = new Color(1, 1, 1, 0);
            }
            yield return null;
        }
        buttonCanvas.alpha = 0;
        buttonCanvas.interactable = false;
        currentImage = 0;
        canChange = true;
        if (writer.TextIsBuilding)
            writer.StopBuildingText();
        writer.ClearDialogue();
        ChangeImage();

        if (currentCutscene == listOfCutscenes.numberOfCutscenes.Count - 1 && endButtonText != null)
        {
            endButtonText.text = "Skip";
        }

        yield return new WaitForSeconds(cutsceneBlackScreenDuration);

        while (cutscenePlace.color != new Color(1, 1, 1))
        {
            cutscenePlace.color += new Color(cutsceneChangeSpeed, cutsceneChangeSpeed, cutsceneChangeSpeed, 0);

            if (cutscenePlace.color.r > 1)
            {
                cutscenePlace.color = new Color(1, 1, 1, 1);
            }
            yield return null;
        }
        canSkip = true;
        yield return new WaitForSeconds(dialogOffset);

        while (dialoguePlace.color != new Color(1, 1, 1, .7f))
        {
            dialoguePlace.color += new Color(0, 0, 0, cutsceneChangeSpeed);
            buttonCanvas.alpha += cutsceneChangeSpeed;
            if (dialoguePlace.color.a > .7f)
            {
                dialoguePlace.color = new Color(1, 1, 1, .7f);
            }

            yield return null;
        }

        buttonCanvas.alpha = 1;
        buttonCanvas.interactable = true;
        writer.BuildText(listOfCutscenes.numberOfCutscenes[currentCutscene].cutsceneDialogue, dialogSpeed);

    }

    public IEnumerator BlackScreen(float time)
    {
        cutscenePlace.sprite = listOfCutscenes.numberOfCutscenes[0].cutsceneImages[0];
        cutscenePlace.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(time);
        startCutscene = true;
        ChangeCutscene();
    }

    IEnumerator EndScreen()
    {
        while (cutscenePlace.color != new Color(0, 0, 0))
        {
            cutscenePlace.color -= new Color(cutsceneChangeSpeed, cutsceneChangeSpeed, cutsceneChangeSpeed, 0);
            dialoguePlace.color -= new Color(0, 0, 0, cutsceneChangeSpeed);
            if (cutscenePlace.color.r < 0)
            {
                cutscenePlace.color = new Color(0, 0, 0, 1);
                dialoguePlace.color = new Color(1, 1, 1, 0);
            }
            yield return null;
        }
        buttonCanvas.alpha = 0;
        buttonCanvas.interactable = false;
        if (writer.TextIsBuilding)
            writer.StopBuildingText();
        writer.ClearDialogue();

        yield return new WaitForSeconds(cutsceneBlackScreenDuration);
        SceneManager.LoadScene(afterCutsceneScene, LoadSceneMode.Single);
    }

    private void ChangeImage()
    {
        if (cutscenePlace.sprite == listOfCutscenes.numberOfCutscenes[currentCutscene].cutsceneImages[currentImage])
            return;

        cutscenePlace.sprite = listOfCutscenes.numberOfCutscenes[currentCutscene].cutsceneImages[currentImage];
    }



}