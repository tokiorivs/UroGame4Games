using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    enum scenes {
        menu = 0,
        memoria = 1,
        roulette = 2,
        trivia = 3,
        creditos = 4,
    }

    [SerializeField] scenes numberScene;
    void Start ()
    {
        // Scene[] scenes = SceneManager.GetAllScenes();
    }
    public void ChooseScene()
    {
        // int actualScene = scenes.numberScene;
        Debug.Log("hola mundooooooo");
        SceneManager.LoadScene((int)numberScene);
        Debug.Log(numberScene);
    }
}
