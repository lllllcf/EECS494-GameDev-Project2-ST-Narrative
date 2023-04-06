using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBack : MonoBehaviour
{
    public float black_time = 1.0f;

    public CanvasGroup canvas;
    public GameObject invinCanvas;
    public void click()
    {
        global.level1_lose_word = false;
        global.level2_lose_word = false;
        global.level3_lose_word = false;
        global.level4_lose_word = false;
        global.level5_lose_word = false;
        global.level6_lose_word = false;
        global.level7_lose_word = false;
        global.level8_lose_word = false;
        global.level9_lose_word = false;

        print("click");
        StartCoroutine(piece1Back());

    }

    IEnumerator piece1Back()
    {
        invinCanvas.SetActive(true);
        canvas.interactable = false;
        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / 2;
            yield return null;
        }
        canvas.alpha = 1;

        yield return new WaitForSeconds(black_time);
        SceneManager.LoadScene("ChooseLevel");
    }
}