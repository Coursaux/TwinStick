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
        //Cursor.visible = false;
        agent = gameObject.GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<HealthManager>().dead)
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

                if (PlayerDirection.sqrMagnitude > 0.0f)
                {
                    transform.LookAt(transform.position + PlayerDirection);
                }
            }
            else if (!GlobalVariables.controller)
            {
                Vector2 mouse = Input.mousePosition;
                Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
                mouse -= center;
                Vector3 rotation = new Vector3(0, -Mathf.Rad2Deg * Mathf.Atan(mouse.y / mouse.x) + 90, 0);
                if (mouse.x < 0)
                {
                    rotation = new Vector3(0, -Mathf.Rad2Deg * Mathf.Atan(mouse.y / mouse.x) + 270, 0);
                }
                transform.rotation = Quaternion.Euler(rotation);
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
}
