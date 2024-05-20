using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;
using TMPro;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update [SerializeField] private Button uiSpiningButton;
    [SerializeField] private Button uiSpiningButton;
    [SerializeField] private TextMeshProUGUI uiSpinButtonText;
    [SerializeField] private PickerWheel pickerWheel;
    [SerializeField] private Sprite buttonPressed;
    [SerializeField] private Sprite button;
    [SerializeField] private AudioClip buttonSound;
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
            audioSource.PlayOneShot(buttonSound);

            });
            pickerWheel.Spin();
        });
    }
}
