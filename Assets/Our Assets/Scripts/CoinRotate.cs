using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour {

	public float spinSpeed = 200f;
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.left * spinSpeed * Time.deltaTime);

	}


}
