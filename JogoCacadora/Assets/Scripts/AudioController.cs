using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceBackground;
    public AudioClip [] BackgroundMusicas;
    // Start is called before the first frame update
    void Start()
    {
        AudioClip Background = BackgroundMusicas[0];
        audioSourceBackground.clip = Background;
        audioSourceBackground.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
