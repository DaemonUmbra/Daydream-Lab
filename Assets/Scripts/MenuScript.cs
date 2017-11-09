using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    Ray GazeRay;
    RaycastHit GazeHit;
    float SecondsToClick = 1f;
    float? GazeStart;
	// Use this for initialization
	void Start () {
		
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
                    if (GazeHit.collider.gameObject.name == "Start Button" || GazeHit.collider.gameObject.name == "Restart Button")
                    {
                        LoadMainLevel();
                    }
                    if(GazeHit.collider.gameObject.name == "Quit Button")
                    {
                        Application.Quit();
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

    void LoadMainLevel()
    {
        SceneManager.LoadScene(1);
    }
}
