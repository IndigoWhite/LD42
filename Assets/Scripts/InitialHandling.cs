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

    [Header("Game Over Handling")]

    public Image[] gameOverMugs;
    public TextMeshProUGUI[] gameOverNames;
    public GameObject mainUI;
    public GameObject gameOverUI;



    // Use this for initialization
    void Start () {

        for (int i = 0; i < victims.Length; i++)
        {
            remainingVictims.Add(victims[i]);
        }

        //mugSprite = victims[0].mugShot;
        mugShot.sprite = victims[0].mugShot;
        nameText.text = victims[0].victimName;
        ageText.text = victims[0].age.ToString();
        familyText.text = victims[0].family;
        jobText.text = victims[0].job;

        spacesLeftText.text = spacesLeft.ToString();
        InvokeRepeating("Timer", 1, 1);

	}

    public void Timer()
    {
        if (timeLeft <= 0)
        {
            GameOver();
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
        savedVictims.Add(remainingVictims[0]);
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

    public void KillVictim()
    {
        deadVictims.Add(remainingVictims[0]);
        NextVictim();

    }

    public void NextVictim()
    {
        remainingVictims.RemoveAt(0);

        mugShot.sprite = remainingVictims[0].mugShot;
        nameText.text = remainingVictims[0].victimName;
        ageText.text = remainingVictims[0].age.ToString();
        familyText.text = remainingVictims[0].family;
        jobText.text = remainingVictims[0].job;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");

        mainUI.SetActive(false);
        gameOverUI.SetActive(true);
        for (int i = 0; i < savedVictims.Count; i++)
        {
            gameOverMugs[i].sprite = savedVictims[i].mugShot;
            gameOverNames[i].text = savedVictims[i].victimName;
        }
    }
}
