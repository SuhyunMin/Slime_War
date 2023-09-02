using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulllet : MonoBehaviour
{
    public GameObject[] pos;
    public GameObject bullet;

    public float delayTime = 0.3f;

    private float start;


    void Start()
    {
        start = Random.Range(0.0f, 3.0f);
        InvokeRepeating("Fire", start, delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Fire();
        
    }

    void Fire()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            GameObject _bullet = Instantiate(bullet, pos[i].transform.position, pos[i].transform.rotation);
            Destroy(_bullet, 5.0f); 
        }
    }
}
