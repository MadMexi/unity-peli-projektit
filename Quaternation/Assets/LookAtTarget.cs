using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;          // Kohde, jota kohti halutaan katsoa
    public float rotationSpeed = 5f;  // K��nn�ksen nopeus

    void Update()
    {
        if (target == null) return;

        // Suunta kohteeseen
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // Estet��n kallistuminen

        if (direction != Vector3.zero)
        {
            // Lasketaan haluttu rotaatio
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Smooth-k��nn�s kohti kohdetta
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}