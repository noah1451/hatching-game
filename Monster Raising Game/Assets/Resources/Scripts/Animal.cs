using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    [Header("NAVMESH STATS")]
    public LayerMask groundLayer, playerLayer;
    public NavMeshAgent agent;
    Vector3 destpoint;
    bool walkpointset;
    public float range;

    [Header("ANIMAL STATS")]
    public AnimalScriptable Statistics;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = Statistics.Speed;
        Patrol(); 
    }
    
    void Patrol()
    {
        if (!walkpointset)
        {
            Invoke("SearchForDestination", 3);
        }
        if(walkpointset)
        {
            agent.destination = destpoint;
        }
        if(Vector3.Distance(transform.position, destpoint) < 10)
        {
            walkpointset = false;
        }
    }

    void SearchForDestination()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destpoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destpoint, Vector3.down, groundLayer))
        {
            walkpointset = true;
        }
    }
}
