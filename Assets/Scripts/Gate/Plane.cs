using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gate
{
    public class Plane : MonoBehaviour, IComputable
    {
        public Operation operation;
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
            if (!other.GetComponent<Army>()) return;

            int spawnTo = CalculateSpawnCount();
            LevelManager.Instance.currentCount += spawnTo;
            Army army = LevelManager.Instance.GetSpawnPlayer().GetComponent<Army>();
            if (spawnTo > 0)
            {
                army.Spawn(spawnTo);
            }
            else
            {
                army.KillUnitFromCount(Math.Abs(spawnTo));
            }

            Debug.Log($"Spawn {spawnTo}");
        }

        public int CalculateSpawnCount()
        {
            double count = LevelManager.Instance.currentCount;
            Debug.Log("START" + count);
            switch (operation)
            {
                case Operation.Add:
                    count += spawnCount;
                    break;

                case Operation.Subtract:
                    count -= spawnCount;
                    break;

                case Operation.Multiple:
                    count *= spawnCount;
                    break;

                case Operation.Division:
                    count /= spawnCount;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            Debug.Log("RESULT" + count);
            return (int)Math.Floor(count) - LevelManager.Instance.currentCount;
        }
    }
}