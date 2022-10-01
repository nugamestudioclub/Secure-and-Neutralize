using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject pingPrefab;
    [SerializeField]
    private GameObject batteryIconPrefab;
    [SerializeField]
    private float scanRadius = 100;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        GameObject.Find("RadarCamera").GetComponent<Camera>().orthographicSize = scanRadius;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > 10)
        {
            timeElapsed = 0;
            Scan();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Scan();
        }
    }

    private void Scan()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, scanRadius, LayerMask.GetMask("Scannable"));

        foreach (var collider in colliders)
        {
            Debug.Log(collider.tag);
            if (collider.CompareTag("Monster"))
            {
                GameObject ping = Instantiate(pingPrefab, collider.transform, false);
                ping.transform.parent = GameObject.Find("RadarCamera").transform;
            }
            if (collider.CompareTag("Battery"))
            {
                GameObject icon = Instantiate(batteryIconPrefab, collider.transform, false);
                Camera radarCam = GameObject.Find("RadarCamera").GetComponent<Camera>();
                icon.transform.parent = radarCam.transform;
                icon.transform.rotation = Quaternion.Euler(90, radarCam.transform.rotation.eulerAngles.y, radarCam.transform.rotation.eulerAngles.z);
            }
        }
    }
}
