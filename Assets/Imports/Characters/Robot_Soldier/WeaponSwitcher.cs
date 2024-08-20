using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject sword;
    public GameObject shotgun;
    public GameObject defaultWeapon;

    private GameObject currentWeapon;
    private Transform rightHandMiddle1;

    void Start()
    {
        currentWeapon = defaultWeapon;
        sword.SetActive(false);
        Debug.Log("Setting sword inactive.");
        shotgun.SetActive(false);
        defaultWeapon.SetActive(true);
        rightHandMiddle1 = GameObject.Find("RightHandMiddle4").transform;
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
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(sword);
        }

        FollowHand();
    }

    void SwitchWeapon(GameObject newWeapon)
    {
        if (currentWeapon!= null)
        {
            currentWeapon.SetActive(false);
            Debug.Log("Disabling previous weapon. Current weapon active status: " + currentWeapon.activeSelf);
        }

        newWeapon.SetActive(true);
        currentWeapon = newWeapon;

        if (currentWeapon == sword)
        {
            Debug.Log("Switching to sword. Sword active status: " + sword.activeSelf);
        }
    }

    void FollowHand()
    {
        if (currentWeapon!= null)
        {
            currentWeapon.transform.position = rightHandMiddle1.position;
            currentWeapon.transform.rotation = rightHandMiddle1.rotation;
        }
    }
}