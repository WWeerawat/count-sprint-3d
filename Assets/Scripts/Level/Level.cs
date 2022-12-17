using System;
using UnityEngine;

namespace Level
{
    public class Level : MonoBehaviour
    {
        public GameObject startLine;

        public GameObject finishLine;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public bool IsFinish(GameObject player)
        {
            return Math.Abs(player.transform.position.z - finishLine.transform.position.z) < 1;
        }
    }
}