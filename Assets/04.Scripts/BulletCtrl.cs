using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public Transform tr;
    public float speed = 5f;

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("PLAYER"))
        {
            Destroy(this.gameObject);
        }
    }
}
