using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TbackStart : MonoBehaviour
{
    public CanvasGroup canvas;
    public GameObject invinCanvas;
    public int currentPiece = 1;
    public float black_time = 1.0f;
    public float camera_duration_sec = 2.0f;

    public GameObject Button1, Button2;

    public GameObject text1, text2;

    public float letterPause = 0.08f;

    string message1, message2;

    public AudioClip word_clip;
    bool clip = false;

    void Start()
    {

        message2 = text2.GetComponent<TMPro.TextMeshProUGUI>().text;
        
        message1 = text1.GetComponent<TMPro.TextMeshProUGUI>().text;
        
    }

    public void click()
    {
        if (currentPiece == 1)
            StartCoroutine(piece1Back());
        if (currentPiece == 2)
            StartCoroutine(performTransition1(10.0f, 0.0f, camera_duration_sec));
        if (currentPiece == 3)
            StartCoroutine(performTransition2(10.0f, 0.0f, camera_duration_sec));
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
        SceneManager.LoadScene("FakeStart");
    }

    private IEnumerator performTransition1(float camera_move_vertical, float camera_move_horizontal, float camera_duration_sec)
    {
        text1.GetComponent<TMPro.TextMeshProUGUI>().text = "";

        Button1.SetActive(false);
        Button2.SetActive(false);
        GameObject.Find("player").GetComponent<ArrowKeyMovement>().enabled = false;
        GameObject.Find("player").GetComponent<InstantMove>().enabled = false;
        GameObject.Find("NextController").GetComponent<ToT2>().sp.SetActive(false);

        Vector3 initial_pos = Camera.main.gameObject.transform.position;
        // left positive, right negative, down positive, up negative
        Vector3 dest_pos = Camera.main.gameObject.transform.position - new Vector3(camera_move_vertical, camera_move_horizontal, 0.0f);

        float initial_time = Time.time;
        // The "progress" variable will go from 0.0f -> 1.0f over the course of "duration_sec" seconds.
        float progress = (Time.time - initial_time) / camera_duration_sec;

        while (progress < 1.0f)
        {
            // Recalculate the progress variable every frame. Use it to determine
            // new position on line from "initial_pos" to "dest_pos"
            progress = (Time.time - initial_time) / camera_duration_sec;
            Vector3 new_position = Vector3.Lerp(initial_pos, dest_pos, progress);
            Camera.main.gameObject.transform.position = new_position;

            // yield until the end of the frame, allowing other code / coroutines to run
            // and allowing time to pass.
            yield return null;
        }

        Camera.main.gameObject.transform.position = dest_pos;
        GameObject.Find("player").transform.position = new Vector3(5.5f, 0.8f, 0.0f);

        currentPiece -= 1;
        GameObject.Find("NextController").GetComponent<ToT2>().currentPiece -= 1;

        GameObject.Find("player").GetComponent<ArrowKeyMovement>().enabled = true;
        GameObject.Find("player").GetComponent<InstantMove>().enabled = true;

        //GameObject.Find("shadowPlayer").transform.position = GameObject.Find("player").transform.position;

        Button1.SetActive(true);
        Button2.SetActive(true);
        invinCanvas.SetActive(true);

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

        invinCanvas.SetActive(false);

    }

    private IEnumerator performTransition2(float camera_move_vertical, float camera_move_horizontal, float camera_duration_sec)
    {

        text2.GetComponent<TMPro.TextMeshProUGUI>().text = "";

        Button1.SetActive(false);
        Button2.SetActive(false);
        GameObject.Find("player").GetComponent<ArrowKeyMovement>().enabled = false;
        GameObject.Find("player").GetComponent<InstantMove>().enabled = false;
        GameObject.Find("NextController").GetComponent<ToT2>().sp.SetActive(false);

        Vector3 initial_pos = Camera.main.gameObject.transform.position;
        // left positive, right negative, down positive, up negative
        Vector3 dest_pos = Camera.main.gameObject.transform.position - new Vector3(camera_move_vertical, camera_move_horizontal, 0.0f);

        float initial_time = Time.time;
        // The "progress" variable will go from 0.0f -> 1.0f over the course of "duration_sec" seconds.
        float progress = (Time.time - initial_time) / camera_duration_sec;

        while (progress < 1.0f)
        {
            // Recalculate the progress variable every frame. Use it to determine
            // new position on line from "initial_pos" to "dest_pos"
            progress = (Time.time - initial_time) / camera_duration_sec;
            Vector3 new_position = Vector3.Lerp(initial_pos, dest_pos, progress);
            Camera.main.gameObject.transform.position = new_position;

            // yield until the end of the frame, allowing other code / coroutines to run
            // and allowing time to pass.
            yield return null;
        }

        Camera.main.gameObject.transform.position = dest_pos;
        GameObject.Find("player").transform.position = new Vector3(11.0f, 1.5f, 0.0f);

        currentPiece -= 1;
        GameObject.Find("NextController").GetComponent<ToT2>().currentPiece -= 1;

        GameObject.Find("player").GetComponent<ArrowKeyMovement>().enabled = true;
        GameObject.Find("player").GetComponent<InstantMove>().enabled = true;

        GameObject.Find("NextController").GetComponent<ToT2>().sp.SetActive(true);
        GameObject.Find("shadowPlayer").transform.position = GameObject.Find("player").transform.position;

        Button1.SetActive(true);
        Button2.SetActive(true);
        invinCanvas.SetActive(true);

        //AudioSource.PlayClipAtPoint(enter_clip, Camera.main.transform.position);
        //yield return new WaitForSeconds(1.0f);
        foreach (char letter in message2.ToCharArray())
        {
            clip = !clip;
            if (clip)
                AudioSource.PlayClipAtPoint(word_clip, Camera.main.transform.position);
            text2.GetComponent<TMPro.TextMeshProUGUI>().text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }

        invinCanvas.SetActive(false);
    }
}
