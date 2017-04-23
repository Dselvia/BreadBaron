using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayVideo : MonoBehaviour {
    public MovieTexture movie1;
    public AudioSource audio;
	// Use this for initialization
	void Start () {
        GetComponent<RawImage>().texture = movie1 as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie1.audioClip;

        movie1.Play();
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) && movie1.isPlaying)
            movie1.Pause();
        else if (Input.GetKeyDown(KeyCode.P) && !movie1.isPlaying)
            movie1.Play();
    }

    public void StartMovie()
    {
        if (movie1.isPlaying)
            movie1.Play();
        else if (!movie1.isPlaying)
            movie1.Pause();
    }
  
}
