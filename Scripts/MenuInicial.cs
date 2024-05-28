using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    enum scenes {
        menu = 0,
        safari = 1,
        trivia = 2,
        roulette = 3,
        memoria = 4,
    }

    [SerializeField] scenes numberScene;
    void Start ()
    {
        // Scene[] scenes = SceneManager.GetAllScenes();
    }
    public void ChooseScene()
    {
        // int actualScene = scenes.numberScene;
        SceneManager.LoadScene((int)numberScene);
        Debug.Log(numberScene);
    }
}
