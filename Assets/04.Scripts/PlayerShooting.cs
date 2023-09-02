using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject[] pos;
    public GameObject bullet;

    private AudioSource audio;
    public AudioClip shootingSound;


    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.shootingSound;
        this.audio.loop = false;

    }

    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            Fire();
            this.audio.Play();
        }
    }

    void Fire()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            Instantiate(bullet, pos[i].transform.position, pos[i].transform.rotation);
        }
    }

  
}
