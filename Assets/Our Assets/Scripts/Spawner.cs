using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject;

    public float minTime = 2f;
    public float maxTime = 5f;
    public float xz_components = 15f;
	public int maxCollectibleCount = 6;

    public static float time;
    private float spawnTime;
    private float x;
    private float z;

    void Start()
    {
        SetRandomTime();
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if ((time >= spawnTime)&& GameObject.FindGameObjectsWithTag("Collectibles").Length <= maxCollectibleCount) {
            setRandomComponents();
            Instantiate(spawnObject, new Vector3(x, spawnObject.transform.position.y,z), spawnObject.transform.rotation);
            SetRandomTime();
        }
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
        time = 0;
    }
    void setRandomComponents()
    {
        x = Random.Range(0, xz_components);
        z = Random.Range(0, xz_components);
    }
}
