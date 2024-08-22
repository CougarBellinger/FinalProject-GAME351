using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    //public GameObject sword;
    public GameObject shotgun;
    public GameObject defaultWeapon;
    private GameObject currentWeapon;

    void Start()
    {
        //sword.SetActive(false);
        shotgun.SetActive(false);
        defaultWeapon.SetActive(true);
        currentWeapon = defaultWeapon;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(defaultWeapon);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(shotgun);
        }
        // else if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     SwitchWeapon(sword);
        // }
    }

    void SwitchWeapon(GameObject newWeapon)
    {
        if (currentWeapon == newWeapon)
        {
            return;
        }
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false);
        }
        newWeapon.SetActive(true);
        currentWeapon = newWeapon;
    }
}

