using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleGravity : MonoBehaviour {

    [SerializeField] SpaceShipControls ssc;
    [SerializeField] float gravityStrength = .1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 shipPosition = ssc.transform.position;
        Vector3 myPosition = this.transform.position;
        Vector3 direction = myPosition - shipPosition;
        

        Vector3 unitDirection = Vector3.ClampMagnitude(direction, 1);
        float dx2 = direction.x * direction.x;
        float dy2 = direction.x * direction.x;
        float distanceSq = Mathf.Sqrt(dx2 + dy2);


        float distStrength = gravityStrength * (1f/distanceSq);
        ssc._velocity += unitDirection * (distStrength) * Time.deltaTime;
	}
}
