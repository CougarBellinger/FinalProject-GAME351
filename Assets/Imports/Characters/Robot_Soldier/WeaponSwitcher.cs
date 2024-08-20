using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject sword;
    public GameObject shotgun;
    public GameObject defaultWeapon;

    private GameObject currentWeapon;

    void Start()
    {
        currentWeapon = defaultWeapon;
        sword.SetActive(false);
        shotgun.SetActive(false);
        defaultWeapon.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(sword);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(shotgun);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(defaultWeapon);
        }
    }

    void SwitchWeapon(GameObject newWeapon)
    {
        currentWeapon.SetActive(false);
        newWeapon.SetActive(true);
        currentWeapon = newWeapon;
    }
}
