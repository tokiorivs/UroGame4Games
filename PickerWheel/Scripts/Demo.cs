using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;
using TMPro;
using System.Security.Permissions;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update [SerializeField] private Button uiSpiningButton;
    [SerializeField] private Button uiSpiningButton;
    [SerializeField] private TextMeshProUGUI uiSpinButtonText;
    [SerializeField] private PickerWheel pickerWheel;
    [SerializeField] private Sprite buttonPressed;
    [SerializeField] private Sprite button;
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip replySound;
    [SerializeField] private AudioClip loseSound;
    public AudioSource audioSource;
    private void Awake()
    {
        audioSource = pickerWheel.audioSource;
    }
    private void Start()
    {
        uiSpiningButton.onClick.AddListener(()=>
        {
            uiSpiningButton.interactable = false;
            uiSpinButtonText.text = "Girando";
            uiSpiningButton.image.sprite = buttonPressed; 
            audioSource.PlayOneShot(buttonSound);
            pickerWheel.OnSpinStart(()=>{
                Debug.Log("girando");

            });
            pickerWheel.OnSpinEnd(wheelPiece =>{
               Debug.Log("Spin en label "+ wheelPiece.Label+ " , Amount" + wheelPiece.Amount) ;
               uiSpiningButton.interactable = true;
               uiSpinButtonText.text = "Gira";
               uiSpiningButton.image.sprite = button;
               string code = wheelPiece.Label;
               Debug.Log("el codigo es " + code);
               Sounds(code);
            audioSource.PlayOneShot(buttonSound);

            });
            pickerWheel.Spin();
        });
    }
       private void Sounds(string code)
    {
        if(code == "Ganaste")
        {
            audioSource.PlayOneShot(winSound);
            uiSpinButtonText.text = "Ganaste!!!";
            Debug.Log("ganaste");
        }
        if(code == "Perdiste")
        {
            audioSource.PlayOneShot(loseSound);
            uiSpinButtonText.text = "Piña";
            Debug.Log("piña ");
        }
        if(code == "Again"){
            audioSource.PlayOneShot(replySound);
            uiSpinButtonText.text = "Vuelve a intentarlo";
            Debug.Log("vuelve a intentarlo");
        }

        if(code == "Premio")
        {
            audioSource.PlayOneShot(winSound);
            uiSpinButtonText.text = "Ganaste!!!";
        }
        if(code == "Piña")
        {
            audioSource.PlayOneShot(loseSound);
            uiSpinButtonText.text = "Piña";
        }
        if(code == "Gira"){
            audioSource.PlayOneShot(replySound);
            uiSpinButtonText.text = "Vuelve a intentarlo";
        }
        // else{
        //     uiSpinButtonText.text = "error horror";
        // }
    }


}
