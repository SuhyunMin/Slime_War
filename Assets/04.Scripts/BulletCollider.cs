using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCollider : MonoBehaviour
{
    public Sprite player_PB_1;
    public Sprite player_PB_2;
    public Sprite player_PB_3;
    public Sprite player_PB_4;

    public PlayerControl playerControl;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerControl = FindObjectOfType<PlayerControl>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBulletSprite(int hp)
    {
        Debug.Log("SetBulletSprite");


        if (hp >= 8)
        {
            spriteRenderer.sprite = player_PB_1;
            Debug.Log($"888");
        }
        else if (hp >= 6)
        {
            spriteRenderer.sprite = player_PB_2;
            Debug.Log($"666");
        }
        else if (hp >= 4)
        {
            spriteRenderer.sprite = player_PB_3;
            Debug.Log($"444");
        }
        else if (hp >= 2)
        {
            spriteRenderer.sprite = player_PB_4;
            Debug.Log($"222");
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("ENEMY"))
        {
            Destroy(this.gameObject);
        }
    }
}
