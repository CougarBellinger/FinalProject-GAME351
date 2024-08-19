using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;

    void Start()
    {
        weapon1.SetActive(true);
        weapon2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(2);
        }
    }

    void SwitchWeapon(int weaponNumber)
    {
        switch (weaponNumber)
        {
            case 1:
                weapon1.SetActive(true);
                weapon2.SetActive(false);
                break;
            case 2:
                weapon1.SetActive(false);
                weapon2.SetActive(true);
                break;
        }
    }
}

