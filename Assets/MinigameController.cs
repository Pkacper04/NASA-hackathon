using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;
using UnityEngine;

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
    private Star commonStar;

    [SerializeField]
    private Star unCommonStar;

    [SerializeField]
    private Star rareStar;


    private List<PlanetsScriptableData> listStarsFound = new List<PlanetsScriptableData>();

    private int starsFound = 0;

    private List<Vector3> positions = new List<Vector3>();

    private RectTransform starTransform;

    private bool gameStarted = false;

    private int minutes;

    private int seconds;

    [SerializeField]
    private float commonChance;

    [SerializeField]
    private float unCommonChance;

    [SerializeField]
    private float rareChance;

    public float CommonChance { get => commonChance; set => commonChance = value; }
    public float UnCommonChance { get => unCommonChance; set => unCommonChance = value; }
    public float RareChance { get => rareChance; set => rareChance = value; }

    public bool GameStarted { get => gameStarted; }

    public int StarsCounter { get => starsCounter; set => starsCounter = value; }
    public float TimeToSearch { get => timeToSearch; set => timeToSearch = value; }
    public float DetectingTime { get => detectingTime; set => detectingTime = value; }


    private void Start()
    {
        starTransform = commonStar.GetComponent<RectTransform>();
        InitGame();
    }

    [Button("initGame")]
    public void InitGame()
    {
        listStarsFound.Clear();
        starTransform = commonStar.GetComponent<RectTransform>();
        minutes = CalculateMinutes();
        seconds = CalculateSeconds(minutes);

        if (seconds < 10)
            timerText.text = "0" + minutes + " : " + seconds + "0";
        else
            timerText.text = "0" + minutes + " : " + seconds;
        starsFound = 0;
        positions.Clear();
        AddStars();
        gameStarted = true;
    }

    private void AddStars()
    {

        for (int i = 0; i < starsCounter; i++)
        {
            Vector3 starPosition = FindSpot();
            Star starToAdd = null;

            switch(ChooseRarity())
            {
                case 0:
                    starToAdd = commonStar;
                    starToAdd.StarData = PlanetsController.Instance.GetCommonPlanet();
                    break;
                case 1:
                    starToAdd = unCommonStar;
                    starToAdd.StarData = PlanetsController.Instance.GetUncommonPlanet();
                    break;
                case 2:
                    starToAdd = rareStar;
                    starToAdd.StarData = PlanetsController.Instance.GetRarePlanet();
                    break;
            }

            GameObject NewStar = Instantiate(starToAdd.gameObject, starPosition,Quaternion.identity, LookingArea);
            NewStar.GetComponent<RectTransform>().anchoredPosition3D = starPosition;
        }
    }

    private int ChooseRarity()
    {
        int number = Random.Range(0,101);

        if (number < commonChance)
            return 0;
        else if (number < UnCommonChance + commonChance)
            return 1;
        else
            return 2;
    }

    private Vector3 FindSpot()
    {
        for(int i=0;i<360;i++)
        {
            Debug.Log("LookingArea.rect.width: "+LookingArea.rect.width);
            float xMaxValue = (LookingArea.rect.width - lookingOffset) / 2;
            float yMaxValue = (LookingArea.rect.height - lookingOffset) / 2;

            float positionX = Random.Range(-xMaxValue, xMaxValue);
            float positionY = Random.Range(-yMaxValue, yMaxValue);

            Vector3 newPosition = new Vector3(positionX, positionY, 1f);

            if (!CheckIfPositionOccupied(newPosition))
                continue;
            positions.Add(newPosition);

            return newPosition;
        }
        return Vector3.zero;
    }

    private bool CheckIfPositionOccupied(Vector3 ourPosition)
    {

        foreach(Vector3 position in positions)
        {
            if (Mathf.Abs(position.x - ourPosition.x) < starTransform.rect.width + 10f)
            {
                return false;
            }
            else if(Mathf.Abs(position.y - ourPosition.y) < starTransform.rect.height + 10f)
            {
                return false;
            }
        }
        return true;
    }

    private void Update()
    {
        if(gameStarted)
        {
            timeToSearch -= Time.deltaTime;

            if (timeToSearch <= 0)
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
    }

    public void FoundStar(PlanetsScriptableData planet)
    {
        listStarsFound.Add(planet);

        starsFound++;
        if (starsFound == StarsCounter)
            EndGame();

    }

    private void EndGame()
    {
        gameStarted = false;
        Debug.Log("Planets that yoy found: ");
        foreach (PlanetsScriptableData data in listStarsFound)
        {
            Debug.Log(data.PlanetName);
        }
    }

    private int CalculateMinutes()
    {
        return (int)(timeToSearch / 60f);
    }

    private int CalculateSeconds(int minutes)
    {
        return (int)(timeToSearch - (minutes * 60));
    }
}
