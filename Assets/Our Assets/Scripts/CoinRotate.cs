using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour {

	public float spinSpeed = 200f;
    public float minTime = 2f;
    public float maxTime = 5f;
    public float xz_components = 5f;

    private float time;
    private int flag;
    private float spawnTime;
    private float x;
    private float z;

    void Start () {
        flag = 0;
        SetRandomTime();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.left * spinSpeed * Time.deltaTime);
        if (flag == 1)
        {
            time += Time.deltaTime;
        }
        if (time >= spawnTime)
        {
            setRandomComponents();
            transform.SetPositionAndRotation(new Vector3(x, transform.position.y, z), transform.rotation);
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            SetRandomTime();
        }

    }
    void setRandomComponents()
    {
        x = Random.Range(0, xz_components);
        z = Random.Range(0, xz_components);
    }
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
        time = 0;
        flag = 0;
    }
    public void triggerFlag()
    {
        flag = 1;
    }
}
