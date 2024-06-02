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
       audioSource.clip = musisBackground;
       audioSource.Play(); 
    }
    public void ButtonSound()
    {
        Debug.Log("soy el sonido ");
        audioSource.PlayOneShot(buttonSound);
    }

}
