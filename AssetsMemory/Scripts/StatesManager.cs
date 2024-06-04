using UnityEngine;
using UnityEngine.SceneManagement;

public class StatesManager : MonoBehaviour
{
[SerializeField] CardManager cardManager;
[SerializeField] EndMemory gameEndWindow;
public bool gameLose;
public bool gameEnd;
    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();
        gameEndWindow = FindObjectOfType<EndMemory>();
        cardManager.gameObject.SetActive(true);
        gameEndWindow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cardManager.gameEnd)
        {
            gameEnd = cardManager.gameEnd;
            GameEndWindow();
        }
        
    }
    public void GameEndWindow()
    {
        cardManager.gameObject.SetActive(false);
        gameEndWindow.gameObject.SetActive(true);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
}
