using UnityEngine;

public class CameraMouseControl : MonoBehaviour
{
    [SerializeField]
    float MaxXAngle = 90f;

    [SerializeField]
    Camera player_camera;

    Vector2 ratio = Vector2.zero;
    Vector3 initial_input;

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
                locked_mouse ? CursorLockMode.Locked : CursorLockMode.None;
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

        initial_input = Input.mousePosition;
    }

    // move this to update if framerate doesnt really matter
    void FixedUpdate()
    {
        HandleMouseInput();
    }

    void HandleMouseInput()
    {
        Vector3 cache = Input.mousePosition - initial_input;

        Vector3 rot = Vector3.zero;

        rot.x = Mathf.Clamp(cache.y * ratio.y * -1f, -MaxXAngle, MaxXAngle);
        rot.y = cache.x * ratio.x;
        rot.z = 0f;

        player_camera.transform.localEulerAngles = rot;
    }
}
