using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MovieCtrlW5 : MonoBehaviour
{
    VideoPlayer vp;
    public ParticleSystem ps;
    
    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        //ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (vp.isPlaying)
            {
                vp.Pause();
            }
            else
            {
                vp.Play();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (ps.isPlaying)
            {
                ps.Stop();
            }
            else
            {
                ps.Play();
            }
        }
    }

    public void OnFound()
    {
        vp.Play();
        ps.Play();
    }
    public void OnLost()
    {
        vp.Pause();
        ps.Pause();
    }
}
