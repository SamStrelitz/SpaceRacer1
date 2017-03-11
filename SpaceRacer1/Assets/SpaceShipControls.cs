using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControls : MonoBehaviour {

    float _rotAngle = 0f;
    float rotSpeed = 1.4f;
    float _gRot = 0;
    Vector3 _velocity;
    float _thrust = .1f;

    void Start () {
        _velocity = new Vector3(0f, 0f, 0f);

	}
	
	void Update () {

        float movement = Input.GetAxis("Horizontal");
        bool thrusting = false;
        _rotAngle -= movement * rotSpeed * Time.deltaTime;

        this.transform.Rotate(0, 0, _rotAngle);
        _gRot -= _rotAngle;

        float vert = Input.GetAxis("Vertical");
        if (vert < 0)
            vert = 0;
        else if (vert > 0)
        {
            thrusting = true;
        }

        if (thrusting)
        {
            /*    Vector3 UnitForward = new Vector3(0, 0, 0);
                Debug.Log("LocalRotX: " + this.transform.localRotation.x);
                UnitForward.x = Mathf.Sin(_gRot);
                UnitForward.y = Mathf.Cos(_gRot);
                UnitForward = Vector3.ClampMagnitude(UnitForward, 1);
                Debug.Log("gRot:" + _gRot + "X: " + UnitForward.x + " Y:" + UnitForward.y); */

            Debug.Log("Transform.right: X: " + transform.right.x + " Y:" + transform.right.y);
            Vector3 UnitForward = transform.up;
      
            _velocity.x += UnitForward.x * _thrust * vert * Time.deltaTime;
            _velocity.y += UnitForward.y * _thrust * vert * Time.deltaTime; 
            _velocity.z = 0f;

        }
        transform.Translate(_velocity);

    }
}
