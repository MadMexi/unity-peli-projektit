using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        scoreText.text = "Sait " + GameManager.Instance.score + " pistett�!";
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}