using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipControls : MonoBehaviour {

    float _rotAngle = 0f;
    float rotSpeed = 300f;
    public Vector3 _velocity;
    float _thrust = .01f;

    private bool ButtonThrust = false;
    private bool RightButtonPushed = false;
    private bool LeftButtonPushed = false;

    [SerializeField] bool UsingButtons = false;
    [SerializeField] ParticleThrustScript pts;

    void Start () {
        _velocity = new Vector3(0f, 0f, 0f);

	}
	
	void Update () {
        float movement = 0;
        if (UsingButtons == false)
        {
            movement = Input.GetAxis("Horizontal");
        }
        else
        {
            if (RightButtonPushed == true)
                movement = 1;
            else if (LeftButtonPushed == true)
                movement = -1;
            else
                movement = 0;
        }
        bool thrusting = false;
        _rotAngle -= movement * rotSpeed * Time.deltaTime;

        //transform.Rotate(0,0,_rotAngle);
        //transform.localRotation.z += _rotAngle;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, _rotAngle));


        if (UsingButtons == false)
        {


            float vert = Input.GetAxis("Vertical");
            if (vert < 0)
                vert = 0;
            else if (vert > 0)
            {
                thrusting = true;
            }
        }
        else
        {
            thrusting = ButtonThrust;
        }
        
        if (thrusting)
        {

            pts.gameObject.SetActive(true);
            Vector3 UnitForward = Vector3.ClampMagnitude(transform.up, 1);

            /*_velocity.x += UnitForward.x * _thrust * vert * Time.deltaTime;
            _velocity.y += UnitForward.y * _thrust * vert * Time.deltaTime;
            _velocity.z = 0f;*/
            _velocity.x += UnitForward.x * _thrust  * Time.deltaTime;
            _velocity.y += UnitForward.y * _thrust  * Time.deltaTime;
            _velocity.z = 0f; 

        }
        else
        {
            pts.gameObject.SetActive(false);
        }

        //transform.Translate(_velocity);
        transform.Translate(_velocity, Space.World);

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnterSpaceship");

        MoonDefiner md = collision.GetComponent<MoonDefiner>();

        if(md != null)
        {
            Scene current = SceneManager.GetActiveScene();
            Debug.Log("Moon collider, load next scene");
            Debug.Log(current.name + "");

            if(current.name == "e1m1")
            {
                SceneManager.LoadScene("e1m2");
            }
            if(current.name == "e1m2")
            {
                SceneManager.LoadScene("e1m3");
            }
            if (current.name == "e1m3")
            {
                SceneManager.LoadScene("e1m4");
            }
            if (current.name == "e1m4")
            {
                SceneManager.LoadScene("e1m5");
            }
            if (current.name == "e1m5")
                SceneManager.LoadScene("e1m6");
            if(current.name=="e1m6")
            {
                SceneManager.LoadScene("Winner");
            }
        }
        else
        {
            Debug.Log("Not Moon Collider");
            Scene current = SceneManager.GetActiveScene();
            SceneManager.LoadScene(current.name);
        }
        
    }
    public void ThrustButtonPushed()
    {
        Debug.Log("Thrust Button Pushed");
        ButtonThrust = true;
    }
    public void ThrustButtonReleased()
    {
        Debug.Log("Thrust Button Released");
        ButtonThrust = false;
    }
    public void RightButtonDown()
    {
        Debug.Log("Right Button Down");
        RightButtonPushed = true;
    }
    public void RightButtonReleased()
    {
        RightButtonPushed = false;
    }
    public void LeftButtonDown()
    {
        LeftButtonPushed = true;
    }
    public void LeftButtonReleased()
    {
        LeftButtonPushed = false;
    }
}
