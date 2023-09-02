using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    public int hp = 10;

    public int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            OnPlayerHpChange(hp);
        }
    }
    public int initHp = 10;

    public Rigidbody2D rb;
    public float speed = 50.0f;

    public Transform tr;
    public GameObject effect, gameOverText;
    public Animator animator;
    // GameObject obj = GameObject.FindGameObjectWithTag("PLAYER");
    //obj.gameObject.AddComponent<Animator>();

    //public GameObject playerPrefab;

    // GameObject go = Instantiate(playerPrefab);

    public void OnPlayerHpChange(int hp)
    {
        if (hp == 9)
        {
      
        }
    }


    public GameObject[] pos;
    public GameObject bullet;

    public Sprite player_P_1;
    public Sprite player_P_2;
    public Sprite player_P_3;
    public Sprite player_P_4;

    float h;  //좌우
    float v;  //위아래

    void Awake()
    {
        Hp = initHp;
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Fire();
        }

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(h, v);
        rb.velocity = dir * speed * Time.deltaTime;

        float size = Camera.main.orthographicSize;
        float offset = 0.5f;
        
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float wSize = Camera.main.orthographicSize * screenRatio;

        if (tr.position.x >= wSize - offset)
        {
            tr.position = new Vector3(wSize - offset, tr.position.y, 0);
        }

        if (tr.position.x <= -wSize + offset)
        {
            tr.position = new Vector3(-wSize + offset, tr.position.y, 0);
        }

        float offset1 = 8.5f;  //적에게 너무 가까이 가지 않게 조절
        if (tr.position.y >= size - offset1)
        {
            tr.position = new Vector3(tr.position.x, size - offset1, 0);
        }

        if (tr.position.y <= -size + offset)
        {
            tr.position = new Vector3(tr.position.x, -size + offset, 0);
        }
    }

    public void Fire()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            GameObject prefab = Instantiate(bullet, pos[i].transform.position, pos[i].transform.rotation);
            BulletCollider bulletCollider = prefab.GetComponent<BulletCollider>();
            bulletCollider.SetBulletSprite(Hp);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("ENEMY"))
        {
            Hp--;

            if (Hp <= 8)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = player_P_1;
                animator.SetInteger("playerHp", Hp);
            }
            if (Hp <= 6)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = player_P_2;
                animator.SetInteger("playerHp", Hp);
            }
            if (Hp <= 4)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = player_P_3;
                animator.SetInteger("playerHp", Hp);
            }
            if (Hp <= 2)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = player_P_4;
                animator.SetInteger("playerHp", Hp);
            }
            if (Hp <= 0)
            {
                Instantiate(effect, tr.position, Quaternion.identity);
                Invoke("BackToFirstScene", 1.0f);
                gameOverText.SetActive(true);
                gameObject.SetActive(false);              
            }
        }

    }

    void BackToFirstScene()
    {
        Debug.Log("scene changed");
        if (SceneManager.GetActiveScene().name == "0_Start")
        {
            SceneManager.LoadScene("1_Play");
        }
        else
            SceneManager.LoadScene("8_GameOver");
        Destroy(this.gameObject);

    }




}

