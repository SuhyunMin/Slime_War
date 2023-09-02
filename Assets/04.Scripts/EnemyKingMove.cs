using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKingMove : MonoBehaviour
{
    public float moveSpeed = 1;

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

    public GameObject[] pos;
    public GameObject bullet;

    public float delayTime = 7f;

    private float start;

    public GameObject EnemyKing;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Sprite 보라300;

    private AudioSource audio;
    public AudioClip shootingSound;


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
        EnemyKing.GetComponent<Animator>().enabled = false;
        start = Random.Range(0.5f, 5.0f);
        InvokeRepeating("waitForStop", start, delayTime);

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.shootingSound;
        this.audio.loop = false;

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

    void waitForStop()
    {
        EnemyKing.GetComponent<Animator>().enabled = true;
        for (int i = 0; i < pos.Length; i++)
        {
            Instantiate(bullet, pos[i].transform.position, pos[i].transform.rotation);

        }
        this.audio.Play();
        Invoke("Fire", 1.0f);
    }

    void Fire()
    {
        EnemyKing.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = 보라300;


    }

    
}
