using System;
using UnityEngine;

namespace Player.Enemy
{
    [Serializable]
    public struct Enemy
    {
        public GameObject armyPrefab;
        public Transform spawnPoint;
        public int unitCount;
    }
}