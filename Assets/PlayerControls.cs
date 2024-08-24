using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class PlayerControls : MonoBehaviour
{
    public PlayableDirector cutscene;
    public GameObject player;
    public GameObject enemiesParent;
    public GameObject bgm;
    public GameObject gunSound;

    private EnemyAI[] enemyAI;
    private bool cutscenePlaying;


    // Start is called before the first frame update
    void Start()
    {
        enemyAI = enemiesParent.GetComponentsInChildren<EnemyAI>();
        cutscenePlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cutscenePlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || cutscene.time >= cutscene.duration - 1f)
            {
                player.GetComponent<CharacterMovement>().enabled = true;
                player.GetComponent<CharacterShoot>().enabled = true;

                bgm.SetActive(true);
                gunSound.SetActive(true);

                foreach (EnemyAI enemyAI in enemyAI)
                {
                    enemyAI.enabled = true;
                }

                cutscenePlaying = false;
                cutscene.Stop();
            }

            else
            {
                player.GetComponent<CharacterMovement>().enabled = false;
                player.GetComponent<CharacterShoot>().enabled = false;

                bgm.SetActive(false);
                gunSound.SetActive(false);

                foreach (EnemyAI enemyAI in enemyAI)
                {
                    enemyAI.enabled = false;
                }
            }
        }
    }
}
