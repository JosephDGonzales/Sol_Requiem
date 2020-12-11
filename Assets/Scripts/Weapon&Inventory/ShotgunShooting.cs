using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public ShotgunAmmo lowerShotgunAmmo;
    public ShotgunAmmo getReserveAmmo;
    public Text ShotgunAmmoUI;
    public Text ShotgunReserveAmmoUI;
    int ReserveAmmo;
    public int ReloadAmmo;
    public int AmmoLimit;

    public float bulletForce = 20f;
    private float timeToFire = 1f;
    public int maxAmmo = 7;
    public int maxReserveAmmo = 21;
    public int currentAmmo;
    public float reloadTime = 1f;
    public float fireRate = 1f;
    private bool isReloading = false;

    void Start()
    {
        currentAmmo = maxAmmo;
        ReserveAmmo = getReserveAmmo.maxReserveAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        ReserveAmmo = getReserveAmmo.maxReserveAmmo;
        ShotgunAmmoUI.text = currentAmmo.ToString();
        ShotgunReserveAmmoUI.text = ReserveAmmo.ToString();

        if (isReloading)
        {
            return;
        }

        if (ReserveAmmo > 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }

            if (currentAmmo == 0)
            {
                StartCoroutine(Reload());
            }    
        }

        if (ReserveAmmo <= 0 && currentAmmo <= 0)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= timeToFire)
        {
            if (gameObject.activeSelf)
            {
                timeToFire = Time.time + 2.5f / fireRate;
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        currentAmmo--;

        yield return new WaitForSeconds(0.4f);
        Destroy(bullet);
    }


    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(1);

        ReloadAmmo = maxAmmo - currentAmmo;
        AmmoLimit = currentAmmo + getReserveAmmo.maxReserveAmmo;
        lowerShotgunAmmo.DecreaseShotgunAmmo();
        //maxReserveAmmo -= maxAmmo;

        if (getReserveAmmo.maxReserveAmmo >= maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        else if (getReserveAmmo.maxReserveAmmo < maxAmmo && AmmoLimit >= maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        else if (getReserveAmmo.maxReserveAmmo < maxAmmo && AmmoLimit < maxAmmo)
        {
            currentAmmo = AmmoLimit;
        }

        if (currentAmmo <= 0)
        {
            currentAmmo = 0;
        }

        isReloading = false;
    }

    /*public void AddAmmo()
    {
        maxReserveAmmo += maxAmmo;
        Debug.Log("Ammo Added!");
    }*/
}