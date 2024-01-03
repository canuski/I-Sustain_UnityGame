using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPart : MonoBehaviour
{
    public AudioSource collectSound;
    void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        ScoringSystem.theScore++;
        Destroy(gameObject);
    }
}
