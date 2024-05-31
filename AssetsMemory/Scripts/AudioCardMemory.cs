using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCardMemory : MonoBehaviour
{
    public AudioClip matchCard;
   
    public AudioClip incioGame;
    public AudioClip gameMusic;
    public AudioClip flipCard;
    public AudioClip flipCard_2;
    public AudioSource audioSource;
    public AudioSource matchSource;
    public AudioSource flipSource;

    // Start is called before the first frame update
    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
        matchSource.clip = matchCard;
        flipSource.clip = flipCard_2;
        audioSource.clip = gameMusic;
        audioSource.Play();
        
    }
    public void MatchCard()
    {
        audioSource.PlayOneShot(matchCard);
    }
    public void FlipCard()
    {
        audioSource.PlayOneShot(flipCard);
    }
    public void FlipCard2()
    {
        audioSource.PlayOneShot(flipCard_2);
    }
 
    public void InicioGame()
    {
        audioSource.PlayOneShot(incioGame);
    }
    public void PauseMusic()
    {
        audioSource.Stop();
    }
}
