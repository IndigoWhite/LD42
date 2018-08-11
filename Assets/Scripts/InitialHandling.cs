using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitialHandling : MonoBehaviour {

    public Victim[] victims;
    public Image mugShot;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI ageText;
    public TextMeshProUGUI familyText;
    public TextMeshProUGUI jobText;

    public List<Victim> remainingVictims;
    public List<Victim> savedVictims;
    public List<Victim> deadVictims;

    public TextMeshProUGUI spacesLeftText;
    public TextMeshProUGUI timerText;

    public int spacesLeft = 10;
    public int timeLeft = 90;
    private int selectedVictim;

    [Header("Game Over Handling")]

    public Image[] gameOverMugs;
    public TextMeshProUGUI[] gameOverNames;

    public Image[] gameOverDeadMugs;
    public TextMeshProUGUI[] gameOverDeadNames;

    public GameObject mainUI;
    public GameObject gameOverUI;
    public GameObject gameButtonsUI;

    public GameObject timeUpUI;
    public GameObject zeroSavesUI;
    public GameObject notEnoughSavesUI;

    private bool gameIsOver;

    // Use this for initialization
    void Start () {

        gameIsOver = false;

        for (int i = 0; i < victims.Length; i++)
        {
            remainingVictims.Add(victims[i]);
        }

        RandomVictim();

        //mugSprite = victims[0].mugShot;
        mugShot.sprite = victims[selectedVictim].mugShot;
        nameText.text = victims[selectedVictim].victimName;
        ageText.text = victims[selectedVictim].age.ToString();
        familyText.text = victims[selectedVictim].family;
        jobText.text = victims[selectedVictim].job;

        spacesLeftText.text = spacesLeft.ToString();
        InvokeRepeating("Timer", 1, 1);

	}

    public void Timer()
    {
        if (gameIsOver)
        {
            return;
        }
        if (timeLeft <= 0)
        {
            TimeUpGameOver();
            return;
        }
        else
        {
            timeLeft -= 1;
            timerText.text = timeLeft.ToString();
        }
    }
		
    public void SaveVictim()
    {
        savedVictims.Add(remainingVictims[selectedVictim]);
        spacesLeft -= 1;
        spacesLeftText.text = spacesLeft.ToString();
        if (spacesLeft > 0)
        {
            NextVictim();
        }
        else
        {
            GameOver();
        }
    }

    public void RandomVictim()
    {
        if (remainingVictims.Count <= 0)
        {
            if (savedVictims.Count == 0)
            {
                ZeroSavesGameOver();
                return;
            }
            else
            {
                NotEnoughPickedGameOver();
                return;
            }
        }
        Random rnd = new Random();
        selectedVictim = Random.Range(0, remainingVictims.Count-1);
    }

    public void KillVictim()
    {
        deadVictims.Add(remainingVictims[selectedVictim]);
        NextVictim();

    }

    public void NextVictim()
    {
        remainingVictims.RemoveAt(selectedVictim);

        RandomVictim();
        if (remainingVictims.Count <= 0)
        {
            return;
        }
        mugShot.sprite = remainingVictims[selectedVictim].mugShot;
        nameText.text = remainingVictims[selectedVictim].victimName;
        ageText.text = remainingVictims[selectedVictim].age.ToString();
        familyText.text = remainingVictims[selectedVictim].family;
        jobText.text = remainingVictims[selectedVictim].job;

        
    }

    public void GameOver()
    {
        gameIsOver = true;
        mainUI.SetActive(false);
        gameOverUI.SetActive(true);
        gameButtonsUI.SetActive(false);
        for (int i = 0; i < savedVictims.Count; i++)
        {
            gameOverMugs[i].sprite = savedVictims[i].mugShot;
            gameOverNames[i].text = savedVictims[i].victimName;
        }

        for (int i = 0; i < remainingVictims.Count; i++)
        {
            deadVictims.Add(remainingVictims[i]);
        }

        for (int i = 0; i < gameOverDeadMugs.Length; i++)
        {
            gameOverDeadMugs[i].sprite = deadVictims[i].mugShot;
           // gameOverDeadNames[i].text = deadVictims[i].victimName;
        }
    }

    public void ZeroSavesGameOver()
    {
        gameIsOver = true;
        mainUI.SetActive(false);
        gameButtonsUI.SetActive(false);
        zeroSavesUI.SetActive(true);
    }

    public void TimeUpGameOver()
    {
        gameIsOver = true;
        mainUI.SetActive(false);
        gameButtonsUI.SetActive(false);
        timeUpUI.SetActive(true);
    }

    public void NotEnoughPickedGameOver()
    {
        gameIsOver = true;
        mainUI.SetActive(false);
        gameButtonsUI.SetActive(false);
        notEnoughSavesUI.SetActive(true);
    }
}
