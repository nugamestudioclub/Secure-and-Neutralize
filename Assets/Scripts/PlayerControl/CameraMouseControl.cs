using UnityEngine;

public class CameraMouseControl : MonoBehaviour
{
    [SerializeField]
    float MaxXAngle = 90f;

    [SerializeField]
    Camera player_camera;

    Vector2 ratio = Vector2.zero;
    // Vector3 initial_input;

    bool locked_mouse = false;

    // change this if you need to use mouse point to click on UI stuff
    public bool Locked_Mouse
    {
        get
        {
            return locked_mouse;
        }

        set
        {
            locked_mouse = value;

            Cursor.lockState =
                locked_mouse ? CursorLockMode.Confined : CursorLockMode.None;
        }
    }

    void Start()
    {
        if (player_camera == null)
        {
            player_camera = GetComponentInChildren<Camera>();
        }

        ratio.x = 360f / Screen.width;
        ratio.y = 180f / Screen.height;

        Locked_Mouse = true;

        // initial_input = Input.mousePosition;
    }

    // move this to update if framerate doesnt really matter
    void FixedUpdate()
    {
        HandleMouseInput();
    }

    void HandleMouseInput()
    {
        
        float deltaX = Input.GetAxis("Mouse X");
        float deltaY = Input.GetAxis("Mouse Y");

       
        player_camera.transform.Rotate(-deltaY,0, 0);
        player_camera.transform.parent.Rotate(0, deltaX, 0);
        //player_camera.transform.localEulerAngles = rot;
        //player_camera.transform.localEulerAngles = player_camera.transform.localEulerAngles + new Vector3(deltaX,deltaY,0);
    }
}
