using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetable : MonoBehaviour {
    public bool ResetOnUpdate = false;
    Material mat;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (ResetOnUpdate)
        {
            _Reset();
        }
	}

    private void _Reset()
    {
        Debug.Log("Resetting");
        mat = gameObject.GetComponent<CanvasRenderer>().GetMaterial();
        if (mat)
        {
            mat.color = Color.white;
        }
    }

    public void ManualReset()
    {
        if (ResetOnUpdate)
        {
            Debug.LogWarning("Do not manually Reset this object if ResetOnUpdate is enabled");
        }
        else
        {
            _Reset();
        }
    }
}
