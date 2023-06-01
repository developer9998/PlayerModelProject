using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recordsamples : MonoBehaviour
{

    public int samplerate;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        Time.captureFramerate = samplerate;
        deltatime = Time.deltaTime * samplerate;
    }

    float deltatime;
    float nexttime;
    private void Update()
    {

    }
        
    void FixedUpdate()
    {
        
    }
}
