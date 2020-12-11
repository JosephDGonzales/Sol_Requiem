using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChainSaw : MonoBehaviour
{
    public double fuel = 0;
    public double maxFuel = 100;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public ChainSawAmmo lowerChainsawAmmo;
    public ChainSawAmmo getReserveAmmo;
    public Text ChainsawAmmoUI;
    public Text ChainsawReserveAmmoUI;
    double ReserveAmmo;
    public double ReloadAmmo;
    public double AmmoLimit;

    // Start is called before the first frame update
    void Start()
    {
        fuel = maxFuel;
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
        ChainsawAmmoUI.text = fuel.ToString("F0");
        ChainsawReserveAmmoUI.text = ReserveAmmo.ToString("F2");

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

            if (fuel == 0)
            {
                StartCoroutine(Reload());
            }
        }

        if (ReserveAmmo <= 0 && fuel <= 0)
        {
            return;
        }

        if (Input.GetButton("Fire1") && fuel > 0)
        {
            StartCoroutine(depleteFuel());
        }

        if(fuel <= 0)
        {
            fuel = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Input.GetButton("Fire1") && fuel > 0)
        {
            Debug.Log("Hitting Enemy!");
            EnemyHealth sawEnemy = collision.gameObject.GetComponent<EnemyHealth>();
            sawEnemy.TakeDamage(25);
        }    
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(1);

        ReloadAmmo = maxFuel - fuel;
        AmmoLimit = fuel + getReserveAmmo.maxReserveAmmo;
        lowerChainsawAmmo.DecreaseChainsawAmmo();
        //maxReserveAmmo -= maxAmmo;

        if (getReserveAmmo.maxReserveAmmo >= maxFuel)
        {
            fuel = maxFuel;
        }
        else if (getReserveAmmo.maxReserveAmmo < maxFuel && AmmoLimit >= maxFuel)
        {
            fuel = maxFuel;
        }
        else if (getReserveAmmo.maxReserveAmmo < maxFuel && AmmoLimit < maxFuel)
        {
            fuel = AmmoLimit;
        }

        if (fuel <= 0)
        {
            fuel = 0;
        }

        isReloading = false;
    }

    IEnumerator depleteFuel()
    {
        yield return new WaitForSeconds(0);

        fuel -= 0.03;
    }

    public void Refuel()
    {
        fuel = maxFuel;
    }
}