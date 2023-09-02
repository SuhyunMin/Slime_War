using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour

{
    private AudioSource audio;
    public AudioClip movingSound;

    // Start is called before the first frame update
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.movingSound;
        this.audio.loop = false;
    }

    public void startGame()
    {
        this.audio.Play();
        StartCoroutine("sceneStart");   
    }
    public void restartGame()
    {
        this.audio.Play();
        StartCoroutine("Restart");
    }

    IEnumerator sceneStart()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene("1_Play");
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene("0_Start");
    }
}
