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
            transform.DOLocalMove(new Vector3(direction.x, 0, direction.z), speed);
        }

        public Tween MoveWorld(Vector3 direction)
        {
            return transform.DOMove(direction, speed);
        }

        public void Die()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.GetComponent<Character>()) return;
            
            if (other.GetComponent<Character>().army == army) return;
            
            army.KillUnit(gameObject, false);
            other.GetComponent<Character>().army.KillUnit(other.gameObject, false);
        }
    }
}