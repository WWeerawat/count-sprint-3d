using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float damageDealt = 10f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider colliderComp)
    {
        if (colliderComp.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Player hit obstacle name {name}");
            LevelManager.Instance.ResetLevel();
        }
    }
}