using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustPressAndHold : MonoBehaviour {
	
	public float force = 750f;
	public float minForce = 500f;
	public float maxForce = 1500f;

	private float touchStart = 0f;
	private AutoRotate ar;//this will store the new AutoRotate.cs script I made

	void Start(){
		ar = GetComponent<AutoRotate> ();
		if (ar == null) {
			Debug.Log ("Patay, wala kang AutoRotate script sa player mo");
		}
	}

	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			triggerButtonPressEvents ();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			triggerButtonReleaseEvents ();
		}
	}

	public void triggerButtonPressEvents(){
		touchStart = Time.time;
		if (ar != null) {
			ar.reactToButtonPress ();	//tell the AutoRotate script to react
		}
	}

	public void triggerButtonReleaseEvents(){
		float delta = Time.time - touchStart;
		float newForce = force * delta;

		GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * Mathf.Clamp (newForce, minForce, maxForce)); //clamps value between minForce and maxForce

		if (ar != null) {
			ar.reactToButtonRelease ();	//tell the AutoRotate script to react
		}
	}

}
