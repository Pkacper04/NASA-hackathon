using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;
using System;
using UnityEngine.UI;

public class MinigameController : Singleton<MinigameController>
{
    [SerializeField]
    private int starsCounter;

    [SerializeField]
    private float timeToSearch;

    [SerializeField, MaxValue(60)]
    private float detectingTime;

    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private RectTransform LookingArea;

    [SerializeField]
    private float lookingOffset;

    [SerializeField]
    private float cooldownTime;

    [SerializeField]
    private GameObject globalLight;

    [SerializeField]
    private Canvas backgroundCanvas;

    [SerializeField]
    private GraphicRaycaster backgroundRaycaster;

    [SerializeField]
    private GameObject SpotLight;

    [SerializeField]
    private Canvas canvasGui;

    [SerializeField]
    private GraphicRaycaster guiRaycaster;

    [SerializeField]
    private CanvasGroup AreaGroup;

    [SerializeField]
    private TMP_Text startMisionText;

    [SerializeField]
    private Button startMissionButton;

    [SerializeField]
    private string buttonCommonText;

    private bool hasCooldown = false;

    private float timeToLeft;

    private float tempTimeToSearch;


    [SerializeField]
    private Star commonStar;

    [SerializeField]
    private Star unCommonStar;

    [SerializeField]
    private Star rareStar;


    private List<PlanetsScriptableData> listStarsFound = new List<PlanetsScriptableData>();

    private int starsFound = 0;

    private List<Vector3> positions = new List<Vector3>();



    private bool gameStarted = false;

    private int minutes;

    private int seconds;

    private List<PlanetsScriptableData> starsOnMap = new List<PlanetsScriptableData>();

    [SerializeField]
    private float commonChance;

    [SerializeField]
    private float unCommonChance;

    [SerializeField]
    private float rareChance;

    [SerializeField]
    private AudioSource backgroundMusic;

    [SerializeField]
    private AudioSource miniGameBackgroundMusic;

    [SerializeField]
    private AudioSource sfx_photographingStar;

    [SerializeField]
    private AudioSource sfx_photographedStar;

    [SerializeField]
    private AudioSource sfx_newspaper;

    [SerializeField]
    private AudioClip sfx_photographedStar_OneShot;

    [SerializeField]
    private AudioClip sfx_newspaper_OneShot;

    [SerializeField]
    private TutorialStepsData minigameQuest;

    [SerializeField]
    private TutorialStepsData finishMinigameQuest;

    public float CommonChance { get => commonChance; set => commonChance = value; }
    public float UnCommonChance { get => unCommonChance; set => unCommonChance = value; }
    public float RareChance { get => rareChance; set => rareChance = value; }

    public bool GameStarted { get => gameStarted; }

    public int StarsCounter { get => starsCounter; set => starsCounter = value; }
    public float TimeToSearch { get => timeToSearch; set => timeToSearch = value; }
    public float DetectingTime { get => detectingTime; set => detectingTime = value; }

    public bool HasCooldown { get => hasCooldown; set => hasCooldown = value; }

    public Action OnEndCooldown;

    public void CallOnEndCooldown()
    {
        if (OnEndCooldown != null)
            OnEndCooldown.Invoke();
    }


    private void OnEnable()
    {
        TechTreeController.Instance.OnSpecificResearchBuy += upgradeSatelite;
    }

    private void OnDisable()
    {
        if (TechTreeController.Instance != null)
        {
            TechTreeController.Instance.OnSpecificResearchBuy -= upgradeSatelite;
        }
    }


    public void upgradeSatelite(UpgradeData data)
    {
        if (data.CurrentResearchData.typeOfReaserch != TypeOfReaserch.Satelite)
            return;

        switch (data.CurrentResearchData.sateliteData)
        {
            case SateliteData.ReaserchAmount:
                ReaserchAmountUpgrade(data.CurrentResearchData);
                break;
            case SateliteData.ReaserchLength:
                ReaserchLengthUpgrade(data.CurrentResearchData);
                break;
            case SateliteData.ReaserchRarity:
                ReaserchRarityUpgrade(data.CurrentResearchData);
                break;
        }
    }

    private void ReaserchRarityUpgrade(ResearchData currentResearchData)
    {
        if (currentResearchData.reaserchLevel == ReaserchLevel.L1)
        {
            commonChance = 70;
            unCommonChance = 25;
            rareChance = 5;
        }
        else if (currentResearchData.reaserchLevel == ReaserchLevel.L2)
        {
            commonChance = 50;
            unCommonChance = 35;
            rareChance = 15;
        }
        else
        {
            commonChance = 30;
            unCommonChance = 45;
            rareChance = 25;
        }
    }

