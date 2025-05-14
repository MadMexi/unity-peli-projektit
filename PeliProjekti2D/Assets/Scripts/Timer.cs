using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text timerText;

    private void Update()
    {
        if (GameManager.Instance.isGameActive)
        {
            GameManager.Instance.gameTime -= Time.deltaTime;
            timerText.text = "Aikaa jäljellä: " + Mathf.Ceil(GameManager.Instance.gameTime).ToString();

            if (GameManager.Instance.gameTime <= 0)
            {
                GameManager.Instance.EndGame();
            }
        }
    }
}