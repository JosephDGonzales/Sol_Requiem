using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserGunShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public LaserGunAmmo lowerLaserGunAmmo;
    public LaserGunAmmo getReserveAmmo;
    public Text LaserGunAmmoUI;
    public Text LaserGunReserveAmmoUI;
    public Text LaserGunChargeTimeUI;
    int ReserveAmmo;
    public int ReloadAmmo;
    public int AmmoLimit;

    public float bulletForce = 20f;
    public float charge = 0f;
    private float maxCharge = 3f;
    public int maxAmmo = 4;
    public int maxReserveAmmo = 8;
    public int currentAmmo;
    public float reloadTime = 1f;
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
        LaserGunAmmoUI.text = currentAmmo.ToString();
        LaserGunReserveAmmoUI.text = ReserveAmmo.ToString();
        LaserGunChargeTimeUI.text = charge.ToString("0");

        if(charge >= 3)
        {
            LaserGunChargeTimeUI.text = "Ready to Fire!";
        }    

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

        if (Input.GetButton("Fire1"))
        {
            charge += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            if (gameObject.activeSelf)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        if(charge >= maxCharge)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            currentAmmo--;
            FindObjectOfType<AudioManagerGame>().Play("LaserFire");
            yield return new WaitForSeconds(1.2f);
            Destroy(bullet);
        }

        charge = 0f;
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(1);

        ReloadAmmo = maxAmmo - currentAmmo;
        AmmoLimit = currentAmmo + getReserveAmmo.maxReserveAmmo;
        lowerLaserGunAmmo.DecreaseLaserGunAmmo();
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

    public void AddAmmo()
    {
        maxReserveAmmo += maxAmmo;
        Debug.Log("Ammo Added!");
    }
}