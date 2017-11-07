using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {
    List<GameObject> FallenObjects = new List<GameObject>();
    public int FallenNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FallenNum = FallenObjects.Count;
	}

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if (!FallenObjects.Contains(collision.gameObject) && collision.gameObject.tag == "Target")
        {
            FallenObjects.Add(collision.gameObject);
        }
    }


}
