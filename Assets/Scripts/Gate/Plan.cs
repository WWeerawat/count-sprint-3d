using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plan : MonoBehaviour
{
    public int spawnCount;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        LevelManager.Instance.currentCount += spawnCount;
        Debug.Log(LevelManager.Instance.currentCount);
    }
}