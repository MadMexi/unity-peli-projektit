using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;          // Kohde, jota kohti halutaan katsoa
    public float rotationSpeed = 5f;  // Käännöksen nopeus

    void Update()
    {
        if (target == null) return;

        // Suunta kohteeseen
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // Estetään kallistuminen

        if (direction != Vector3.zero)
        {
            // Lasketaan haluttu rotaatio
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Smooth-käännös kohti kohdetta
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}