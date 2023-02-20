using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    public GameObject title;
    public float seconds;

    // Start is called before the first frame update
    void Start()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        title.SetActive(false);

        StartCoroutine(showText());
        
    }

    IEnumerator showText()
    {
        yield return new WaitForSeconds(seconds);
        title.SetActive(true);
        GetComponent<TextRevealer>().RevealText(title);
    }

}