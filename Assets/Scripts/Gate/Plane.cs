using System;
using Player;
using TMPro;
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
            transform.Find("number").GetComponent<TMP_Text>().text = SetPlaneText();
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

            transform.parent.gameObject.SetActive(false);

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

        public string SetPlaneText()
        {
            string resultText = "";
            switch (operation) {
                case Operation.Addition:
                    resultText += "+";
                    break;

                case Operation.Subtraction:
                    resultText += "-";
                    break;

                case Operation.Multiple:
                    resultText += "x";
                    break;

                case Operation.Division:
                    resultText += "÷";
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            resultText += spawnCount;

            return resultText;
        }
    }
}