using UnityEngine;
using System.Collections.Generic;

using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public Transform gun;
    private float shootAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            shootAngle = 90;
        }
        if (Input.GetKey(KeyCode.A))
        {
            shootAngle = 180;
        }
        if (Input.GetKey(KeyCode.S))
        {
            shootAngle = 270;
        }
        if (Input.GetKey(KeyCode.D))
        {
            shootAngle = 0;
        }
        gun.eulerAngles = new Vector3(0, 0, shootAngle);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject go = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(0,0,shootAngle));
            Destroy(go, 10);
        }

    }
}
