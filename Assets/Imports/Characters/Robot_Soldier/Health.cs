using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHits = 5;
    private int currentHits = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MachineGunRobot_FireBurster")
        {
            currentHits++;
            if (currentHits >= maxHits)
            {
                Destroy(gameObject);
            }
        }
    }
}
