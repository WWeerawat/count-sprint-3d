using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get { return _instance; } }
    private static LevelManager _instance;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return; //Avoid doing anything else
        }
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    [Header("Utils")]
    public GameObject player;

    [Header("Levels")]
    public GameObject[] levels;
    GameObject currentLevelObj;
    Level currentLevel;
    public int currentCount;


    // Start is called before the first frame update
    void Start()
    {
        currentLevelObj = levels[0];
        currentLevel = currentLevelObj.GetComponent<Level>();
        Vector3 startPos = currentLevel.startLine.transform.position;
        player.transform.position = new Vector3(startPos.x, startPos.y + 0.5f, startPos.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel.IsFinish(player))
        {
            Debug.Log("You finished!!");
            player.GetComponent<TestController>().enabled = false;
        }
    }

    public void StartLevel()
    {
    }
}