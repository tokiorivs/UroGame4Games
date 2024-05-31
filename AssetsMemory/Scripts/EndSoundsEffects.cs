using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSoundsEffects : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource musicBackground;
    public AudioClip loseGame;
    public AudioClip winGame;
    public AudioClip endGame;


   public void WinGame()
    {
        audioSource.clip = winGame  ;
        audioSource.Play();
    }
    public void LoseGame()
    {
        audioSource.clip = loseGame;
        audioSource.Play();
    }
    public void MusicBackground()
    {
        musicBackground.clip =endGame;
        musicBackground.Play();
    }
}
