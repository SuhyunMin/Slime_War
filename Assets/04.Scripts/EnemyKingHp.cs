using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKingHp : MonoBehaviour
{
    public int hp = 3;
    public int initHp = 3;

    public Transform tr;
    public GameObject effect, gameOverText, EnemyKing;

    void Start()
    {
        gameOverText.SetActive(false);
        EnemyKing.GetComponent<SpriteRenderer>().enabled = true;

    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("PLAYERBullet"))
        {
            hp--;

            if (hp <= 0)
            {
                Instantiate(effect, tr.position, Quaternion.identity);
                gameOverText.SetActive(true);
                gameObject.SetActive(false);
                Invoke("SceneChange", 1.0f);
                EnemyKing.GetComponent<SpriteRenderer>().enabled = false;

            }
        }
    }

    void SceneChange()
    {
        if (SceneManager.GetActiveScene().name == "1_Play")
        {
            SceneManager.LoadScene("2_Play");        
        }
        else if (SceneManager.GetActiveScene().name == "2_Play")
        {
            SceneManager.LoadScene("3_Play");
        }
        else if (SceneManager.GetActiveScene().name == "3_Play")
        {
            SceneManager.LoadScene("4_Play");
        }
        else if (SceneManager.GetActiveScene().name == "4_Play")
        {
            SceneManager.LoadScene("5_Play");
        }
        else if (SceneManager.GetActiveScene().name == "5_Play")
        {
            SceneManager.LoadScene("6_Play");
        }
        else if (SceneManager.GetActiveScene().name == "6_Play")
         {
             SceneManager.LoadScene("7_Play");
         }
         else if(SceneManager.GetActiveScene().name == "7_Play")
         {
             SceneManager.LoadScene("8_GameOver");
         }

        //Quit();
    }

    /* public void Quit()
     {
 #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false; 
 #elif UNITY_WEBPLAYER
         Application.OpenURL("http://google.com");
 #else
         Application.Quit();

     }*/
}