using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBossRoom : MonoBehaviour {

    public GameObject player;
    public GameObject boss;
    public GameObject doorEntrance;
    public GameObject doorExit;

    public string bossTag;

    private GameObject[] sensedObjects;

    // Use this for initialization
    void Start () {
        boss.SetActive(false);
        doorEntrance.SetActive(false);
        doorExit.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (boss == null)
        {
            doorExit.SetActive(false);
        }

        if (boss != null)
        {
            if ((37f < player.transform.position.x) && (player.transform.position.x < 41f) && (player.transform.position.y < -30))
            {
                boss.SetActive(true);
                doorEntrance.SetActive(true);
                doorExit.SetActive(true);
            }
        }

    }

}
