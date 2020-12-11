using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PistolAmmo lowerPistolAmmo;
    //int getPistolAmmo = GameObject.Find("PistolAmmo").GetComponent<PistolAmmo>().maxReserveAmmo;
    public PistolAmmo getReserveAmmo;
    public Text pistolAmmoUI;
    public Text pistolReserveAmmoUI;
    int ReserveAmmo;
    public int AmmoLimit;
    public int ReloadAmmo;

    public float bulletForce = 20f;

    public int maxAmmo = 15;
    //public int maxReserveAmmo = 45;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public float fireRate = 1f;
    private float timeToFire = 0f;

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
        pistolAmmoUI.text = currentAmmo.ToString();
        pistolReserveAmmoUI.text = ReserveAmmo.ToString();

        //Add bool that determines if the weapon is picked up


        if(isReloading)
        {
            return;
        }

        if(ReserveAmmo > 0)
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

        if(ReserveAmmo <= 0 && currentAmmo <= 0)
        {
            return;
        } 

        if (Input.GetButtonDown("Fire1") && Time.time >= timeToFire)
        {
            if (gameObject.activeSelf)
            {
                timeToFire = Time.time + 3f / fireRate;
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
        lowerPistolAmmo.DecreasePistolAmmo();
        //maxReserveAmmo-= maxAmmo;

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