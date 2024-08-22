using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject sword;
    public GameObject shotgun;
    public GameObject defaultWeapon;
    public GameObject shotGunParent;

    private GameObject currentWeapon;
    private Transform rightHand;

    void Start()
    {
        sword.SetActive(false);
        shotgun.SetActive(false);
        defaultWeapon.SetActive(true);
        currentWeapon = defaultWeapon;
        rightHand = GameObject.Find("RightHand")?.transform;
        if (rightHand == null)
        {
            Debug.LogError("RightHand object not found in the scene.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(defaultWeapon);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(shotGunParent);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(sword);
        }
        FollowHand();
    }

    void SwitchWeapon(GameObject newWeapon)
    {
        if (currentWeapon == newWeapon)
        {
            return;
        }
        if (currentWeapon!= null)
        {
            currentWeapon.SetActive(false);
        }
        newWeapon.SetActive(true);
        currentWeapon = newWeapon;
        if (rightHand!= null)
        {
            if (newWeapon!= null)
            {
                newWeapon.transform.SetParent(rightHand);
                newWeapon.transform.localPosition = Vector3.zero;
                newWeapon.transform.localRotation = Quaternion.identity;
            }
        }
    }

    void FollowHand()
    {
        if (currentWeapon!= null)
        {
            if (rightHand!= null)
            {
                currentWeapon.transform.position = rightHand.position;
                currentWeapon.transform.rotation = rightHand.rotation;
            }
            else
            {
                Debug.LogWarning("RightHand transform is null. Weapon will not follow.");
            }
        }
    }
}