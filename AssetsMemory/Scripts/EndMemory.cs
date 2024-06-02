using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndMemory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalMessage;
    CardManager cardManager;
    AudioCardMemory audioCardMemory;
    EndSoundsEffects endSoundsEffects;
    StatesManager statesManager;
    bool gameLose;
    bool gameEnd = false;
    bool verify = false;

    void Start()
    {
        // cardManager = FindObjectOfType<CardManager>();
        statesManager = FindObjectOfType<StatesManager>();
        audioCardMemory = FindObjectOfType<AudioCardMemory>();
        endSoundsEffects = FindObjectOfType<EndSoundsEffects>();

        endSoundsEffects.MusicBackground();
        audioCardMemory.PauseMusic();
        endSoundsEffects.MusicBackground();
    }
    void Update()
    {
        if(gameEnd = statesManager.gameEnd && !verify)
        {

            if(gameLose = statesManager.gameLose)
            {
                // Debug.Log("loser");
                LoseMessage();
                verify = true;
                Debug.Log("verifiacnado " + verify);

            }
            else
            {
                // Debug.Log("winner");
                WinMessage();
                verify = true;
                Debug.Log("verifiacnado " + verify);
            }
        }

    }

    public void WinMessage()
    {
        endSoundsEffects.WinGame();
        finalMessage.text    = "Felicitaciones Ganaste";
    }
    public void LoseMessage()
    {
        endSoundsEffects.LoseGame();
        finalMessage.text = "Gracias por participar";
    }
}
