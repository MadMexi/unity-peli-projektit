using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float gameTime = 30f;
    public bool isGameActive = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // s�ilyy scenejen v�lill�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        score = 0;
        gameTime = 30f;
        isGameActive = true;
        SceneManager.LoadScene("GameScene");
    }

    public void EndGame()
    {
        isGameActive = false;
        SceneManager.LoadScene("EndScene");
    }

    public void QuitGame()  //Toimii vain Buildatuissa peleiss�
    {
        Application.Quit();
    }
}