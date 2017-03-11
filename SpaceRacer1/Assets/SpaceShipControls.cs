using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControls : MonoBehaviour {

    float _rotAngle = 0f;
    float rotSpeed = 1.4f;
    Vector3 _velocity;
 //   Vector3 _position;
    float _thrust = 100000f;
	// Use this for initialization
	void Start () {
        _velocity = new Vector3(0f, 0f, 0f);
 //       _position = new Vector3(0f, 0f, 0f);

	}
	
	// Update is called once per frame
	void Update () {

        float movement = Input.GetAxis("Horizontal");
        bool thrusting = false;
        _rotAngle -= movement * rotSpeed * Time.deltaTime;

        this.transform.Rotate(0, 0, _rotAngle);

        float vert = Input.GetAxis("Vertical");
        if (vert < 0)
            vert = 0;
        if (vert > 0)
        {
            thrusting = true;
      //      Debug.Log("Thrusting");
        }

        if (thrusting)
        {
            Vector3 UnitForward = transform.forward;
            Debug.Log("X: " + UnitForward.x + " Y:" + UnitForward.y);
            //make a unit vector in the forward direction
          //  UnitForward = UnitForward / UnitForward.magnitude;

            _velocity.x += UnitForward.x * _thrust * vert * Time.deltaTime;
            _velocity.y += UnitForward.y * _thrust * vert * Time.deltaTime; 
            _velocity.z = 0f;

        }

        //_position.x += _velocity.x;
        //_position.y += _velocity.y;*/

        //_velocity.y = .02f; // * Time.deltaTime;
        transform.Translate(_velocity);

    }
}
