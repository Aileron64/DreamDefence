using UnityEngine;
using System.Collections;

public class SelectTrack : MonoBehaviour
{
    public float maxVolume;
    public int selectedTrack;
    public AudioClip[] tracks;
    AudioSource audio;
	// Use this for initialization
	void Start ()
    { 
        if(gameObject.GetComponent<AudioSource>() == null)
        {
            Debug.LogError(gameObject.name + " must have an Audio Source attached!");
        }
        audio = gameObject.GetComponent<AudioSource>();
        audio.volume = maxVolume;
        PlayTrack();
	}
    
    public void PlayTrack()
    {
        audio.clip = tracks[selectedTrack];
        audio.Play();
    }
}
