using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class Unit : MonoBehaviour
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
            if (!other.GetComponent<Unit>()) return;

            if (other.GetComponent<Unit>().army == army) return;

            army.KillUnit(gameObject, false);
            other.GetComponent<Unit>().army.KillUnit(other.gameObject, false);
        }
    }
}