using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerSc : MonoBehaviour {

    [SerializeField] SpaceShipControls ssc;
    [SerializeField] Camera mCam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //mCam.transform.Translate(ssc.transform.position, Space.World);
        mCam.transform.position = ssc.transform.position;
        mCam.transform.Translate(0,0,-10f);
	}
}
