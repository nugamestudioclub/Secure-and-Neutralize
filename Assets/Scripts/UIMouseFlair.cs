using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMouseFlair : MonoBehaviour
{
    [SerializeField]
    Camera pov;

    [SerializeField]
    Transform door;

    [SerializeField]
    Light u_light;

    [SerializeField]
    GameObject TransitionEffect;

    bool do_effect = true;

    Vector3 original = new Vector3(-0.7f, 1f, -2.18f);

    private void OnEnable()
    {
        UIManager.GSEffects += CutsceneEffect;
    }

    private void OnDisable()
    {
        UIManager.GSEffects -= CutsceneEffect;
    }


    // Update is called once per frame
    void Update()
    {
        if (do_effect)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 13.5f;

            pos = pov.ScreenToWorldPoint(pos);

            pos.x = Mathf.Clamp(pos.x, -2.5f, 2.5f);
            pos.y = Mathf.Clamp(pos.y, 0.5f, 9.5f);

            u_light.transform.position =
                Vector3.Lerp(
                    u_light.transform.position,
                    pos,
                    0.45f);

            float delta = Input.GetAxis("Mouse X");

            u_light.transform.Rotate(0, delta * 6f, 0);
        }
    }

    public void CutsceneEffect()
    {
        StartCoroutine(IEPointAtDoor());
    }

    IEnumerator IEPointAtDoor()
    {
        Debug.Log("fired");
        do_effect = false;

        while (u_light.transform.eulerAngles.magnitude > 1.5f)
        {
            u_light.transform.position = Vector3.Lerp(u_light.transform.position, original, 0.125f);
            u_light.transform.rotation = Quaternion.Lerp(u_light.transform.rotation, Quaternion.identity, 0.5f);
            
            yield return new WaitForEndOfFrame();
        }

        u_light.transform.position = original;
        u_light.transform.eulerAngles = Vector3.zero;

        yield return StartCoroutine(IEOpenDoor());
    }

    IEnumerator IEOpenDoor()
    {
        Debug.Log("fired 2");
        Vector3 point = new Vector3(1f, 0f, 10f);

        int value = 0;

        while (value < 85)
        {
            door.RotateAround(point, Vector3.up, 9f);

            value += 9;

            yield return new WaitForEndOfFrame();
        }

        CreateTransitionEffect();
    }

    void CreateTransitionEffect()
    {
        GameObject.Instantiate(TransitionEffect,
            pov.ScreenToWorldPoint(new Vector3(Screen.width/2f, Screen.height/2f)) + Vector3.forward * 2f,
            Quaternion.identity);
    }
}
