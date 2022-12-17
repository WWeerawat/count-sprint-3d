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
            Army army = other.GetComponent<Army>();
            if (!army) return;

            int unitDiff = CalculateSpawnCount(army.units.Count);

            if (unitDiff > 0) {
                army.Spawn(unitDiff);
            }
            else {
                army.KillUnitFromCount(Math.Abs(unitDiff));
            }

            Debug.Log($"Spawn {unitDiff}");
        }

        public int CalculateSpawnCount(int armyCount)
        {
            double count = armyCount;
            // Debug.Log("START" + count);
            switch (operation) {
                case Operation.Addition:
                    count += spawnCount;
                    break;

                case Operation.Subtraction:
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
            // Debug.Log("RESULT" + count);
            return (int)Math.Floor(count) - armyCount;
        }
    }
}