using Player;
using UnityEngine;

namespace Obstacle
{
    public class Obstacle : MonoBehaviour
    {
        public float damageDealt = 10f;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnTriggerEnter(Collider other)
        {
            Kill(other);
        }

        void Kill(Collider character)
        {
            if(!character.GetComponent<Character>()) return;
        
            character.GetComponent<Character>().army.KillUnit(character.gameObject);
        }
    }
}