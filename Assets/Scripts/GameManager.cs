using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    private static GameManager instance;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return; //Avoid doing anything else
        }
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public GameObject mainMenuUI;

    private void Start()
    {
        mainMenuUI.SetActive(true);
    }

}