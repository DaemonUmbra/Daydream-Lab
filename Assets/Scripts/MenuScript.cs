using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {
    Ray GazeRay;
    RaycastHit GazeHit;
    float SecondsToClick = 1f;
    float? GazeStart = null;
    Text DebugText;
	// Use this for initialization
	void Start () {
        DebugText = GameObject.Find("Debug Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        GazeRay = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(GazeRay, out GazeHit))
        {
            if (GazeHit.transform.GetComponent<UnityEngine.UI.Button>())
            {
                if (GazeStart == null)
                {
                    GazeStart = Time.time;
                }
                if (GvrControllerInput.ClickButtonDown || (Time.time >= GazeStart + SecondsToClick))
                {
                    if (GazeHit.collider.transform.name == "Start Button" || GazeHit.collider.transform.name == "Restart Button")
                    {
                        GazeStart = null;
                        LoadMainLevel();
                    }
                    if(GazeHit.collider.transform.name == "Quit Button")
                    {
                        GazeStart = null;
                        Quit();
                    }
                }
            }
            else
            {
                GazeStart = null;
            }
        }
        else
        {
            GazeStart = null;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadMainLevel()
    {
        SceneManager.LoadScene(1);
    }
}
