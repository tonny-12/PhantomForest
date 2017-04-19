using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBossRoom : MonoBehaviour {

    public GameObject player;
    public GameObject boss;
    public GameObject door;

    // Use this for initialization
    void Start () {
        boss.SetActive(false);
        door.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if ( (37f < player.transform.position.x) && (player.transform.position.x < 41f) && (player.transform.position.y < -30) )
        {
            boss.SetActive(true);
            door.SetActive(true);
        }
	}

}
