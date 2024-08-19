using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2Prefab;
    private GameObject currentWeapon;

    void Start()
    {
        if (weapon1 != null)
        {
            currentWeapon = weapon1;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SwitchWeapon();
        }
    }

    void SwitchWeapon()
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        if (weapon2Prefab != null)
        {
            currentWeapon = Instantiate(weapon2Prefab, transform);
            currentWeapon.transform.localPosition = Vector3.zero;
            currentWeapon.transform.localRotation = Quaternion.identity;
        }
    }
}

