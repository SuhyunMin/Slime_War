using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float moveSpeed = 2;

    private Vector2 minMovePoint;
    private Vector2 maxMovePoint;

    private Rigidbody2D myrb;

    public bool isWalking;

    public float walkTime = 1;
    private float walkCounter;
    public float waitTime = 1;
    private float waitCounter;


    private int WalkDirection;

    public Collider2D moveZone;

    private bool hasMoveZone;

    public GameObject prefab;


    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if (moveZone != null)
        {
            minMovePoint = moveZone.bounds.min;
            maxMovePoint = moveZone.bounds.max;
            hasMoveZone = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (isWalking)
        {
            walkCounter -= Time.deltaTime;

            switch (WalkDirection)
            {
                case 0:
                    myrb.velocity = new Vector2(moveSpeed, 0);
                    if (hasMoveZone && transform.position.x >= maxMovePoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    myrb.velocity = new Vector2(-moveSpeed, 0);
                    if (hasMoveZone && transform.position.x <= minMovePoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {
            waitCounter -= Time.deltaTime;

            myrb.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }

    }




    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 2);
        isWalking = true;
        walkCounter = walkTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (gameObject.name != "Collider")
        {
            if (collision.CompareTag("PLAYER"))
            {
                for (int i = 0; i < 1; i++)
                {
                    Destroy(collision.gameObject);
                    GameObject enemy = Instantiate(prefab, new Vector3(transform.position.x + 2f * i, transform.position.y, transform.position.z), Quaternion.identity);
                    enemy.SetActive(true);
                }
            }
        }
        */
    }
}
