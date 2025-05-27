using UnityEngine;


public class PlayerMovement2 : MonoBehaviour
{
    public float speed = 5f;


    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");


        transform.position += new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime;
    }
}