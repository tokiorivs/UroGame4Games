using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdmin : MonoBehaviour
{
    public float timeToMatch = 10f;
    public float CurrentTimeToMatch = 0;

    public enum GameState {
        Idle,
        InGame,
        GameOver,
    }
    public GameState gameState;
   
}
