using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustPressAndHold : MonoBehaviour {
	
	public float force = 750f;
	public float minForce = 500f;
	public float maxForce = 1500f;

	private float touchStart = 0f;
	private PlayerRotate ar;//this will store the new PlayerRotate.cs script I made

	void Start(){
		ar = GetComponent<PlayerRotate> ();
		if (ar == null) {
			Debug.Log ("Patay, wala kang PlayerRotate script sa player mo");
		}
	}

	public void triggerButtonPressEvents(){
		touchStart = Time.time;
		if (ar != null) {
			ar.reactToButtonPress ();	//tell the PlayerRotate script to react
		}
	}

	public void triggerButtonReleaseEvents(){
		float delta = Time.time - touchStart;
		float newForce = force * delta;

		GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * Mathf.Clamp (newForce, minForce, maxForce)); //clamps value between minForce and maxForce

		if (ar != null) {
			ar.reactToButtonRelease ();	//tell the PlayerRotate script to react
		}
	}

}
