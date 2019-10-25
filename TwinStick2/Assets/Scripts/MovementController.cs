using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    public float speed = 6.0f;
    public static MovementController instance;
    private Vector3 moveDirection = Vector3.zero;
    private NavMeshAgent agent;

    private bool inventoryOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryOpen = !inventoryOpen;
        }

        Vector3 PlayerDirection = new Vector3();
        if (GlobalVariables.controller)
        {
            //Rotate Character
            PlayerDirection = Vector3.right * Input.GetAxis("RHorizontal") + Vector3.forward * -Input.GetAxis("RVertical");
        }
        else if (!GlobalVariables.controller)
        {
            PlayerDirection = Vector3.right * Input.GetAxis("Mouse X") + Vector3.forward * -Input.GetAxis("Mouse Y");
        }

        if (PlayerDirection.sqrMagnitude > 0.0f)
        {
            transform.LookAt(transform.position + PlayerDirection);
        }

        if (!inventoryOpen)
        {
            //Move Character
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            //agent.Move(moveDirection*Time.deltaTime);
            agent.velocity = moveDirection;
        }
    }



}
