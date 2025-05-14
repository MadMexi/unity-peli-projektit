using UnityEngine;

public class RandomMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float waitTime = 1f;
    private float areaWidth = 5f;
    private float areaLength = 5f;

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        SetNewTarget();
    }

    void Update()
    {
        if (isMoving)
        {

            // Liikutaan kohdetta kohti
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Kun saavutetaan kohde
            if (Vector3.Distance(transform.position, targetPosition) < 0.6f)
            {
                isMoving = false;
                Invoke(nameof(SetNewTarget), waitTime);
            }
        }
    }

    void SetNewTarget()
    {
        // Satunnainen piste alueelta (keskiö keskellä)
        float x = Random.Range(-areaWidth / 2f, areaWidth / 2f);
        float z = Random.Range(-areaLength / 2f, areaLength / 2f);
        float y = transform.position.y; // pidetään korkeus samana
        Debug.Log(x + " " + y + " " + z);
        targetPosition = new Vector3(x, y, z);
        isMoving = true;
    }
}