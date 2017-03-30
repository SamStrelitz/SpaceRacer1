using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipControls : MonoBehaviour {

    float _rotAngle = 0f;
    float rotSpeed = 300f;
    public Vector3 _velocity;
    float _thrust = .05f;
    

    void Start () {
        _velocity = new Vector3(0f, 0f, 0f);

	}
	
	void Update () {

        float movement = Input.GetAxis("Horizontal");
        bool thrusting = false;
        _rotAngle -= movement * rotSpeed * Time.deltaTime;

        //transform.Rotate(0,0,_rotAngle);
        //transform.localRotation.z += _rotAngle;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, _rotAngle));

        float vert = Input.GetAxis("Vertical");
        if (vert < 0)
            vert = 0;
        else if (vert > 0)
        {
            thrusting = true;
        }

        if (thrusting)
        {
           
            Vector3 UnitForward = Vector3.ClampMagnitude(transform.up, 1);
      
            _velocity.x += UnitForward.x * _thrust * vert * Time.deltaTime;
            _velocity.y += UnitForward.y * _thrust * vert * Time.deltaTime; 
            _velocity.z = 0f;

        }
        //transform.Translate(_velocity);
        transform.Translate(_velocity, Space.World);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnterSpaceship");

        MoonDefiner md = collision.GetComponent<MoonDefiner>();

        if(md != null)
        {
            Debug.Log("Moon collider, load next scene");
        }
        else
        {
            Debug.Log("Not Moon Collider");
            Scene current = SceneManager.GetActiveScene();
            SceneManager.LoadScene(current.name);
        }
        
    }
}
