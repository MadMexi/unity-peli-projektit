using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public Transform gun1;
    private float shootAngle;
    public int AmmoInClip;
    public int MaxAmmo;
    public float ReloadTime;
    private Coroutine ReloadCoroutine;
    private UI_Manager uimanager;
    public int Health = 100;
    public KeyCode MoveUp = KeyCode.UpArrow;
    public KeyCode MoveDown = KeyCode.DownArrow;
    public KeyCode MoveRight = KeyCode.RightArrow;
    public KeyCode MoveLeft = KeyCode.LeftArrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uimanager = FindFirstObjectByType<UI_Manager>();
        uimanager.BulletText.text = "Bullets: " + AmmoInClip + "/" + MaxAmmo;
        uimanager.HealthText.text = "Health: " + Health;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(MoveUp))
        {
            shootAngle = 90;
            Shooting();
        }
        if (Input.GetKeyDown(MoveLeft))
        {
            shootAngle = 180;
            Shooting();
        }
        if (Input.GetKeyDown(MoveDown))
        {
            shootAngle = 270;
            Shooting();
        }
        if (Input.GetKeyDown(MoveRight))
        {
            shootAngle = 0;
            Shooting();
        }
    }

    void Shooting()
    {
        gun1.eulerAngles = new Vector3(0, 0, shootAngle);
        if (ReloadCoroutine == null)
        {
            GameObject go = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.Euler(0, 0, shootAngle));
            Destroy(go, 10);
            AmmoInClip -= 1;
            uimanager.BulletText.text = "Bullets: " + AmmoInClip + "/" + MaxAmmo;

            if (AmmoInClip <= 0)
            {
                ReloadCoroutine = StartCoroutine(Reload());
            }
        }
        
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadTime);
        AmmoInClip = MaxAmmo;
        ReloadCoroutine = null;
        uimanager.BulletText.text = "Bullets: " + AmmoInClip + "/" + MaxAmmo;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("Enemy");
        if (other.gameObject.tag == "Enemy")
        {
            Health -= 10;
            if (Health <= 0)
            {
                GameManager.Instance.EndGame();
            }
            uimanager.HealthText.text = "Health: " + Health;
        }
    }
}
