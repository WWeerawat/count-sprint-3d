using System;
using UnityEngine;

namespace Player
{
    public class Character: MonoBehaviour 
    {
        public float speed = 6f;

        public void Move(Vector3 direction)
        {
            // if (direction.magnitude >= 0.1f)
            // {
            //     Debug.Log($"{transform.position} and {direction}");
            //     transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
            //     // transform.Translate();
            // }

            transform.localPosition = new Vector3(direction.x, 0, direction.z);
        }
    }
}