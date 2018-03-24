using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAndHold : MonoBehaviour {

    public float force = 750f;
    public float minForce = 500f;
    public float maxForce = 1500f;
    float touchStart = 0f;
    bool rotateObject = true;
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Time.time;
            rotateObject = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            float delta = Time.time - touchStart;
            float newForce = force * delta;
            if (newForce <= minForce)
            {
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * minForce);
            }
            else if (newForce >= maxForce)
            {
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * maxForce);
            }
            else
            {
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * newForce);
            }
            rotateObject = true;
            
        }
        if (rotateObject)
        {
            transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }
	}
}
