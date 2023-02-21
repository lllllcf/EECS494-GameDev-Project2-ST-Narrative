using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sunTriggerController : MonoBehaviour
{
    public GameObject player;
    private bool nearWater = false;

    public float black_time = 10.0f;

    public CanvasGroup canvas;
    public GameObject invinCanvas, quoteCanvas;
    // Start is called before the first frame update
    void Start()
    {
        quoteCanvas.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (nearWater && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            StartCoroutine(toNextLevel());
        }
    }

    IEnumerator toNextLevel()
    {
        invinCanvas.SetActive(true);
        canvas.interactable = false;
        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / 2;
            yield return null;
        }
        canvas.alpha = 1;
        quoteCanvas.SetActive(true);

        yield return new WaitForSeconds(black_time);
        SceneManager.LoadScene("Level2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) nearWater = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) nearWater = false;
    }

}
