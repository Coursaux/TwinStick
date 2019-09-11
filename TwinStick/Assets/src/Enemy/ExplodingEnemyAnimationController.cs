using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemyAnimationController : MonoBehaviour
{
    private Animator controller;

    private ExplodingEnmemy parent;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponentSafely<Animator>();
        parent = gameObject.GetComponentInParent<ExplodingEnmemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.exploding)
        {
            controller.SetBool("IsExploding", true);
        }
    }
}
