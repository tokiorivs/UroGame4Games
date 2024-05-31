using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndMemory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalMessage;
    CardManager cardManager;
    AudioCardMemory audioCardMemory;
    EndSoundsEffects endSoundsEffects;
    bool gameLose;
    bool gameOver;

    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
        audioCardMemory = FindObjectOfType<AudioCardMemory>();
        endSoundsEffects = FindObjectOfType<EndSoundsEffects>();
        endSoundsEffects.MusicBackground();
    }
    void Update()
    {
        if(gameLose)
        {
            LoseMessage();
            endSoundsEffects.LoseGame();
        }
        if(gameOver)
        {
            WinMessage();
            endSoundsEffects.WinGame();
        }
        else
        {
            WinMessage();
            endSoundsEffects.WinGame();
        }

    }

    public void WinMessage()
    {
        audioCardMemory.PauseMusic();
        finalMessage.text    = "Felicitaciones Ganaste";
    }
    public void LoseMessage()
    {
        audioCardMemory.PauseMusic();
        finalMessage.text = "Lo Sentimos, Perdiste";
    }
}
