using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.score += 1;
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject); //Tuhoa t�rm�tty objekti
        }
        Destroy(gameObject); //Tuhoaa itsens�
    }
    public float moveSpeed = 3;
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Vector3 offset = transform.position - player.position; //Muutetaan koordinaatteja niin, ett� pelaajan suhde viholliseen on sama kuin nollapisteen suhde muutettuun.
        Vector3 normalisointi = offset.normalized; //Rajoitetaan pituus 1:een, jolloin normalisoitu on vain suunta.
        Vector3 dir = normalisointi * -1; //K��nnet��n oikeaan suuntaan

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

}
