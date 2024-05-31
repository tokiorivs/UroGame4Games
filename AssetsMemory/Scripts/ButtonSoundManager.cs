using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    [SerializeField] Button homeButton;
    [SerializeField] Button restartButton; 
    [SerializeField] AudioSource buttonsAudiosource;
    [SerializeField] AudioClip buttonSound;
    // // Start is called before the first frame update
    // private void Awake()
    // {
    //     buttonsAudiosource = FindObjectOfType<AudioSource>();
    // }
    private void Start()
    {
        buttonsAudiosource.Play();
      PlayButton(homeButton, buttonSound);
      PlayButton(restartButton, buttonSound); 
    }
    void PlayButton(Button button, AudioClip audioclip)
    {
          button.onClick.AddListener(()=>{
            buttonsAudiosource.PlayOneShot(audioclip);
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
