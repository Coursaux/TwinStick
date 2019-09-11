using System.Collections;
using System.Collections.Generic;
using Missive_CSharp;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    public float speed = 6.0f;
    public static MovementController instance;
    private Vector3 moveDirection = Vector3.zero;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponentSafely<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Rotate Character
        var PlayerDirection = Vector3.right * Input.GetAxis("RHorizontal") + Vector3.forward * -Input.GetAxis("RVertical");

        if (PlayerDirection.sqrMagnitude > 0.0f)
        {
            transform.LookAt(transform.position + PlayerDirection);
        }
        
        //Move Character
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;
        
        //agent.Move(moveDirection*Time.deltaTime);
        agent.velocity = moveDirection;
    }

    
        
}
