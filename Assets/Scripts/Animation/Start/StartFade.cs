using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;

    public GameObject b1;
    public GameObject b2;

    public GameObject invinCanvas;

    public float pre_wait_time;
    public CanvasGroup canvas;
    public float black_time;
    public float button_time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(canvasFade());
    }

    IEnumerator canvasFade()
    {
        
        yield return new WaitForSeconds(pre_wait_time);
        invinCanvas.SetActive(true);
        //**************fade the screen********************************************//
        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / 2;
            yield return null;
        }
        canvas.alpha = 1;
        canvas.interactable = false;

        //**************move player && camera********************************************//
        Camera.main.gameObject.transform.position = new Vector3(1.47f, 0.0f, -10.0f);
        yield return new WaitForSeconds(black_time);

        //**************fade in the screen********************************************//
        canvas.interactable = true;
        while (canvas.alpha > 0)
        {
            canvas.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        canvas.alpha = 0;
        canvas.interactable = false;

        Button1.SetActive(true);
        //GetComponent<TextRevealer>().RevealText(b1);
        //Button1.SetActive(true);
        yield return new WaitForSeconds(button_time);
        //Button2.SetActive(true);
        //GetComponent<TextRevealer>().RevealText(b2);
        Button2.SetActive(true);

        invinCanvas.SetActive(false);

    }


}
