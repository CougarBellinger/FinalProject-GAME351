using UnityEngine;
using TMPro;

public class EnemyKilled : MonoBehaviour
{
    public TextMeshProUGUI killCountText;

    private int killCount = 0;

    void Start()
    {
        UpdateKillCountText();
    }

    public void IncrementKillCount()
    {
        killCount++;
        UpdateKillCountText();
    }

    void UpdateKillCountText()
    {
        killCountText.text = "Kills: " + killCount;
    }
}
