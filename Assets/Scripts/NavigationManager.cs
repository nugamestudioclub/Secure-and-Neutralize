using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavigationManager : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent navigationAgent;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private Vector3 target;
    

    public void Target(Vector3 destination)
    {
        navigationAgent.SetDestination(destination);
        navigationAgent.speed = speed;
        navigationAgent.isStopped = false;
        navigationAgent.destination = destination;
        this.target = destination;
        print("Updated to:" + destination.ToString());
    }

    public void StopNavigation()
    {
        this.navigationAgent.isStopped = false;
    }
    public void StartNavigation()
    {
        
        this.navigationAgent.isStopped = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        navigationAgent.isStopped = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
