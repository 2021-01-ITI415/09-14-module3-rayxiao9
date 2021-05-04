using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class FirstPersonPlayerAudio : MonoBehaviour
{
    public AudioClip splashSound;

    public AudioClip pickUpSound;

    public AudioClip victorySound;

    public AudioSource audioS;

    public AudioMixerSnapshot ambIdleSnapshot;
    public AudioMixerSnapshot ambInSnapshot;
    public AudioMixerSnapshot finishedSnapshot;

    private int tokens = 0;
    public Text tokenCounter, finishedText, collectAllText;
    private bool finished = false;
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Water")) {
            audioS.PlayOneShot(splashSound);
        }
        if (other.CompareTag("Ambience")) {
            ambInSnapshot.TransitionTo(0.5f);
        }
        if (other.CompareTag("PickUp")) {
            audioS.PlayOneShot(pickUpSound);
            ambIdleSnapshot.TransitionTo(0.5f);
            Destroy(other.gameObject);
            tokens++;
            tokenCounter.text = "Tokens Collected " + tokens;
            if (tokens == 1) {
                tokenCounter.gameObject.SetActive(false);
                collectAllText.gameObject.SetActive(true);
                finished = true;
                finishedSnapshot.TransitionTo(0.5f);
                audioS.PlayOneShot(victorySound);
                Invoke("ReloadLevel", 4f);
            }
        }
        if (other.CompareTag("Fin") && !finished) {
            finishedSnapshot.TransitionTo(0.5f);
            audioS.PlayOneShot(victorySound);
            tokenCounter.gameObject.SetActive(false);
            if (tokens == 1) {
                finishedText.text = "You Finished with\n" + tokens + "\nToken!";
            } else {
                finishedText.text = "You Finished with\n" + tokens + "\nTokens!";
            }
            finishedText.gameObject.SetActive(true);
            Invoke("ReloadLevel", 4f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Ambience")) {
            ambIdleSnapshot.TransitionTo(0.5f);
        }
    }

    void Awake() {
        SetUpUITexts();
    }

    void SetUpUITexts() {
        GameObject go = GameObject.Find("Tokens");
        if (go != null) {
            tokenCounter = go.GetComponent<Text>();
        }

        go = GameObject.Find("Finish Text");
        if (go != null) {
            finishedText = go.GetComponent<Text>();
        }

        go = GameObject.Find("Collected All Text");
        if (go != null) {
            collectAllText = go.GetComponent<Text>();
        }

        finishedText.gameObject.SetActive(false);
        collectAllText.gameObject.SetActive(false);
    }

    void ReloadLevel() {
        SceneManager.LoadScene("07-Prototype3");
    }
}
