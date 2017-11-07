using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    List<GameObject> HitCubes = new List<GameObject>();
    public int CubesHit;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CubesHit = HitCubes.Count;
	}

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if(!HitCubes.Contains(collision.gameObject) && (collision.gameObject.tag == "Target" || collision.gameObject.tag == "FloorTarget"))
        {
            HitCubes.Add(collision.gameObject);
        }
    }


}
