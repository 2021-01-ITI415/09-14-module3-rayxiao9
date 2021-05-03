using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FirstPersonPlayerAudio : MonoBehaviour
{
    public AudioClip splashSound;

    public AudioSource audioS;

    public AudioMixerSnapshot ambIdleSnapshot;
    public AudioMixerSnapshot ambInSnapshot;
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Water")) {
            audioS.PlayOneShot(splashSound);
        }
        if (other.CompareTag("Ambience")) {
            ambInSnapshot.TransitionTo(0.5f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Ambience")) {
            ambIdleSnapshot.TransitionTo(0.5f);
        }
    }
}
