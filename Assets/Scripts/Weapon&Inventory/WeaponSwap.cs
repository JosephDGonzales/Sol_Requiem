using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public int WeaponSelected = 0;

    // Start is called before the first frame update
    void Start()
    {
        WeaponSelect();
    }

    // Update is called once per frame
    void Update()
    {
        int prevWeaponSelected = WeaponSelected;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (WeaponSelected >= transform.childCount - 1)
            {
                WeaponSelected = 0;
            }
            else
            {
                WeaponSelected++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (WeaponSelected <= 0)
            {
                WeaponSelected = transform.childCount - 1;
            }
            else
            {
                WeaponSelected--;
            }
        }

        if (prevWeaponSelected != WeaponSelected)
        {
            WeaponSelect();
        }    
    }

    void WeaponSelect()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == WeaponSelected)    //Add check for whether or not weapon is picked up
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }    
    }
}