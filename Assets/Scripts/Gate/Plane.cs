using Player;
using UnityEngine;

namespace Gate
{
    public class Plane : MonoBehaviour
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
            if(!other.GetComponent<Army>()) return;
        
            LevelManager.Instance.currentCount += spawnCount;
            LevelManager.Instance.GetSpawnPlayer().GetComponent<Army>().Spawn(spawnCount);
            Debug.Log(LevelManager.Instance.currentCount);
        }
    }
}