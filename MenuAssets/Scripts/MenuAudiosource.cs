using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudiosource : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip musisBackground;
    [SerializeField] AudioClip buttonSound;
    void Start()
    {
       audioSource.Play(); 
    }
    private void ButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }

}
