using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    Transform MainCam;
	// Use this for initialization
	void Start () {
        MainCam = GameObject.Find("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = MainCam.position;
	}
}
