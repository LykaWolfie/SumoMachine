using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void Move()
    {
     
    }
    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
	}
}
