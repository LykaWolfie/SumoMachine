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
        {//you're gonna want to store these in a public void function, such that button events can call this easily
            touchStart = Time.time;
            rotateObject = false;
        }
        else if (Input.GetMouseButtonUp(0))
		{//you're gonna want to store these in a public void function, such that button events can call this easily
            float delta = Time.time - touchStart;
            float newForce = force * delta;
			//Try looking up Mathf.Clamp
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
		{//would be better to transfer this if statement to a new script for modularity
		//That way, we can disable the PressAndHold script while still having player rotation intact. For debugging purposes...
            transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }
	}
}
