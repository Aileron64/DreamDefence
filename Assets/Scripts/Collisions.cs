using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour
{
    AudioSource audio;
    public AudioClip hitSound;
	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = hitSound;
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
        audio.Play();
    }
}
