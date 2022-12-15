using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Level : MonoBehaviour
{
    public GameObject startLine;

    public GameObject finishLine;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsFinish(GameObject player)
    {
        return Math.Abs(player.transform.position.z - finishLine.transform.position.z) < 1;
    }
}