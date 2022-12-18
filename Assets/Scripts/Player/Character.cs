using System;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class Character: MonoBehaviour 
    {
        public float speed;

        public Army army;

        public void Move(Vector3 direction)
        {
            // if (direction.magnitude >= 0.1f)
            // {
            //     Debug.Log($"{transform.position} and {direction}");
            //     transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
            //     // transform.Translate();
            // }

            // transform.localPosition = new Vector3(direction.x, 0, direction.z);
            transform.DOLocalMove(new Vector3(direction.x, 0, direction.z), speed);
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.GetComponent<Character>()) return;
            
            if (other.GetComponent<Character>().army == army) return;
            
            army.KillUnit(gameObject);
            other.GetComponent<Character>().army.KillUnit(other.gameObject);
        }
    }
}