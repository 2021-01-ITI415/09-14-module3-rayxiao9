using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip splashSound;

    public AudioSource audioS;

    public AudioMixerSnapshot idleSnapshot;
    public AudioMixerSnapshot auxInSnapshot;
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Water")) {
            audioS.PlayOneShot(splashSound);
        }
        if (other.CompareTag("EnemyZone")) {
            auxInSnapshot.TransitionTo(0.5f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Water")) {
            audioS.PlayOneShot(splashSound);
        }
        if (other.CompareTag("EnemyZone")) {
            idleSnapshot.TransitionTo(0.5f);
        }
    }
}