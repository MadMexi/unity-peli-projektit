using UnityEngine;
using TMPro;
public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI BulletText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HealthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeText.text = "Timer: " + GameManager.Instance.gameTime.ToString("f0");
        ScoreText.text = "Score: " + GameManager.Instance.score;
    }
}
