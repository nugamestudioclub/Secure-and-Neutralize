using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject flashlight;

    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerWorldInteractions.inDialogue)
        {
            float xMovement = Input.GetAxis("Horizontal");
            float zMovement = Input.GetAxis("Vertical");

            Vector3 movement = transform.right * xMovement + transform.forward * zMovement;

            controller.Move(movement * speed * Time.deltaTime);

            if (Input.GetKeyDown("f"))
            {
                if (flashlight.activeSelf)
                {
                    flashlight.SetActive(false);
                }
                else
                {
                    flashlight.SetActive(true);
                }
            }
        }
    }
}
