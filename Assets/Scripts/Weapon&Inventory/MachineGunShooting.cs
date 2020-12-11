using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGunShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public MachineGunAmmo lowerMachineGunAmmo;
    public MachineGunAmmo getReserveAmmo;
    public Text MachineGunAmmoUI;
    public Text MachineGunReserveAmmoUI;
    int ReserveAmmo;
    public int ReloadAmmo;
    public int AmmoLimit;

    public float bulletForce = 20f;
    private float timeToFire = 0f;
    public int maxAmmo = 50;
    public int maxReserveAmmo = 150;
    public int currentAmmo;
    public float reloadTime = 1f;
    public float fireRate = 8f;
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
        MachineGunAmmoUI.text = currentAmmo.ToString();
        MachineGunReserveAmmoUI.text = ReserveAmmo.ToString();

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

        if (Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            if (gameObject.activeSelf)
            {
                timeToFire = Time.time + 2f / fireRate;
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

        yield return new WaitForSeconds(1.2f);
        Destroy(bullet);
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(1);

        ReloadAmmo = maxAmmo - currentAmmo;
        AmmoLimit = currentAmmo + getReserveAmmo.maxReserveAmmo;
        lowerMachineGunAmmo.DecreaseMachineGunAmmo();
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

    /*(public void AddAmmo()
    {
        maxReserveAmmo += maxAmmo;
        Debug.Log("Ammo Added!");
    }*/
}