using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public GameObject[] uiPanels;
    private int currentPanelSelected = 0;

	public void AdvancePanel()
    {
        uiPanels[currentPanelSelected].SetActive(false);
        currentPanelSelected += 1;
        uiPanels[currentPanelSelected].SetActive(true);        
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        if (currentPanelSelected+1 == uiPanels.Length)
        {
            SceneManager.LoadScene("Main");
            return;
        }      
    }

}
