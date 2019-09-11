using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayText : MonoBehaviour
{
    public GameObject buttons;
    public GameObject Credits;
    public GameObject title;
    public CanvasGroup cGroup;
    float TmStart;
    float TmLen = 12;

    // Use this for initialization
    void Start()
    {
        TmStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float timeRatio = Time.time / (TmStart + TmLen);
        if (Time.time > TmStart + TmLen)
        {
            Credits.SetActive(false);
            buttons.SetActive(true);
            title.SetActive(true);
        }
        else
        {
            cGroup.alpha = timeRatio;
        }
    }
}
