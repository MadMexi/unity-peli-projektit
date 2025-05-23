using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public AudioSource audioSource;
    public float moveSpeed = 3;
    private Transform player;
    public GameObject EffectOnDestroyPrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            if (EffectOnDestroyPrefab)
            {
                Instantiate(EffectOnDestroyPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject, 0.2f);
        }

        if (other.gameObject.tag == "Bullet")
        {
            GameManager.Instance.score += 1;
            //Debug.Log("osuma");
            audioSource.Play(); // Toista kuolemis ‰‰ni
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(other.gameObject); //Tuhoa tˆrm‰tty objekti
            if (EffectOnDestroyPrefab)
            {
                Instantiate(EffectOnDestroyPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject,0.2f); //Tuhoaa itsens‰
        }
        
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Vector3 offset = transform.position - player.position; //Muutetaan koordinaatteja niin, ett‰ pelaajan suhde viholliseen on sama kuin nollapisteen suhde muutettuun.
        Vector3 normalisointi = offset.normalized; //Rajoitetaan pituus 1:een, jolloin normalisoitu on vain suunta.
        Vector3 dir = normalisointi * -1; //K‰‰nnet‰‰n oikeaan suuntaan

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
      

}
