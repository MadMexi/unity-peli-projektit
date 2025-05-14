using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    private bool color = true;
    void Update()
    {
        // Heit� s�de eteenp�in objektin nykyisest� sijainnista
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Tarkistetaan, osuuko s�de johonkin 4 yksik�n s�teell�
        if (Physics.Raycast(ray, out hit, 4f))
        {
            Debug.Log("Osui kohteeseen: " + hit.collider.name);
            if (color)
            {
                // Voit tehd� t�ss� jotain objektin kanssa, esim. muuttaa v�ri�
                hit.collider.GetComponent<Renderer>().material.color = Color.blue;

            }
            else
            {
                hit.collider.GetComponent<Renderer>().material.color = Color.red;

            }
            color = !color;

        }

        // Piirr� s�de n�kym�ksi Scene-n�kym�ss� (debuggausta varten)
        Debug.DrawRay(transform.position, transform.forward * 2f, Color.green);
    }
}