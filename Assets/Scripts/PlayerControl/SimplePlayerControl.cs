using UnityEngine;


// simple character controller class that only handles lateral movement.
// disable this component to disable player movement.
public class SimplePlayerControl : MonoBehaviour
{
    CharacterController controller;

    [SerializeField, Range(0f, 50f)]
    float moveForce = 10f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // not sure if CharacterController.SimpleMove deals with framerate
    // inconsistency so I'll just throw this in here for now.
    void FixedUpdate()
    {
        HandleInput();
    }

    // handles lateral movement simply :)
    // it does the job good enough
    //
    // im not sure if wrapping the whole thing in an if check to see if a key
    // is down in the first place is worth it.
    void HandleInput()
    {
        Vector3 current_movement = Vector3.zero;

        current_movement +=
            transform.forward * Input.GetAxis("Horizontal") +
            transform.right * Input.GetAxis("Vertical");

        controller.SimpleMove(current_movement * moveForce);
    }
}
