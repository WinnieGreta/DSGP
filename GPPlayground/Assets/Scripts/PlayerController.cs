using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector3 target;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private InputActionAsset actions;
    private InputAction pointAction;
    private Vector2 moveInput;
    [SerializeField] private float directVelocity;
    private Rigidbody2D rb;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //actions = GetComponent<PlayerInput>().actions;
        //pointAction = actions.FindAction("Fire");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if (pointAction.WasPerformedThisFrame())
        // {
        //     Debug.Log("Mouse down");
        // }
        rb.velocity = moveInput * directVelocity;
        if (agent.enabled && Math.Abs(target.x - transform.position.x) <= 0.1 && Math.Abs(target.y - transform.position.y) <= 0.1)
        {
            Debug.Log("Reached destination");
            agent.isStopped = true;
        }
    }

    public void SetTarget(InputAction.CallbackContext context)
    {
        agent.enabled = true;
        target = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        target.z = 0;
        agent.SetDestination(target);
        agent.isStopped = false;
        //agent.SetDestination(new Vector3(0,0,0));


    }

    public void Move(InputAction.CallbackContext context)
    {
        agent.enabled = false;
        moveInput = context.ReadValue<Vector2>();
    }
}
