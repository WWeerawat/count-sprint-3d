using UnityEngine;

namespace PlayerTest
{
    public class TestController : MonoBehaviour
    {
        // Movement speed of the player
        public float speed = 10f;

        // CharacterController component attached to the player
        CharacterController _controller;

        // Start is called before the first frame update
        void Start()
        {
            // Get the CharacterController component attached to the player
            _controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            // Get input from the horizontal and vertical axes
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
        
            // Calculate the player's movement
            Vector3 movement = new Vector3(horizontal, 0, vertical);
            movement = movement.normalized * (speed * Time.deltaTime);
        
            // Move the player
            _controller.Move(movement);
        }
    }
}