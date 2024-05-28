using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeToMatch = 10f;
    public float currentTimeToMatch = 0;

    public enum GameState
    {
        Idle,
        LevelSelection,
        InGame,
        GameOver,
        Pause,
        Options
    }

    public GameState gameState;

    public int Points = 0;
    public UnityEvent OnPointsUpdated;
    public UnityEvent<GameState> OnGameStateUpdated;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (gameState == GameState.InGame)
        {
            currentTimeToMatch += Time.deltaTime;
            if (currentTimeToMatch > timeToMatch)
            {
                gameState = GameState.GameOver;
                OnGameStateUpdated?.Invoke(gameState);
            }
        }
    }

    public void AddPoints(int newPoints)
    {
        Points += newPoints;
        OnPointsUpdated?.Invoke();
        currentTimeToMatch = 0;
    }

    public void StartGame()
    {
        Points = 0;
        gameState = GameState.InGame;
        OnGameStateUpdated?.Invoke(gameState);
        currentTimeToMatch = 0;
    }

    public void RestartGame()
    {
        Points = 0;
        gameState = GameState.InGame;
        OnGameStateUpdated?.Invoke(gameState);
        currentTimeToMatch = 0f;
    }

    public void ExitGame()
    {
        Points = 0;
        gameState = GameState.Idle;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void LevelSelection()
    {
        gameState = GameState.LevelSelection;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void Idle()
    {
        gameState = GameState.Idle;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void Options()
    {
        gameState = GameState.Options;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void Pause()
    {
        gameState = GameState.Pause;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void ContinueGame()
    {
        gameState = GameState.InGame;
        OnGameStateUpdated?.Invoke(gameState);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
