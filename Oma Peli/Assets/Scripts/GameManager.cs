using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float gameTime = 1f;
    public bool isGameActive = false;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // säilyy scenejen välillä
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        score = 0;
        gameTime = 1f;
        isGameActive = true;
        SceneManager.LoadScene("GameScene");
    }

    public void EndGame()
    {
        isGameActive = false;
        SceneManager.LoadScene("EndScene");
    }

    public void QuitGame()  //Toimii vain Buildatuissa peleissä
    {
        Application.Quit();
    }



    private void Update()
    {
        gameTime += Time.deltaTime;
    }


}