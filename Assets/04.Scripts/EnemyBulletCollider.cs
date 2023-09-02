using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollider : MonoBehaviour
{

    public PlayerControl playerControl;

    private void Awake()
    {
        playerControl = FindObjectOfType<PlayerControl>();
        // Debug.Log($"Player Hp : {playerControl.Hp}"); // TODO
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("PLAYER"))
        {
            Destroy(this.gameObject);
        }
    }


}
