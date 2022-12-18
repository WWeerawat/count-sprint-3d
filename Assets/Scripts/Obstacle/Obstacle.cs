using Player;
using UnityEngine;

namespace Obstacle
{
    public class Obstacle : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Kill(other);
        }

        private void Kill(Collider character)
        {
            if (!character.GetComponent<Unit>()) return;

            character.GetComponent<Unit>().army.KillUnit(character.gameObject);
        }
    }
}