using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    [Header("Utils")]
    public GameObject player;

    [Header("Levels")]
    public GameObject[] levels;
    GameObject currentLevelObj;
    GameObject currentLevelStartLine;
    GameObject currentLevelFinishLine;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartLevel()
    {
    }
}