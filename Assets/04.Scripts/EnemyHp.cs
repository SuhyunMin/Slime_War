using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHp : MonoBehaviour
{
    public int hp = 1;
    public int initHp = 1;

    public Transform tr;
    public GameObject effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PLAYERBullet")
        {
            hp--;
            Debug.Log($"hit : hp : {hp}");

            if (hp <= 0)
            {
                Debug.Log($"root name : {transform.root.gameObject.name}");

                Instantiate(effect, tr.position, Quaternion.identity);
                Destroy(transform.root.gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
