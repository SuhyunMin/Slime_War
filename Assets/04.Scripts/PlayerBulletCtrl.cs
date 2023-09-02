using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCtrl : MonoBehaviour
{
    public Transform tr;
    public float speed = 10f;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
