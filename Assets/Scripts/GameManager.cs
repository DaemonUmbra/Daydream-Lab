using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public bool Running { get; private set; }
    Text TimeText;
    Text FallenText;
    Text HitText;
    int CubesFallen;
    int CubesHit;
    float SecsLeft = 5f;
    GameObject RestartButton;
    GameObject QuitButton;
	// Use this for initialization
	void Start () {
        Running = true;
        TimeText = GameObject.Find("TimeText").GetComponent<Text>();
        FallenText = GameObject.Find("FallenText").GetComponent<Text>();
        HitText = GameObject.Find("HitText").GetComponent<Text>();
        RestartButton = GameObject.Find("Restart Button");
        QuitButton = GameObject.Find("Quit Button");
        RestartButton.SetActive(false);
        QuitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Running)
        {
            SecsLeft -= Time.deltaTime;
            if(SecsLeft <= 0)
            {
                SecsLeft = 0;
                Running = false;
            }
            CubesHit = 0;
            CubesFallen = GameObject.Find("Plane").GetComponent<FloorScript>().FallenNum;
            foreach (GameObject Go in GameObject.FindGameObjectsWithTag("Ball"))
            {
                CubesHit += Go.GetComponent<BallScript>().CubesHit;
            }

            HitText.text = "Cubes Hit: " + CubesHit;
            FallenText.text = "Cubes Knocked Down: " + CubesFallen;
            TimeText.text = "Seconds Left: " + SecsLeft.ToString("n2");
        }
        else
        {
            RestartButton.SetActive(true);
            QuitButton.SetActive(true);
        }
    }
}
