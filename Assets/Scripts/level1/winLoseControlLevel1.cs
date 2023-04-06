using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winLoseControlLevel1 : MonoBehaviour
{
    public GameObject loseWord, winWord, lose_trigger, startWall, level;
    public int total_count;
    private int count;
    private bool lose = false;
    public float lose_word_time = 15.0f;

    public CanvasGroup canvas;
    public GameObject invinCanvas;

    // Start is called before the first frame update
    void Start()
    {
        winWord.SetActive(false);
        loseWord.SetActive(false);
        if (global.level1_lose_word)
        {
            loseWord.SetActive(true);
            StartCoroutine(removeLoseWord());
        }
            
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == total_count)
        {
            global.level1_lose_word = false;
            level.SetActive(false);
            winWord.SetActive(true);
            lose_trigger.SetActive(false);
            startWall.SetActive(false);
        }

        if (lose)
        {
            global.level1_lose_word = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator removeLoseWord()
    {
        yield return new WaitForSeconds(lose_word_time);
        loseWord.SetActive(false);
    }

    //IEnumerator loseAndRestart()
    //{
    //invinCanvas.SetActive(true);
    //canvas.interactable = false;
    //while (canvas.alpha < 1)
    //{
    //    canvas.alpha += Time.deltaTime / 2;
    //    yield return null;
    //}
    //canvas.alpha = 1;


    //}

    public void add_count()
    {
        count += 1;
    }

    public void lose_game()
    {
        lose = true;
    }

}