    private void ReaserchLengthUpgrade(ResearchData currentResearchData)
    {
        if (currentResearchData.reaserchLevel == ReaserchLevel.L1)
        {
            timeToSearch = 72;
        }
        else if (currentResearchData.reaserchLevel == ReaserchLevel.L2)
        {
            timeToSearch = 90;
        }
        else
        {
            timeToSearch = 120;
        }
    }

    private void ReaserchAmountUpgrade(ResearchData currentResearchData)
    {
        if (currentResearchData.reaserchLevel == ReaserchLevel.L1)
        {
            starsCounter = 4;
        }
        else if (currentResearchData.reaserchLevel == ReaserchLevel.L2)
        {
            starsCounter = 6;
        }
        else
        {
            starsCounter = 9;
        }
    }

    [Button("initGame")]
    public void InitGame()
    {

        if (hasCooldown)
            return;

        if(TutorialController.Instance.TutorialGoing)
        {
            TutorialController.Instance.FinishQuest(minigameQuest);
        }

        starsOnMap.Clear();
        ClosePopups.Instance.CloseAllPanels();

        tempTimeToSearch = timeToSearch;

        ScreenTransition.Instance.startFadingIn();
        backgroundRaycaster.enabled = true;
        listStarsFound.Clear();
        minutes = CalculateMinutes();
        seconds = CalculateSeconds(minutes);

        if (seconds < 10)
            timerText.text = "0" + minutes + " : " + seconds + "0";
        else
            timerText.text = "0" + minutes + " : " + seconds;
        starsFound = 0;
        positions.Clear();
        Cursor.visible = false;
        AddStars();
        EnableMinigameValues();
        backgroundMusic.Stop();
        miniGameBackgroundMusic.Play();
    }

    private void AddStars()
    {

        for (int i = 0; i < starsCounter; i++)
        {
            Debug.Log("start");
            Vector3 starPosition = FindSpot();
            Star starToAdd = null;

            int rarity = ChooseRarity();

            if (rarity == 0)
            {
                starToAdd = commonStar;
                starToAdd.StarData = PlanetsController.Instance.GetCommonPlanet();
                if (CheckIfStarExists(starToAdd.StarData))
                {
                    i -= 1;
                    Debug.Log("check");
                    continue;
                }
            }
            else if (rarity == 1)
            {

                starToAdd = unCommonStar;
                starToAdd.StarData = PlanetsController.Instance.GetUncommonPlanet();
                if (CheckIfStarExists(starToAdd.StarData))
                {
                    i -= 1;
                    Debug.Log("check");
                    continue;
                }
            }
            else
            {
                starToAdd = rareStar;
                starToAdd.StarData = PlanetsController.Instance.GetRarePlanet();
                if (CheckIfStarExists(starToAdd.StarData))
                {
                    i -= 1;
                    Debug.Log("check");
                    continue;
                }
            }
            Debug.Log("finish");
            GameObject NewStar = Instantiate(starToAdd.gameObject, starPosition, Quaternion.identity, LookingArea);
            NewStar.GetComponent<RectTransform>().anchoredPosition3D = starPosition;
        }
    }
    

    private bool CheckIfStarExists(PlanetsScriptableData starToAdd)
    {
        if (starsOnMap.Contains(starToAdd))
        {
            return true;
        }
        else
        {
            starsOnMap.Add(starToAdd);
            return false;
        }
    }

    private int ChooseRarity()
    {
        int number = UnityEngine.Random.Range(0, 101);

        if (number <= commonChance)
            return 0;
        else if (number <= UnCommonChance + commonChance)
            return 1;
        else
            return 2;
    }

    private Vector3 FindSpot()
    {
        for (int i = 0; i < 360; i++)
        {
            float xMaxValue = (LookingArea.rect.width - lookingOffset) / 2;
            float yMaxValue = (LookingArea.rect.height - lookingOffset) / 2;

            float positionX = UnityEngine.Random.Range(-xMaxValue, xMaxValue);
            float positionY = UnityEngine.Random.Range(-yMaxValue, yMaxValue);

            Vector3 newPosition = new Vector3(positionX, positionY, 1f);

            if (!CheckIfPositionOccupied(newPosition))
                continue;
            positions.Add(newPosition);

            Debug.Log("return new position");

            return newPosition;
        }

        Debug.Log("return 0");
        return Vector3.zero;
    }

    private bool CheckIfPositionOccupied(Vector3 ourPosition)
    {

        Collider2D hitColliders = Physics2D.OverlapCircle(ourPosition, 10);

        if (hitColliders != null)
        {
            return false;
        }
        
        return true;
    }

