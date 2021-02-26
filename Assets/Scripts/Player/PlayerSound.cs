using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerSound : MonoBehaviour {
    public PlayerMovement playerMovement;
    public AudioSource audioSource;

    public List<AudioClip> footstepsSounds  = new List<AudioClip>();

    void Start() {

    }

    void Update () {
    }

    public AudioClip GetNextSound()
    {
    var randomIndex = UnityEngine.Random.Range(0, 5);
    return footstepsSounds[randomIndex];
    }

    public AudioClip GetJumpLandingSound()
    {
        return footstepsSounds[5];
    }
 }
