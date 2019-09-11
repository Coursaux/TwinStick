using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget != null)
        {
            targetPos = new Vector3(followTarget.transform.position.x, transform.position.y, followTarget.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        
    }
}
