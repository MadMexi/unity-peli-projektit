using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    private bool color = true;
    void Update()
    {
        // Heitä säde eteenpäin objektin nykyisestä sijainnista
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Tarkistetaan, osuuko säde johonkin 4 yksikön säteellä
        if (Physics.Raycast(ray, out hit, 4f))
        {
            Debug.Log("Osui kohteeseen: " + hit.collider.name);
            if (color)
            {
                // Voit tehdä tässä jotain objektin kanssa, esim. muuttaa väriä
                hit.collider.GetComponent<Renderer>().material.color = Color.blue;

            }
            else
            {
                hit.collider.GetComponent<Renderer>().material.color = Color.red;

            }
            color = !color;

        }

        // Piirrä säde näkymäksi Scene-näkymässä (debuggausta varten)
        Debug.DrawRay(transform.position, transform.forward * 2f, Color.green);
    }
}