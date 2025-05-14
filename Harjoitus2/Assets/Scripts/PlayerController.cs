using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask wallLayer;
    void Update()
    {
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDir = Vector3.forward;
        else if (Input.GetKey(KeyCode.S))
            moveDir = Vector3.back;
        else if (Input.GetKey(KeyCode.A))
            moveDir = Vector3.left;
        else if (Input.GetKey(KeyCode.D))
            moveDir = Vector3.right;

        if (moveDir != Vector3.zero)
        {
            float moveDistance = moveSpeed * Time.deltaTime;
            Vector3 origin = transform.position;

            // Raycast tarkistaa törmääkö suunnassa, johon pelaaja on liikkumassa
            if (!Physics.Raycast(origin, moveDir, moveDistance + 0.6f, wallLayer))
            {
                //Käytetään Space.World, jotta liike on riippumaton objektin rotaatiosta.
                transform.Translate(moveDir * moveDistance, Space.World);
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Debug.Log("Osuit Collision!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Osuit Trigger!");
            Destroy(other.gameObject);
            Debug.Log("Pallo poistettiin!");
        }

    }
    
}