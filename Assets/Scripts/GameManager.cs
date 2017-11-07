using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    Text TimeText;
    Text FallenText;
    Text HitText;
    int CubesFallen;
    int CubesHit;
    float SecsLeft = 60f;
	// Use this for initialization
	void Start () {
        TimeText = GameObject.Find("TimeText").GetComponent<Text>();
        FallenText = GameObject.Find("FallenText").GetComponent<Text>();
        HitText = GameObject.Find("HitText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        SecsLeft -= Time.deltaTime;
        CubesHit = 0;
        CubesFallen = GameObject.Find("Plane").GetComponent<FloorScript>().FallenNum;
        foreach(GameObject Go in GameObject.FindGameObjectsWithTag("Ball"))
        {
            CubesHit += Go.GetComponent<BallScript>().CubesHit;
        }

        HitText.text = "Cubes Hit: " + CubesHit;
        FallenText.text = "Cubes Knocked Down: " + CubesFallen;
        TimeText.text = "Seconds Left: " + SecsLeft.ToString("n2");
	}
}
