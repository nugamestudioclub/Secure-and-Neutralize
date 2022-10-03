using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldVictimFacer : MonoBehaviour
{
    [SerializeField]
    private Vector3 baseRotation;
    // Update is called once per frame
    void Update()
    {
        Vector3 flatPos = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(flatPos);
        transform.Rotate(baseRotation);
    }
}
