using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHits = 5;
    private int currentHits = 0;
    private bool isHit = false;

    void Update()
    {
        if (isHit)
        {
            currentHits++;
            if (currentHits >= maxHits)
            {
                Destroy(gameObject);
            }
            isHit = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MachineGunRobot_FireBurster")
        {
            isHit = true;
        }
    }
}
