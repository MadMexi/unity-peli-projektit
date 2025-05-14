
using UnityEngine;

public class Vector3Demo : MonoBehaviour
{
    public Transform target; // Toinen objekti, johon verrataan (asetetaan Inspectorissa)

    void Start()
    {
        // 1. Aseta sijainti
        transform.position = new Vector3(0f, 1f, 0f);
        Debug.Log("Sijainti asetettu: " + transform.position);

        // 2. Aseta asento Euler-kulmilla (kääntyy 90 astetta y-akselin ympäri)
        transform.eulerAngles = new Vector3(0f, 90f, 0f);
        Debug.Log("Asento (Euler): " + transform.eulerAngles);

        // 3. Aseta koko (skaala)
        transform.localScale = new Vector3(2f, 2f, 2f);
        Debug.Log("Skaala: " + transform.localScale);

        // 4. Liikuta oikealle (vain Startissa testiksi)
        transform.position += Vector3.right * 2f;
        Debug.Log("Liikuttu oikealle: " + transform.position);


    }

    void Update()
    {
        // 5. Suunta kohteeseen ja etäisyys
        if (target != null)
        {
            Vector3 suunta = (target.position - transform.position).normalized;
            float etaisyys = Vector3.Distance(transform.position, target.position);

            Debug.Log("Suunta kohteeseen: " + suunta);
            Debug.Log("Etäisyys kohteeseen: " + etaisyys);
        }
        // 6. Liiku jatkuvasti eteenpäin (z-akselia pitkin)
        // transform.position += Vector3.forward * Time.deltaTime;

        // 7. Voit testata suunnan myös näppäimillä (esim. wasd-liike)
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        transform.position += input.normalized * 5f * Time.deltaTime;
        Debug.Log("Sijainti: " + transform.position);

    }
}
