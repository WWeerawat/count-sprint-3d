using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get { return _instance; } }
    private static LevelManager _instance;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
            return; //Avoid doing anything else
        }
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    [Header("Utils")]
    public GameObject player;

    [Header("Levels")]
    public GameObject[] levels;
    GameObject currentLevelObj;
    Level.Level currentLevel;
    public int currentCount;

    GameObject spawnedPlayer;

    public CinemachineVirtualCamera cinemachineVirtualCamera;


    // Start is called before the first frame update
    void Start()
    {
        currentLevelObj = levels[0];
        currentLevel = currentLevelObj.GetComponent<Level.Level>();
        currentLevelObj = Instantiate(currentLevelObj, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnedPlayer)
            return;

        spawnedPlayer.GetComponent<Army>().FreeMove();

        if (spawnedPlayer.GetComponent<Army>().IsAllUnitDies()) {
            ResetLevel();
        }

        if (currentLevel.IsFinish(spawnedPlayer)) {
            Debug.Log("You finished!!");
            DestroyPlayer();
            GameManager.Instance.mainMenuUI.SetActive(true);
        }
    }

    public void StartLevel()
    {
        InstantiatePlayer();
        GameManager.Instance.mainMenuUI.SetActive(false);
    }

    // public void SetToStartPosition()
    // {
    //     Vector3 startPos = currentLevel.startLine.transform.position;
    //     player.transform.position = new Vector3(startPos.x, startPos.y + 0.5f, startPos.z);
    // }
    public void ResetLevel()
    {
        Debug.Log("YOU DIED");
        DestroyPlayer();
        InstantiatePlayer();
    }

    private void InstantiatePlayer()
    {
        Vector3 startPos = currentLevel.startLine.transform.position;
        spawnedPlayer = Instantiate(player, new Vector3(startPos.x, startPos.y + 0.5f, startPos.z), Quaternion.identity);
        cinemachineVirtualCamera.Follow = spawnedPlayer.transform;
    }
    private void DestroyPlayer()
    {
        Destroy(spawnedPlayer);
    }

    public GameObject GetSpawnPlayer()
    {
        return spawnedPlayer;
    }
}