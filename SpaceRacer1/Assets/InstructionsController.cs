using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonLoadFirstLevel()
    {
        //SceneManager.LoadScene("e1m1");
        //debug load:
        SceneManager.LoadScene("e1m6");
        
    }
}
