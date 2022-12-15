using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

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

    public GameObject mainMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}