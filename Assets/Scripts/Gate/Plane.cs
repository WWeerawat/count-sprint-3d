using System;
using Player;
using TMPro;
using UnityEngine;

namespace Gate
{
    public class Plane : MonoBehaviour, IComputable
    {
        public Operation operation;
        public int spawnCount;

        private void Start()
        {
            transform.Find("number").GetComponent<TMP_Text>().text = SetPlaneText();
        }

        private void OnTriggerEnter(Collider other)
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

            transform.parent.gameObject.SetActive(false);
        }

        public int CalculateSpawnCount(int armyCount)
        {
            double count = armyCount;
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
            return (int) Math.Floor(count) - armyCount;
        }

        private string SetPlaneText()
        {
            string resultText = "";
            resultText += operation switch
            {
                Operation.Addition => "+",
                Operation.Subtraction => "-",
                Operation.Multiple => "x",
                Operation.Division => "÷",
                _ => throw new ArgumentOutOfRangeException()
            };
            resultText += spawnCount;

            return resultText;
        }
    }
}