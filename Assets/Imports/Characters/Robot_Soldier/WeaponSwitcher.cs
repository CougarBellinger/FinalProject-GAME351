using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject sword;
    public GameObject shotgun;
    public GameObject defaultWeapon;

    public Sprite swordSprite;
    public Sprite shotgunSprite;
    public Sprite defaultWeaponSprite;

    private GameObject currentWeapon;
    private Transform rightHandPinky4;
    private Image weaponUIImage;

    void Start()
    {
        sword.SetActive(false);
        shotgun.SetActive(false);
        defaultWeapon.SetActive(true);
        currentWeapon = defaultWeapon;

        rightHandPinky4 = GameObject.Find("RightHandPinky4").transform;
        weaponUIImage = GameObject.Find("Weapon").GetComponent<Image>();

        weaponUIImage.sprite = defaultWeaponSprite;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(defaultWeapon, defaultWeaponSprite);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(shotgun, shotgunSprite); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(sword, swordSprite);
        }

        FollowHand();
    }

    void SwitchWeapon(GameObject newWeapon, Sprite newWeaponSprite)
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false);
        }

        newWeapon.SetActive(true);
        currentWeapon = newWeapon;

        weaponUIImage.sprite = newWeaponSprite;
    }

    void FollowHand()
    {
        if (currentWeapon != null)
        {
            currentWeapon.transform.position = rightHandRing4.position;
            currentWeapon.transform.rotation = rightHandRing4.rotation;
        }
    }
}
