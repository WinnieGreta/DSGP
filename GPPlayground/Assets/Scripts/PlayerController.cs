using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector3 target;
    
    NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //target = agent.transform.position;
        //agent.SetDestination(target);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Mouse down");
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            agent.SetDestination(target);
        }
        //Debug.Log(target);
    }
}
