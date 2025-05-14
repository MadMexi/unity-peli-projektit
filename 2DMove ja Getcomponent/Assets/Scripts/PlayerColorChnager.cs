

using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer otherRenderer = collision.GetComponent<SpriteRenderer>();
        if (otherRenderer != null)
        {
            spriteRenderer.color = otherRenderer.color;
        }
    }
}
