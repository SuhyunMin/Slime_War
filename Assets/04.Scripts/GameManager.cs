using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   /* public GameObject player;
    Vector3 StartingPos;
    Quaternion StartingRotate;
    bool isStarted = false;
    static bool isEnded = false;

    static int stageLevel = 0;*/


    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(600, 1024, true);
    }

    void Start()
    {
        //if (stageLevel > 0)
        // StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

        if (stageLevel < 5)
        {
            GUILayout.Label(" stage " + (stageLevel + 1));
        }
        else
            GUILayout.Label(" stage End");

        GUILayout.Space(5);
        GUILayout.EndVertical();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();

        if (!isStarted && stageLevel == 0)
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            GUILayout.Label("R U Ready? :");

            if (GUILayout.Button("Start!"))
            {
                isStarted = true;
                StartGame();
            }

            GUILayout.Space(100);
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        else if (isEnded && stageLevel == 5)
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            GUILayout.Label("Thanks for Play :D");

            if (GUILayout.Button("Restart?"))
            {
                isEnded = false;
                stageLevel = 0;
                ScoreManager.setScore(0);
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
            GUILayout.Space(100);
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        if (other.gameObject.tag == "End")
        {
            other.enabled = false;
            GameManager.EndGame();
        }

       

    }
    public static void EndGame()
    {
        Time.timeScale = 0f;
        stageLevel++;

        if (stageLevel == 5)
            isEnded = true;
        else
            SceneManager.LoadScene(stageLevel, LoadSceneMode.Single);
    }*/
}

