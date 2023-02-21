using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toLevel9 : MonoBehaviour
{
    public float black_time = 1.0f;

    public CanvasGroup canvas;
    public GameObject invinCanvas;
    public void click()
    {
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
        SceneManager.LoadScene("Level9");
    }
}