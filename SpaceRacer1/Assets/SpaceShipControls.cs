using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControls : MonoBehaviour {

    float _rotAngle = 0f;
    float rotSpeed = 1.4f;
    Vector3 _velocity;
 //   Vector3 _position;
    float _thrust = 1f;
	// Use this for initialization
	void Start () {
        _velocity = new Vector3(0f, 0f, 0f);
 //       _position = new Vector3(0f, 0f, 0f);

	}
	
	// Update is called once per frame
	void Update () {

        float movement = Input.GetAxis("Horizontal");
        
        _rotAngle -= movement * rotSpeed * Time.deltaTime;

        this.transform.Rotate(0, 0, _rotAngle);

        /*float vert = Input.GetAxis("Vertical");
        if (vert < 0)
            vert = 0;

        Vector3 UnitForward = transform.forward;
        _velocity.x += UnitForward.x * _thrust * vert;
        _velocity.y += UnitForward.y * _thrust * vert;

        _position.x += _velocity.x;
        _position.y += _velocity.y;*/

        _velocity.x = .01f; // * Time.deltaTime;
        transform.Translate(_velocity);

    }
}
