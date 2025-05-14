using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}