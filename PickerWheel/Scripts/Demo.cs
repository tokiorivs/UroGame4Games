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
    private void Start()
    {
        uiSpiningButton.onClick.AddListener(()=>
        {
            uiSpiningButton.interactable = false;
            uiSpinButtonText.text = "Girando";

            pickerWheel.OnSpinStart(()=>{
                Debug.Log("girando");

            });
            pickerWheel.OnSpinEnd(wheelPiece =>{
               Debug.Log("Spin en label "+ wheelPiece.Label+ " , Amount" + wheelPiece.Amount) ;
               uiSpiningButton.interactable = true;
               uiSpinButtonText.text = "Gira";

            });
            pickerWheel.Spin();
        });
    }
}
