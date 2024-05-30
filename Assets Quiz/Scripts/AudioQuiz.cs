using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioQuiz : MonoBehaviour
{
    public AudioClip matchSFX;
    public AudioClip missSFX  ;
    public AudioClip gameMusic;

    public AudioSource audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void MatchSfx()
    {
        audioSource.PlayOneShot(matchSFX);
    }
    public void MissSfx()
    {
        audioSource.PlayOneShot(missSFX);
    }
  
}