    private void Update()
    {
        if (gameStarted)
        {
            tempTimeToSearch -= Time.deltaTime;

            if (tempTimeToSearch <= 0)
            {
                timerText.text = "00 : 00";
                EndGame();
                return;
            }

            minutes = CalculateMinutes();
            seconds = CalculateSeconds(minutes);

            if (seconds < 10)
                timerText.text = "0" + minutes + " : " + "0" + seconds;
            else
                timerText.text = "0" + minutes + " : " + seconds;

        }
        else if (hasCooldown)
        {
            int Cminutes = CalculateMinutes(timeToLeft);
            int Cseconds = CalculateSeconds(timeToLeft, Cminutes);

            if (Cseconds < 10)
                startMisionText.text = "0" + Cminutes + " : " + "0" + Cseconds;
            else
                startMisionText.text = "0" + Cminutes + " : " + Cseconds;
            if (timeToLeft <= 0)
            {
                hasCooldown = false;
                startMisionText.text = buttonCommonText;
                startMissionButton.interactable = true;
                CallOnEndCooldown();
            }
            timeToLeft -= Time.deltaTime;
        }
    }

    public void FoundStar(PlanetsScriptableData planet)
    {
        listStarsFound.Add(planet);
        sfx_photographedStar.PlayOneShot(sfx_photographedStar_OneShot,1f);
        starsFound++;
        if (starsFound == StarsCounter)
            EndGame();

    }

    private void EndGame()
    {
        gameStarted = false;

        ScreenTransition.Instance.startFadingIn();
        miniGameBackgroundMusic.Stop();
       

        StartCoroutine(WaitForNewspaper());

    }

    private void ClearArea()
    {
        for (int i = 1; i < LookingArea.childCount; i++)
        {
            Destroy(LookingArea.GetChild(i).gameObject);
        }
    }

    private IEnumerator WaitForNewspaper()
    {
        yield return new WaitUntil(() => ScreenTransition.Instance.InTransition == false);
        globalLight.SetActive(true);
        backgroundRaycaster.enabled = false;
        SpotLight.SetActive(false);
        guiRaycaster.enabled = true;
        canvasGui.enabled = true;
        AreaGroup.alpha = 0;
        AreaGroup.interactable = false;
        AreaGroup.blocksRaycasts = false;
        NewspaperController.Instance.EnableNewspaper();
        sfx_newspaper.PlayOneShot(sfx_newspaper_OneShot, 1f);

        int Cminutes = CalculateMinutes(cooldownTime);
        int Cseconds = CalculateSeconds(cooldownTime, Cminutes);

        if (Cseconds < 10)
            startMisionText.text = "0" + Cminutes + " : " + "0" + Cseconds;
        else
            startMisionText.text = "0" + Cminutes + " : " + Cseconds;

        timeToLeft = cooldownTime;

        startMissionButton.interactable = false;
        ClearArea();
       
        Cursor.visible = true;
        ScreenTransition.Instance.startFadingOut();
        yield return new WaitUntil(() => ScreenTransition.Instance.InTransition == false);

        NewspaperController.Instance.InitNewspaper(listStarsFound);
    }

    private int CalculateMinutes(float cooldownTime)
    {
        return (int)(cooldownTime / 60f);
    }

    private int CalculateSeconds(float cooldownTime, int minutes)
    {
        return (int)(cooldownTime - (minutes * 60));
    }

    private int CalculateMinutes()
    {
        return (int)(tempTimeToSearch / 60f);
    }

    private int CalculateSeconds(int minutes)
    {
        return (int)(tempTimeToSearch - (minutes * 60));
    }

    private void EnableMinigameValues()
    {
        StartCoroutine(WaitForTransition());
    }

    private IEnumerator WaitForTransition()
    {
        yield return new WaitUntil(() => ScreenTransition.Instance.InTransition == false);
        globalLight.SetActive(false);
        SpotLight.SetActive(true);
        guiRaycaster.enabled = false;
        canvasGui.enabled = false;
        backgroundRaycaster.enabled = true;
        AreaGroup.alpha = 1;
        AreaGroup.interactable = true;
        AreaGroup.blocksRaycasts = true;
        ScreenTransition.Instance.startFadingOut();
        yield return new WaitUntil(() => ScreenTransition.Instance.InTransition == false);
        yield return new WaitForSeconds(.5f);

        if(TutorialController.Instance.TutorialGoing)
        {
            Cursor.visible = true;
            TutorialController.Instance.DisplayMinigameTutorialPanel();
            yield return new WaitUntil(() => TutorialController.Instance.MinigameTutorialGoing == false);
            Cursor.visible = false;
            yield return new WaitForSeconds(.5f);
        }

        gameStarted = true;
    }

    internal void StartCooldown()
    {
        if(TutorialController.Instance.TutorialGoing)
        {
            TutorialController.Instance.FinishQuest(finishMinigameQuest);
            TechTreeController.Instance.BlockTechTree = false;
        }
        hasCooldown = true;
    }
}
