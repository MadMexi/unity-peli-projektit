using UnityEngine;


public class SimpleMovement : MonoBehaviour
{
    public float speed = 5f;


    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        transform.position += new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
    }
}