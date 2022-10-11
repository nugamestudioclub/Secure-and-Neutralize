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

    private float pingHit;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("Ping", 01f, 10);
        player = GameObject.FindObjectOfType<PlayerMovement>();
        VictimBehavior[] personsVictims = GameObject.FindObjectsOfType<VictimBehavior>();
        personsWalking = new Transform[personsVictims.Length];
        lastClosest = player.transform.position;
        for (int i = 0; i < personsVictims.Length; i++)
        {
            personsWalking[i] = personsVictims[i].transform;
        }
        nav.Target(player.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 closest = lastClosest;
        Ray ray;
        RaycastHit hit;

        foreach(Transform person in personsWalking)
        {
            if(person.gameObject.activeInHierarchy)
            {
                ray = new Ray();
                ray.origin = transform.position;
                ray.direction = person.transform.position - transform.position;
                if (Physics.Raycast(ray, out hit))
                {
                    nav.Target(person.transform.position);
                }
                if (Vector3.Distance(person.transform.position, transform.position) < minDistanceForKill)
                {

                    if (person.GetComponent<VictimBehavior>().isGood)
                        PlayerWorldInteractions.goodNumKilled += 1;
                    else
                        PlayerWorldInteractions.badNumKilled += 1;
                    person.transform.gameObject.SetActive(false);
                }
            }
           
            
        }

        ray = new Ray();
        ray.origin = transform.position;
        ray.direction = player.transform.position - transform.position;
        hit = new RaycastHit();
        if(Physics.Raycast(ray,out hit))
        {
            nav.Target(player.transform.position);
        }
       
        if (Vector3.Distance(player.transform.position, transform.position) < minDistanceForKill)
        {
            SceneManager.LoadScene("EndGameScore");
        }
    }

    private void Ping()
    {
        nav.Target(player.transform.position);
    }
}
