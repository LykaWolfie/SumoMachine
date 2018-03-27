using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour {

	private Quaternion originalRotation;

	void Start () {
		originalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = originalRotation;
	}
}
