using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent nav;
    private int destpoint;
    public float patience;
    public float maxPatience;
    public float minPatience;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        patience = maxPatience;
    }

    // Update is called once per frame
    private void Update()
    {
        patience -= Time.deltaTime;
        if(patience > maxPatience)
        {
            patience = maxPatience;
        }
        
    }
    void FixedUpdate()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
        {
            GoToNextPoint();
            patience += 2;
        }
        if(patience <= 0)
        {
            GoToNextPoint();
            
        }
    }
    void GoToNextPoint()
    {
        if(points.Length == 0)
        {
            return;
        }
        nav.destination = points[destpoint].position;
        destpoint = (destpoint + 1) % points.Length;
        patience = Random.Range(minPatience, maxPatience);
    }
}
