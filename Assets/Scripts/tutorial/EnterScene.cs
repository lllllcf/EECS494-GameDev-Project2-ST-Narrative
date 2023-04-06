using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScene : MonoBehaviour
{
    public CanvasGroup canvas;
    public GameObject invinCanvas;

    public GameObject text1;

    public bool isTutorial = false;

    public float letterPause = 0.08f;

    string message1;

    public AudioClip word_clip;
    bool clip = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isTutorial)
        {
            message1 = text1.GetComponent<TMPro.TextMeshProUGUI>().text;
            
        }
        

        StartCoroutine(canvasFade());
    }

    IEnumerator canvasFade()
    {
        

        if (isTutorial)
        {
            GameObject level = GameObject.Find("level");
            level.SetActive(false);
            canvas.alpha = 1;
            canvas.interactable = false;

            text1.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            //**************fade in the screen********************************************//
            canvas.interactable = true;
            while (canvas.alpha > 0)
            {
                canvas.alpha -= Time.deltaTime / 2;
                yield return null;
            }
            canvas.alpha = 0;

            

            //AudioSource.PlayClipAtPoint(enter_clip, Camera.main.transform.position);
            //yield return new WaitForSeconds(1.0f);
            foreach (char letter in message1.ToCharArray())
            {
                clip = !clip;
                if (clip)
                    AudioSource.PlayClipAtPoint(word_clip, Camera.main.transform.position);
                text1.GetComponent<TMPro.TextMeshProUGUI>().text += letter;
                yield return 0;
                yield return new WaitForSeconds(letterPause);
            }

            level.SetActive(true);
        }
        else
        {
            canvas.alpha = 1;
            canvas.interactable = false;

            //text1.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            //**************fade in the screen********************************************//
            canvas.interactable = true;
            while (canvas.alpha > 0)
            {
                canvas.alpha -= Time.deltaTime / 2;
                yield return null;
            }
            canvas.alpha = 0;
        }

        invinCanvas.SetActive(false);

    }
}
