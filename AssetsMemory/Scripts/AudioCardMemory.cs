using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCardMemory : MonoBehaviour
{
    public AudioClip matchCard;
    public AudioClip missCard;
    public AudioClip gameMusic;
    public AudioClip flipCard;
    public AudioClip flipCard_2;
    public AudioSource audioSource;
    public AudioSource effectSource;

    // Start is called before the first frame update
    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameMusic;
        audioSource.Play();
        
    }
    public void MatchCard()
    {
        audioSource.PlayOneShot(matchCard);
    }
    public void MissCard()
    {
        audioSource.PlayOneShot(missCard);
    }
    public void FlipCard()
    {
        audioSource.PlayOneShot(flipCard);
    }
    public void FlipCard2()
    {
        audioSource.PlayOneShot(flipCard_2);
    }
}
