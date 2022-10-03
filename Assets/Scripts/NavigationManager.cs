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
    private Vector3 testDestination;

    public void Target(Vector3 destination)
    {
        navigationAgent.SetDestination(destination);
        navigationAgent.speed = speed;
        navigationAgent.isStopped = false;
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
