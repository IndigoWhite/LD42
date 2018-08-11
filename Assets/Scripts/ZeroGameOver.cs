using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGameOver : MonoBehaviour {

    public GameObject[] panels;
    public int panelIndex = 0;

    public void NextPanel()
    {
        if (panelIndex >= panels.Length - 1)
        {
            Debug.Log("ZERO GAME OVER");
            Application.Quit();
        }

        panels[panelIndex].SetActive(false);
        panelIndex += 1;
        panels[panelIndex].SetActive(true);
    }
}
