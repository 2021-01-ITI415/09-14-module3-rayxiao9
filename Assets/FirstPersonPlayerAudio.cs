using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayerAudio : MonoBehaviour
{
    public AudioClip splashSound;

    public AudioSource audioS;
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Water")) {
            audioS.PlayOneShot(splashSound);
        }
    }
}
