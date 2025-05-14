using UnityEngine;

public class ClickableSquare : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Hiirtä painettu");
        if (GameManager.Instance.isGameActive)
        {
            Debug.Log("objetki tuhottu");
            GameManager.Instance.score++;
            Destroy(gameObject);
        }
    }
}