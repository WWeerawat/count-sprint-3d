using System;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class CharacterEnemy: MonoBehaviour
    {
        public float speed;

        public Army army;

        public void Move(Vector3 direction)
        {
            transform.DOLocalMove(new Vector3(direction.x, 0, direction.z), speed);
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}