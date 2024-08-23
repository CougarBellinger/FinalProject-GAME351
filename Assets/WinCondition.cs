using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private GameObject enemies;
    private GameObject winOverlay, player;
    public bool win = false;

    private float timer = 5f;

    void Start()
    {
        enemies = GameObject.FindGameObjectWithTag("Enemies");
        player = GameObject.Find("Player");

        winOverlay = GameObject.Find("WinScreen");

        winOverlay.SetActive(false);
    }

    void Update()
    {
        if (enemies.transform.childCount <= 0)
        {
            win = true;
            winOverlay.SetActive(true);
            player.SetActive(false);

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
