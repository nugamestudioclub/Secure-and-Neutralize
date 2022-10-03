using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MonsterComponent : MonoBehaviour
{
    [SerializeField]
    private NavigationManager nav;

    
    private PlayerMovement player;

    [SerializeField]
    private Transform[] personsWalking;
    [SerializeField]
    private float minDistanceForVisual = 20f;
    [SerializeField]
    private float minDistanceForKill = 5f;

    private Vector3 lastClosest;
    
    

    // Start is called before the first frame update
    void Start()
    {
        lastClosest = player.transform.position;
        InvokeRepeating("Ping", 0.0001f, 10);
        player = GameObject.FindObjectOfType<PlayerMovement>();
        VictimBehavior[] personsVictims = GameObject.FindObjectsOfType<VictimBehavior>();
        personsWalking = new Transform[personsVictims.Length];
        for(int i = 0; i < personsVictims.Length; i++)
        {
            personsWalking[i] = personsVictims[i].transform;
        }
        nav.Target(player.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 closest = lastClosest;
        foreach(Transform person in personsWalking)
        {
            float distToPerson = Vector3.Distance(person.position, transform.position);
            if (distToPerson < minDistanceForVisual&&Vector3.Distance(transform.position,closest)>distToPerson)
            {
                closest = person.position;
            }

            if (Vector3.Distance(person.position, transform.position) < minDistanceForKill)
            {
                person.gameObject.SetActive(false);
                if (person.gameObject.GetComponent<VictimBehavior>().isGood)
                {
                    PlayerWorldInteractions.goodNumKilled += 1;
                }
            }
        }
        nav.Target(closest);

        
    }

    private void Ping()
    {
        nav.Target(player.transform.position);
    }
}
