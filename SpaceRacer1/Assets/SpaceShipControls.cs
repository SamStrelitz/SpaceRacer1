using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControls : MonoBehaviour {

    float _rotAngle = 0f;
    float rotSpeed = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float movement = Input.GetAxis("Mouse X");
        
        _rotAngle -= movement * rotSpeed * Time.deltaTime;

        this.transform.Rotate(0, 0, _rotAngle);
        
	}
}
