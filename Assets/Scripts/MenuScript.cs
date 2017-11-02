using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    Ray GazeRay;
    RaycastHit GazeHit;
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
                Debug.Log("Hit Button");
                Material mat = GazeHit.transform.GetComponent<CanvasRenderer>().GetMaterial();
                mat.color = Color.red;
                if (GvrControllerInput.ClickButtonDown)
                {
                    LoadMainLevel();
                }
            }
        }
	}

    void LoadMainLevel()
    {
        SceneManager.LoadScene("Main Scene");
    }
}
