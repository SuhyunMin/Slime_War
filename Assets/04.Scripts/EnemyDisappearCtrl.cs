using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisappearCtrl : MonoBehaviour
{
    public float speed = 0.4f;
    
    void Start()
    {
        Invoke("destroy", speed);
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
}
