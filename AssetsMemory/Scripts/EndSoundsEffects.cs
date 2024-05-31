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
    }
    public void LoseGame()
    {
        audioSource.clip = loseGame;
    }
    public void MusicBackground()
    {
        musicBackground.PlayOneShot(endGame);
    }
}
