﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MyEnemyController : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D enemyRigidBody;

    private bool moving;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    public float waitToReload;
    private bool reloading;

    private GameObject player;

	// Use this for initialization
	void Start () {
        enemyRigidBody = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
    }
	
	// Update is called once per frame
	void Update () {
		if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            enemyRigidBody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            enemyRigidBody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }

        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                player.SetActive(true);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        /*
        if (other.gameObject.tag == "Player")
        {
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            player = other.gameObject;
        }
        */
    }
}
