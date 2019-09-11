using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audioscript : MonoBehaviour
{

    public AudioClip Engine;

    public AudioSource source;

    private bool playing;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = Engine;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            source.Play();
            playing = true;
        }

    }
}
