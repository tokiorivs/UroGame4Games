using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float gameTimer = 10f;
    public bool gameEnd = false;


    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        gameTimer = 0f;
    }
    void UpdateTimer()
    {
        if (!gameEnd)
        {
            gameTimer -= Time.deltaTime; // Restar el tiempo transcurrido
            if (gameTimer <= 0f)
            {
                gameEnd = true;
                Debug.Log("perdiste");
                Debug.Log("el gameOver se cambio a " + gameEnd);
                timerText.text = "--:--";
                

            }
            else
            {
                // Convertir tiempo a formato de minutos y segundos
                int minutes = Mathf.FloorToInt(gameTimer / 60f);
                int seconds = Mathf.FloorToInt(gameTimer % 60f);

                // Actualizar el texto del temporizador
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }


        }
    }
    public bool GetGameOverState()
    {
        return gameEnd;
    }
}
