using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCountDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float gameTime = 90f;
    public GameObject slenderPrefab;
    public GameObject deathScreen;
    bool isSpawned = false;
    private Vector3 spawnPos = new Vector3(-17.7f, 0, 0);

    float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per framer
    void Update()
    {
        if(Time.time-startTime > gameTime && !isSpawned)
        {
            GameObject slender = Instantiate(slenderPrefab, spawnPos, slenderPrefab.transform.rotation);
            slender.GetComponent<CreepyFollow>().target = transform;
            slender.GetComponent<CreepyFollow>().deathScreen = deathScreen;
            isSpawned = true;
        }
    }
}
